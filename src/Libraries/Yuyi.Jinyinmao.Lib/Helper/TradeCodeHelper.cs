// ***********************************************************************
// Project          : io.yuyi.jinyinmao.server
// Author           : Siqi Lu
// Created          : 2015-05-03  6:22 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-05-04  1:09 AM
// ***********************************************************************
// <copyright file="TradeCodeHelper.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

namespace Yuyi.Jinyinmao.Packages.Helper
{
    /// <summary>
    ///     TradeCodeHelper.
    /// </summary>
    public static class TradeCodeHelper
    {
        /// <summary>
        /// Gets the t C1005012004.
        /// </summary>
        /// <value>The t C1005012004.</value>
        public static int TC1005012004
        {
            get { return 1005012004; }
        }

        /// <summary>
        /// Gets the t C1005022004.
        /// </summary>
        /// <value>The t C1005022004.</value>
        public static int TC1005022004
        {
            get { return 1005022004; }
        }

        /// <summary>
        ///     Gets the trade code 1005051001.
        /// </summary>
        /// <value>1005051001.</value>
        public static int TC1005051001
        {
            get { return 1005051001; }
        }

        /// <summary>
        /// Gets the t C1005052001.
        /// </summary>
        /// <value>The t C1005052001.</value>
        public static int TC1005052001
        {
            get { return 1005052001; }
        }

        /// <summary>
        ///     Determines whether the specified trade code is crebit.
        /// </summary>
        /// <param name="tradeCode">The trade code.</param>
        /// <returns><c>true</c> if the specified trade code is crebit; otherwise, <c>false</c>.</returns>
        public static bool IsCrebit(int tradeCode)
        {
            return tradeCode.ToString()[6] == '2';
        }

        /// <summary>
        ///     Determines whether the specified trade code is debit.
        /// </summary>
        /// <param name="tradeCode">The trade code.</param>
        /// <returns><c>true</c> if the specified trade code is debit; otherwise, <c>false</c>.</returns>
        public static bool IsDebit(int tradeCode)
        {
            return tradeCode.ToString()[6] == '1';
        }
    }
}