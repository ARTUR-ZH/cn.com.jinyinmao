// ***********************************************************************
// Project          : io.yuyi.jinyinmao.server
// Author           : Siqi Lu
// Created          : 2015-05-25  4:38 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-06-03  3:34 AM
// ***********************************************************************
// <copyright file="BackOfficeController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Moe.AspNet.Filters;
using Moe.Lib;
using Yuyi.Jinyinmao.Api.Filters;
using Yuyi.Jinyinmao.Api.Models;
using Yuyi.Jinyinmao.Api.Models.BackOffice;
using Yuyi.Jinyinmao.Domain.Commands;
using Yuyi.Jinyinmao.Domain.Dtos;
using Yuyi.Jinyinmao.Packages.Helper;
using Yuyi.Jinyinmao.Service.Interface;

namespace Yuyi.Jinyinmao.Api.Controllers
{
    /// <summary>
    ///     BackOfficeController.
    /// </summary>
    [RoutePrefix("BackOffice"), HMACAuthentication, IpAuthorize]
    public class BackOfficeController : ApiControllerBase
    {
        private readonly IProductInfoService productInfoService;
        private readonly IProductService productService;
        private readonly IUserService userService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BackOfficeController" /> class.
        /// </summary>
        /// <param name="productInfoService">The product information service.</param>
        /// <param name="productService">The product service.</param>
        /// <param name="userService">The user service.</param>
        public BackOfficeController(IProductInfoService productInfoService, IProductService productService, IUserService userService)
        {
            this.productInfoService = productInfoService;
            this.productService = productService;
            this.userService = userService;
        }

        /// <summary>
        ///     用户信息
        /// </summary>
        /// <param name="userIdentifier">用户唯一标识</param>
        /// <response code="200"></response>
        /// <response code="401">认证失败</response>
        /// <response code="403">未授权</response>
        /// <response code="500"></response>
        [Route("UserInfo/{userIdentifier:length(32)}"), ResponseType(typeof(UserInfoResponse))]
        public async Task<IHttpActionResult> GetUserInfo(string userIdentifier)
        {
            Guid userId = Guid.ParseExact(userIdentifier, "N");

            UserInfo info = await this.userService.GetUserInfoAsync(userId);

            return this.Ok(info.ToResponse());
        }

        /// <summary>
        ///     发行金包银理财产品
        /// </summary>
        /// <param name="request">
        ///     JBY产品上架请求
        /// </param>
        /// <response code="200">上架成功</response>
        /// <response code="400">请求格式不合法</response>
        /// <response code="400">
        ///     上架失败：产品编号已存在
        ///     <br />
        ///     认证失败
        /// </response>
        /// <response code="401">认证失败</response>
        /// <response code="403">未授权</response>
        /// <response code="500"></response>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("CurrentProduct/Issue"), ActionParameterRequired, ActionParameterValidate(Order = 1)]
        public async Task<IHttpActionResult> JBYProductIssue(IssueJBYProductRequest request)
        {
            bool result = await this.productInfoService.CheckProductNoExistsAsync(request.ProductNo);
            if (result)
            {
                return this.BadRequest("上架失败：产品编号已存在");
            }

            int maxIssueNo = await this.productInfoService.GetJBYIssueNoAsync();
            if (request.IssueNo <= maxIssueNo)
            {
                return this.BadRequest($"上架失败：金包银产品期数必须大于 {maxIssueNo}");
            }

            if (request.EndSellTime < DateTime.UtcNow.AddHours(8).AddMinutes(10))
            {
                return this.BadRequest("上架失败：产品停售时间已过");
            }

            if (request.EndSellTime < request.StartSellTime)
            {
                return this.BadRequest("上架失败：产品停售时间小于开售时间");
            }

            if (request.FinancingSumAmount % request.UnitPrice != 0)
            {
                return this.BadRequest("上架失败：产品每份单价不能被融资总金额整除");
            }

            DailyConfig config = DailyConfigHelper.GetDailyConfig(DateTime.UtcNow.AddHours(8));

            await this.productService.HitShelvesAsync(new IssueJBYProduct
            {
                Agreement1 = request.Agreement1,
                Agreement2 = request.Agreement2,
                Args = this.BuildArgs(),
                EndSellTime = request.EndSellTime,
                FinancingSumAmount = request.FinancingSumAmount,
                IssueNo = request.IssueNo,
                IssueTime = DateTime.UtcNow.AddHours(8),
                ProductCategory = request.ProductCategory,
                ProductId = Guid.NewGuid(),
                ProductName = request.ProductName,
                ProductNo = request.ProductNo,
                StartSellTime = request.StartSellTime,
                UnitPrice = request.UnitPrice,
                ValueDateMode = request.ValueDateMode,
                Yield = config.JBYYield
            });

            return this.Ok();
        }

        /// <summary>
        ///     发行定期理财产品
        /// </summary>
        /// <param name="request">
        ///     产品上架请求
        /// </param>
        /// <response code="200">上架成功</response>
        /// <response code="400">
        ///     请求格式不合法
        ///     <br />
        ///     上架失败：产品编号已存在
        /// </response>
        /// <response code="401">认证失败</response>
        /// <response code="403">未授权</response>
        /// <response code="500"></response>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [Route("RegularProduct/Issue"), ActionParameterRequired, ActionParameterValidate(Order = 1)]
        public async Task<IHttpActionResult> RegularProductIssue(IssueProductRequest request)
        {
            bool result = await this.productInfoService.CheckProductNoExistsAsync(request.ProductNo);
            if (result)
            {
                return this.BadRequest("上架失败：产品编号已存在");
            }

            if (request.EndSellTime < DateTime.UtcNow.AddHours(8).AddMinutes(10))
            {
                return this.BadRequest("上架失败：产品停售时间已过");
            }

            if (request.EndSellTime < request.StartSellTime)
            {
                return this.BadRequest("上架失败：产品停售时间小于开售时间");
            }

            if (request.ValueDateMode == null && request.ValueDate == null)
            {
                return this.BadRequest("上架失败：产品起息时间错误");
            }

            if (request.FinancingSumAmount % request.UnitPrice != 0)
            {
                return this.BadRequest("上架失败：产品每份单价不能被融资总金额整除");
            }

            Trace.TraceInformation("RegularProductIssue. {0}", request.ToJson());

            await this.productService.HitShelvesAsync(new IssueRegularProduct
            {
                Agreement1 = request.Agreement1,
                Agreement2 = request.Agreement2,
                Args = this.BuildArgs(),
                BankName = request.BankName,
                Drawee = request.Drawee,
                DraweeInfo = request.DraweeInfo,
                EndorseImageLink = request.EndorseImageLink,
                EndSellTime = request.EndSellTime,
                EnterpriseInfo = request.EnterpriseInfo,
                EnterpriseLicense = request.EnterpriseLicense,
                EnterpriseName = request.EnterpriseName,
                FinancingSumCount = request.FinancingSumAmount,
                IssueNo = request.IssueNo,
                Period = request.Period,
                PledgeNo = request.PledgeNo,
                ProductCategory = request.ProductCategory,
                ProductId = Guid.NewGuid(),
                ProductName = request.ProductName,
                ProductNo = request.ProductNo,
                RepaymentDeadline = request.RepaymentDeadline.Date,
                RiskManagement = request.RiskManagement,
                RiskManagementInfo = request.RiskManagementInfo,
                RiskManagementMode = request.RiskManagementMode,
                SettleDate = request.SettleDate.Date,
                StartSellTime = request.StartSellTime,
                UnitPrice = request.UnitPrice,
                Usage = request.Usage,
                ValueDate = request.ValueDate,
                ValueDateMode = request.ValueDateMode,
                Yield = request.Yield
            });

            return this.Ok();
        }

        /// <summary>
        ///     定期理财产品还款通知
        /// </summary>
        /// <param name="productIdentifier">产品唯一标识</param>
        /// <response code="200"></response>
        /// <response code="400">请求格式不合法</response>
        /// <response code="401">认证失败</response>
        /// <response code="403">未授权</response>
        /// <response code="500"></response>
        [Route("RegularProduct/Repay/{productIdentifier:length(32)}")]
        public IHttpActionResult RegularProductRepay(string productIdentifier)
        {
            Guid productId = Guid.ParseExact(productIdentifier, "N");
            this.productService.RepayRegularProductAsync(productId);

            return this.Ok();
        }

        /// <summary>
        ///     用户取现到账
        /// </summary>
        /// <param name="userIdentifier">用户唯一标识</param>
        /// <param name="transcationIdentifier">交易流水唯一标识</param>
        /// <response code="200"></response>
        /// <response code="400">请求格式不合法</response>
        /// <response code="401">认证失败</response>
        /// <response code="403">未授权</response>
        /// <response code="500"></response>
        [Route("Withdrawal/{userIdentifier:length(32)}-{transcationIdentifier:length(32)}")]
        public async Task<IHttpActionResult> WithdrawalTranscationFinished(string userIdentifier, string transcationIdentifier)
        {
            Guid userId = Guid.ParseExact(userIdentifier, "N");
            Guid transcationId = Guid.ParseExact(transcationIdentifier, "N");
            await this.userService.WithdrawalResultedAsync(userId, transcationId);

            return this.Ok();
        }
    }
}