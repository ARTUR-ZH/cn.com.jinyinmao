﻿// ***********************************************************************
// Project          : io.yuyi.jinyinmao.server
// Author           : Siqi Lu
// Created          : 2015-04-26  6:15 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-04-26  10:27 PM
// ***********************************************************************
// <copyright file="TransDetail.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

namespace Yuyi.Jinyinmao.Service
{
    /// <summary>
    ///     TransDetail.
    /// </summary>
    public class TransDetail
    {
        /// <summary>
        ///     开户城市
        /// </summary>
        public string ACC_CITY { get; set; }

        /// <summary>
        ///     账户名
        /// </summary>
        public string ACC_NAME { get; set; }

        /// <summary>
        ///     账号 19位借记卡号
        /// </summary>
        public string ACC_NO { get; set; }

        /// <summary>
        ///     开户省份
        /// </summary>
        public string ACC_PROVINCE { get; set; }

        /// <summary>
        ///     金额（即认证费，由金银猫自己生成，可以是动态的每次都不一样，也可以是写死的每次都一样）
        /// </summary>
        public string AMOUNT { get; set; }

        /// <summary>
        ///     支行名称（即银行名称）
        /// </summary>
        public string BANK_NAME { get; set; }

        /// <summary>
        ///     币值
        /// </summary>
        public string CNY
        {
            get { return "CNY"; }
        }

        /// <summary>
        ///     开户证件号
        /// </summary>
        public string ID_NO { get; set; }

        /// <summary>
        ///     开户证件类型
        /// </summary>
        public string ID_TYPE { get; set; }

        /// <summary>
        ///     产品编号
        /// </summary>
        public string MER_ORDER_NO { get; set; }

        /// <summary>
        ///     回调URL
        /// </summary>
        public string MERCHANT_URL { get; set; }

        /// <summary>
        ///     手机号
        /// </summary>
        public string MOBILE_NO { get; set; }

        /// <summary>
        ///     “SN 流水号”须保证唯一性,总长6——14位, 有字母要用大写
        /// </summary>
        public string SN { get; set; }

        /// <summary>
        ///     交易描述
        /// </summary>
        public string TRANS_DESC
        {
            get { return "金银猫快捷支付认证开通扣款 此费用稍后将返还到您的认证卡里 金银猫客服 4008556333"; }
        }

        /// <summary>
        ///     用户uuid
        /// </summary>
        public string USER_UUID { get; set; }
    }
}