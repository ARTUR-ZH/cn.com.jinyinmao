// ***********************************************************************
// Project          : io.yuyi.jinyinmao.server
// Author           : Siqi Lu
// Created          : 2015-05-07  12:43 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-05-07  1:29 PM
// ***********************************************************************
// <copyright file="SettleAccountInfoResponse.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;
using Moe.AspNet.Models;
using Newtonsoft.Json;
using Yuyi.Jinyinmao.Domain.Dtos;

namespace Yuyi.Jinyinmao.Api.Models
{
    /// <summary>
    ///     SettleAccountInfoResponse.
    /// </summary>
    public class SettleAccountInfoResponse : IResponse
    {
        /// <summary>
        ///     账户余额，以“分”为单位
        /// </summary>
        [Required, JsonProperty("balance")]
        public int Balance { get; set; }

        /// <summary>
        ///     在途的出项金额，以“分”为单位
        /// </summary>
        [Required, JsonProperty("crediting")]
        public int Crediting { get; set; }

        /// <summary>
        ///     在途的进项金额，以“分”为单位
        /// </summary>
        [Required, JsonProperty("debiting")]
        public int Debiting { get; set; }

        /// <summary>
        ///     今天的提现次数
        /// </summary>
        [Required, JsonProperty("monthWithdrawalCount")]
        public int MonthWithdrawalCount { get; set; }

        /// <summary>
        ///     当月的提现次数
        /// </summary>
        [Required, JsonProperty("todayWithdrawalCount")]
        public int TodayWithdrawalCount { get; set; }
    }

    internal static class SettleAccountInfoEx
    {
        internal static SettleAccountInfoResponse ToResponse(this SettleAccountInfo info)
        {
            return new SettleAccountInfoResponse
            {
                Balance = info.Balance,
                Crediting = info.Crediting,
                Debiting = info.Debiting,
                MonthWithdrawalCount = info.MonthWithdrawalCount,
                TodayWithdrawalCount = info.TodayWithdrawalCount
            };
        }
    }
}