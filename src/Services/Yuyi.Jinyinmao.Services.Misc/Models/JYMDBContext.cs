// ***********************************************************************
// Project          : io.yuyi.jinyinmao.server
// Author           : Siqi Lu
// Created          : 2015-05-04  11:50 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-05-26  10:34 PM
// ***********************************************************************
// <copyright file="JYMDBContext.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Data.Entity;
using Microsoft.Azure;
using Moe.EntityFramework;
using Yuyi.Jinyinmao.Service.Models.Mapping;

namespace Yuyi.Jinyinmao.Service.Models
{
    /// <summary>
    ///     JYMDBContext.
    /// </summary>
    public class JymdbContext : DbContextBase
    {
        /// <summary>
        ///     The connectiong string
        /// </summary>
        private static readonly string ConnectiongString;

        /// <summary>
        ///     Initializes static members of the <see cref="JymdbContext" /> class.
        /// </summary>
        static JymdbContext()
        {
            Database.SetInitializer<JymdbContext>(null);
            ConnectiongString = CloudConfigurationManager.GetSetting("JYMDBContextConnectionString");
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JymdbContext" /> class.
        /// </summary>
        public JymdbContext()
            : base(ConnectiongString)
        {
        }

        /// <summary>
        ///     Gets or sets the veri codes.
        /// </summary>
        /// <value>The veri codes.</value>
        public DbSet<VeriCode> VeriCodes { get; set; }

        /// <summary>
        ///     Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder) => modelBuilder.Configurations.Add(new VeriCodeMap());
    }
}