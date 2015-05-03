﻿// ***********************************************************************
// Project          : io.yuyi.jinyinmao.server
// Author           : Siqi Lu
// Created          : 2015-04-11  10:35 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-05-03  6:06 PM
// ***********************************************************************
// <copyright file="UserInfo.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using Orleans.Concurrency;

namespace Yuyi.Jinyinmao.Domain.Dtos
{
    /// <summary>
    ///     Class UserInfo.
    /// </summary>
    [Immutable]
    public class UserInfo
    {
        /// <summary>
        ///     默认银行卡号
        /// </summary>
        public string BankCardNo { get; set; }

        /// <summary>
        ///     银行卡数量
        /// </summary>
        public int BankCardsCount { get; set; }

        /// <summary>
        ///     默认银行卡银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        ///     用户手机号码
        /// </summary>
        public string Cellphone { get; set; }

        /// <summary>
        ///     活动编号(推广相关)
        /// </summary>
        public long ContractId { get; set; }

        /// <summary>
        ///     证件类型
        /// </summary>
        public Credential Credential { get; set; }

        /// <summary>
        ///     证件编号
        /// </summary>
        public string CredentialNo { get; set; }

        /// <summary>
        ///     是否已经设置支付密码
        /// </summary>
        public bool HaSetPaymentPassword { get; set; }

        /// <summary>
        ///     是否已经设置登录密码
        /// </summary>
        public bool HasSetPassword { get; set; }

        /// <summary>
        ///     邀请人
        /// </summary>
        public string InviteBy { get; set; }

        /// <summary>
        ///     登录名
        /// </summary>
        public List<string> LoginNames { get; set; }

        /// <summary>
        ///     真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        ///     注册时间
        /// </summary>
        public DateTime RegisterTime { get; set; }

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public Guid UserId { get; set; }

        /// <summary>
        ///     是否通过实名认证
        /// </summary>
        public bool Verified { get; set; }

        /// <summary>
        ///     实名认证时间
        /// </summary>
        public DateTime? VerifiedTime { get; set; }
    }
}