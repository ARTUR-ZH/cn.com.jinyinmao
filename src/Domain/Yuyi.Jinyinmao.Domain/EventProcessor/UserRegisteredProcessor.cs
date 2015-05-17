// ***********************************************************************
// Project          : io.yuyi.jinyinmao.server
// Author           : Siqi Lu
// Created          : 2015-04-26  11:39 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-05-18  12:27 AM
// ***********************************************************************
// <copyright file="UserRegisteredProcessor.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Moe.Lib;
using Yuyi.Jinyinmao.Domain.Models;
using Yuyi.Jinyinmao.Packages.Helper;

namespace Yuyi.Jinyinmao.Domain.Events
{
    /// <summary>
    ///     UserRegisteredProcessor.
    /// </summary>
    public class UserRegisteredProcessor : EventProcessor<UserRegistered>, IUserRegisteredProcessor
    {
        #region IUserRegisteredProcessor Members

        /// <summary>
        ///     Processes the event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        public override async Task ProcessEventAsync(UserRegistered @event)
        {
            await this.ProcessingEventAsync(@event, async e =>
            {
                string message = Resources.Sms_SignUpSuccessful;
                if (!await this.SmsService.SendMessageAsync(e.Cellphone, message))
                {
                    throw new ApplicationException("Sms sending failed. {0}-{1}".FormatWith(e.Cellphone, message));
                }
            });

            await this.ProcessingEventAsync(@event, async e =>
            {
                ICellphone cellphone = CellphoneFactory.GetGrain(GrainTypeHelper.GetGrainTypeLongKey(GrainType.Cellphone, e.Cellphone));
                await cellphone.Register();
            });

            await this.ProcessingEventAsync(@event, async e =>
            {
                Models.User user = new Models.User
                {
                    Args = e.Args.ToJson(),
                    Cellphone = e.Cellphone,
                    ClientType = e.ClientType,
                    Closed = false,
                    ContractId = e.ContractId,
                    Credential = (int)Credential.None,
                    CredentialNo = string.Empty,
                    Info = JsonHelper.NewDictionary,
                    InviteBy = e.InviteBy,
                    LoginNames = e.LoginNames.Join(","),
                    OutletCode = e.OutletCode,
                    RealName = string.Empty,
                    RegisterTime = e.RegisterTime,
                    UserIdentifier = e.UserId.ToGuidString(),
                    Verified = false,
                    VerifiedTime = null
                };

                using (JYMDBContext db = new JYMDBContext())
                {
                    if (!await db.Users.AnyAsync(u => u.UserIdentifier == user.UserIdentifier))
                    {
                        db.Users.Add(user);
                        await db.SaveChangesAsync();
                    }
                }
            });

            await base.ProcessEventAsync(@event);
        }

        #endregion IUserRegisteredProcessor Members
    }
}