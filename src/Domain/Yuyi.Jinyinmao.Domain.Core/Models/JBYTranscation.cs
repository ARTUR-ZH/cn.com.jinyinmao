﻿// ***********************************************************************
// Project          : io.yuyi.jinyinmao.server
// Author           : Siqi Lu
// Created          : 2015-04-29  5:29 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-04-29  5:41 PM
// ***********************************************************************
// <copyright file="JBYTranscation.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;

namespace Yuyi.Jinyinmao.Domain.Models
{
    /// <summary>
    ///     JBYTranscation.
    /// </summary>
    public class JBYTranscation
    {
        /// <summary>
        ///     Gets or sets the account transcation identifier.
        /// </summary>
        /// <value>The account transcation identifier.</value>
        public string AccountTranscationIdentifier { get; set; }

        /// <summary>
        ///     Gets or sets the agreements information.
        /// </summary>
        /// <value>The agreements information.</value>
        public string AgreementsInfo { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public string Amount { get; set; }

        /// <summary>
        ///     Gets or sets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public string Args { get; set; }

        /// <summary>
        ///     Gets or sets the cellphone.
        /// </summary>
        /// <value>The cellphone.</value>
        public string Cellphone { get; set; }

        /// <summary>
        ///     Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        public string Info { get; set; }

        /// <summary>
        ///     Gets or sets the result code.
        /// </summary>
        /// <value>The result code.</value>
        public int ResultCode { get; set; }

        /// <summary>
        ///     Gets or sets the result time.
        /// </summary>
        /// <value>The result time.</value>
        public Nullable<DateTime> ResultTime { get; set; }

        /// <summary>
        ///     Gets or sets the trade code.
        /// </summary>
        /// <value>The trade code.</value>
        public int TradeCode { get; set; }

        /// <summary>
        ///     Gets or sets the transcation identifier.
        /// </summary>
        /// <value>The transcation identifier.</value>
        public string TranscationIdentifier { get; set; }

        /// <summary>
        ///     Gets or sets the transcation time.
        /// </summary>
        /// <value>The transcation time.</value>
        public DateTime TranscationTime { get; set; }

        /// <summary>
        ///     Gets or sets the trans desc.
        /// </summary>
        /// <value>The trans desc.</value>
        public string TransDesc { get; set; }

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserIdentifier { get; set; }

        /// <summary>
        ///     Gets or sets the user information.
        /// </summary>
        /// <value>The user information.</value>
        public string UserInfo { get; set; }
    }
}
