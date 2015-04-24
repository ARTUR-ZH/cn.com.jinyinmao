﻿// ***********************************************************************
// Project          : io.yuyi.jinyinmao.server
// Author           : Siqi Lu
// Created          : 2015-04-25  3:23 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-04-25  3:23 AM
// ***********************************************************************
// <copyright file="LoginPasswordReset.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;

namespace Yuyi.Jinyinmao.Domain.Events
{
    /// <summary>
    ///     LoginPasswordReset.
    /// </summary>
    public class LoginPasswordReset : IEvent
    {
        #region IEvent Members

        /// <summary>
        ///     Gets or sets the event identifier.
        /// </summary>
        /// <value>The event identifier.</value>
        public Guid EventId { get; set; }

        /// <summary>
        ///     Gets or sets the source identifier.
        /// </summary>
        /// <value>The source identifier.</value>
        public string SourceId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the source.
        /// </summary>
        /// <value>The type of the source.</value>
        public string SourceType { get; set; }

        #endregion IEvent Members
    }
}