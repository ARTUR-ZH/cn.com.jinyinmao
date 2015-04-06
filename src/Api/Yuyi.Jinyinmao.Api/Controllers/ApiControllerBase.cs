﻿// ***********************************************************************
// Project          : io.yuyi.jinyinmao.server
// Author           : Siqi Lu
// Created          : 2015-04-06  11:05 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-04-06  11:32 PM
// ***********************************************************************
// <copyright file="ApiControllerBase.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using System.Web.Http;

namespace Yuyi.Jinyinmao.Api.Controllers
{
    /// <summary>
    ///     Class ApiControllerBase.
    /// </summary>
    public class ApiControllerBase : ApiController
    {
        /// <summary>
        ///     The current user
        /// </summary>
        private CurrentUser currentUser;

        /// <summary>
        ///     Gets the current user.
        /// </summary>
        /// <value>The current user.</value>
        protected CurrentUser CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    currentUser = this.GetCurrentUser();
                }

                return this.currentUser.Id.HasValue ? this.currentUser : null;
            }
        }

        /// <summary>
        ///     Gets the current user.
        /// </summary>
        /// <returns>CurrentUser.</returns>
        [SuppressMessage("ReSharper", "MergeSequentialChecks")]
        protected CurrentUser GetCurrentUser()
        {
            IPrincipal principal = this.User;

            if (principal == null || principal.Identity == null || !principal.Identity.IsAuthenticated)
            {
                return new CurrentUser();
            }

            string token = principal.Identity.Name;
            string[] tokens = token.Split(',');

            if (String.IsNullOrWhiteSpace(token) || tokens.Length != 3)
            {
                return new CurrentUser();
            }

            DateTime expiryTime = DateTime.MinValue;
            long expiry;
            if (long.TryParse(tokens[2], out expiry))
            {
                expiryTime = DateTime.FromBinary(expiry);
            }

            return new CurrentUser
            {
                Id = new Guid(tokens[0]),
                Cellphone = tokens[1],
                ExpiryTime = expiryTime
            };
        }

        /// <summary>
        ///     Creates an <see cref="T:System.Web.Http.IHttpActionResult" /> (200 OK).
        /// </summary>
        /// <returns>An <see cref="T:System.Web.Http.IHttpActionResult" /> (200 OK).</returns>
        protected new IHttpActionResult Ok()
        {
            return base.Ok(new object());
        }
    }

    /// <summary>
    ///     Class CurrentUser.
    /// </summary>
    public class CurrentUser
    {
        /// <summary>
        ///     Gets or sets the cellphone.
        /// </summary>
        /// <value>The cellphone.</value>
        public string Cellphone { get; set; }

        /// <summary>
        ///     Gets or sets the expiry time.
        /// </summary>
        /// <value>The expiry time.</value>
        public DateTime ExpiryTime { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid? Id { get; set; }
    }
}
