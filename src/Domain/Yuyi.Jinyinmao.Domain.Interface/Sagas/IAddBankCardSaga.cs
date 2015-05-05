// ***********************************************************************
// Project          : io.yuyi.jinyinmao.server
// Author           : Siqi Lu
// Created          : 2015-04-26  2:05 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-04-27  4:43 PM
// ***********************************************************************
// <copyright file="IAddBankCardSaga.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Threading.Tasks;
using Orleans;
using Yuyi.Jinyinmao.Domain.Dtos;

namespace Yuyi.Jinyinmao.Domain.Sagas
{
    /// <summary>
    ///     Interface IAddBankCardSaga
    /// </summary>
    public interface IAddBankCardSaga : IGrain
    {
        /// <summary>
        ///     Begins the process.
        /// </summary>
        /// <param name="initData">The initData.</param>
        /// <returns>Task.</returns>
        Task BeginProcessAsync(AddBankCardSagaInitDto initData);
    }
}