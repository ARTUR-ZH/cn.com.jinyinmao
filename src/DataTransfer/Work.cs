// ***********************************************************************
// Project          : io.yuyi.jinyinmao.server
// File             : Work.cs
// Created          : 2015-07-30  1:48 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-07-30  2:03 PM
// ***********************************************************************
// <copyright file="Work.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using DataTransfer.Models;
using Newtonsoft.Json;
using Yuyi.Jinyinmao.Domain;
using Yuyi.Jinyinmao.Domain.Dtos;

namespace DataTransfer
{
    /// <summary>
    ///     Work.
    /// </summary>
    public class Work
    {
        private static readonly List<JBYAccountTransaction> JBYAccountTransactionList = new List<JBYAccountTransaction>();
        private static readonly Guid JBYProductId = new Guid("5e35201f315e41d4b11f014d6c01feb8");
        private static readonly Dictionary<string, object> OrderArgs = new Dictionary<string, object>();
        private static readonly Dictionary<string, object> ProductArgs = new Dictionary<string, object>();

        [SuppressMessage("ReSharper", "CollectionNeverUpdated.Local")] private static readonly List<SettleAccountTransaction> SettleAccountTransactionList = new List<SettleAccountTransaction>();

        private static readonly Dictionary<string, object> UserArgs = new Dictionary<string, object>();

        //static int i = 0;
        /// <summary>
        ///     Runs this instance.
        /// </summary>
        public static async Task Run()
        {
            OrderArgs.Add("Comment", "由原订单数据迁移");
            UserArgs.Add("Comment", "由原用户数据迁移");
            ProductArgs.Add("Comment", "由原产品数据迁移");

            //get products
            await ProductTask().ContinueWith(t => UserTask());

            //ProductTransfer();
        }

        private static async Task<int> GetProductCountAsync()
        {
            using (var context = new OldDBContext())
            {
                return await Task.Run(() => context.Set<TransRegularProductState>().Count());
            }
        }

        private static async Task<Guid> GetSettleTransactionIdAsync(string orderId, string productId)
        {
            using (var context = new OldDBContext())
            {
                if (new Guid(productId) == JBYProductId)
                {
                    var datas = context.JsonJBYAccountTransaction.Where(x => x.OrderId == orderId).Select(x => x.Data).ToList();
                    var list = datas.Select(item => JsonConvert.DeserializeObject<JBYAccountTransaction>(item)).ToList();
                    return await Task.Run(() => list.Where(x => x.TradeCode == 10000).Select(x => x.TransactionId).FirstOrDefault());
                }
                else
                {
                    var datas = context.JsonSettleAccountTransaction.Where(x => x.OrderId == orderId).Select(x => x.Data).ToList();
                    var list = datas.Select(item => JsonConvert.DeserializeObject<SettleAccountTransaction>(item)).ToList();
                    return await Task.Run(() => list.Where(x => x.TradeCode == 10000).Select(x => x.TransactionId).FirstOrDefault());
                }
            }
        }

        private static async Task<int> GetUserCountAsync()
        {
            using (var context = new OldDBContext())
            {
                return await Task.Run(() => context.Set<TransUserInfo>().Count());
            }
        }

        private static async Task ProductTask()
        {
            double count = await GetProductCountAsync();
            var list = new List<Task>();
            for (int j = 0; j < Math.Ceiling(count / 10000); j++)
            {
                Task taskProduct = ProductTransferAsync(j * 10000, 10000, j);
                list.Add(taskProduct);
                Console.WriteLine(j);
            }
            Task.WaitAll(list.ToArray());
        }

        private static async Task UserTask()
        {
            double count = await GetUserCountAsync();
            List<Task> list = new List<Task>();
            for (int j = 0; j < Math.Ceiling(count / 10000); j++)
            {
                Task taskUser = UserTransferAsync(j * 10000, 10000, j);
                list.Add(taskUser);
                Console.WriteLine(j);
            }
            Task.WaitAll(list.ToArray());
        }

        #region ProductTransfer

        [SuppressMessage("ReSharper", "FunctionComplexityOverflow")]
        private static async Task ProductTransferAsync(int skipCount, int takeCount, int threadId)
        {
            int i = 0;
            using (var context = new OldDBContext())
            {
                var oldProductList = context.TransRegularProductState.OrderBy(o => o.ProductId).Skip(skipCount).Take(takeCount);

                if (!oldProductList.Any()) return;

                foreach (var oldProduct in oldProductList)
                {
                    #region product

                    //-1 condition, null
                    if (oldProduct == null) continue;

                    var agreement1 = context.Agreements.FirstOrDefault(a => a.Id == oldProduct.Agreement1);
                    var agreement2 = context.Agreements.FirstOrDefault(a => a.Id == oldProduct.Agreement2);

                    RegularProductMigrationDto product = new RegularProductMigrationDto
                    {
                        Agreement1 = agreement1 != null ? agreement1.Content : string.Empty,
                        Agreement2 = agreement2 != null ? agreement2.Content : string.Empty,
                        Args = ProductArgs,
                        BankName = oldProduct.BankName, //186 items null, ignore
                        Drawee = oldProduct.Drawee,
                        DraweeInfo = oldProduct.DraweeInfo,
                        EndorseImageLink = oldProduct.EndorseImageLink,
                        EndSellTime = oldProduct.EndSellTime,
                        EnterpriseInfo = oldProduct.EnterpriseInfo,
                        EnterpriseLicense = oldProduct.EnterpriseInfo,
                        EnterpriseName = oldProduct.EnterpriseName,
                        FinancingSumAmount = (long)(oldProduct.FinancingSumAmount * oldProduct.UnitPrice * 100),
                        IssueNo = oldProduct.IssueNo,
                        IssueTime = oldProduct.IssueTime,
                        Period = oldProduct.Period,
                        PledgeNo = oldProduct.PledgeNo,
                        ProductCategory = await Utils.GetProductCategoryAsync(oldProduct.ProductCategory, oldProduct.ProductType),
                        ProductName = Utils.GetProductName(oldProduct.ProductName),
                        ProductNo = oldProduct.ProductNo,
                        ProductId = new Guid(oldProduct.ProductId),
                        Repaid = oldProduct.Repaid,
                        RepaidTime = null,
                        RepaymentDeadline = oldProduct.RepaymentDeadline,
                        RiskManagement = oldProduct.RiskManagement,
                        RiskManagementInfo = oldProduct.RiskManagementInfo,
                        RiskManagementMode = Utils.GetRiskManagementMode(oldProduct.RiskManagementMode),
                        SettleDate = Utils.GetDate(oldProduct.SettleDate),
                        SoldOut = oldProduct.SoldOut,
                        SoldOutTime = oldProduct.SoldOutTime,
                        StartSellTime = oldProduct.StartSellTime,
                        UnitPrice = (int)(oldProduct.UnitPrice * 100),
                        Usage = oldProduct.Usage,
                        ValueDate = null,
                        ValueDateMode = 0,
                        Yield = (int)(oldProduct.Yield * 100)
                    };

                    #region orders

                    var oldOrderList = context.TransOrderInfo.Where(o => o.ProductId == oldProduct.ProductId);

                    Dictionary<Guid, OrderInfo> orders = new Dictionary<Guid, OrderInfo>();

                    foreach (var oldOrder in oldOrderList)
                    {
                        var oldUser = context.TransUserInfo.FirstOrDefault(u => u.UserId == oldOrder.UserId);

                        // TODO: oldUser null 值判断
                        if (oldUser == null) continue;

                        UserInfo userInfo = new UserInfo
                        {
                            Args = UserArgs,
                            Balance = -1,
                            BankCardsCount = oldUser.BankCardsCount.GetValueOrDefault(),
                            Cellphone = oldUser.Cellphone,
                            ClientType = oldUser.ClientType,
                            Closed = false,
                            ContractId = oldUser.ContractId,
                            Credential = Utils.GetCredential(oldUser.Credential),
                            CredentialNo = oldUser.CredentialNo,
                            Crediting = -1,
                            Debiting = 0,
                            HasSetPassword = oldUser.HasSetPassword > 0,
                            HasSetPaymentPassword = oldUser.HasSetPaymentPassword > 0,
                            InvestingInterest = -1,
                            InvestingPrincipal = -1,
                            InviteBy = oldUser.InviteBy,
                            JBYAccrualAmount = -1,
                            JBYLastInterest = -1,
                            JBYTotalAmount = -1,
                            JBYTotalInterest = -1,
                            JBYTotalPricipal = -1,
                            JBYWithdrawalableAmount = -1,
                            LoginNames = new List<string> { oldUser.LoginNames },
                            MonthWithdrawalCount = oldUser.MonthWithdrawalCount,
                            OutletCode = Utils.GetOutletCode(oldUser.OutletCode),
                            PasswordErrorCount = oldUser.PasswordErrorCount,
                            PaymentPasswordErrorCount = oldUser.PaymentPasswordErrorCount.GetValueOrDefault(),
                            RealName = oldUser.RealName,
                            RegisterTime = oldUser.RegisterTime,
                            TodayJBYWithdrawalAmount = oldUser.TodayJBYWithdrawalAmount,
                            TodayWithdrawalCount = oldUser.TodayWithdrawalCount,
                            TotalInterest = oldUser.TotalInterest,
                            TotalPrincipal = oldUser.TotalPrincipal,
                            UserId = new Guid(oldUser.UserId),
                            Verified = oldUser.Verified.GetValueOrDefault(),
                            VerifiedTime = oldUser.VerifiedTime,
                            WithdrawalableAmount = oldUser.WithdrawalableAmount
                        };

                        //购买transaction
                        Guid transactionId = Guid.NewGuid();

                        OrderInfo orderInfo = new OrderInfo
                        {
                            AccountTransactionId = transactionId,
                            Args = OrderArgs,
                            Cellphone = oldOrder.Cellphone,
                            ExtraInterest = (long)(oldOrder.ExtraInterest * 100),
                            ExtraInterestRecords = new List<ExtraInterestRecord>(),
                            ExtraYield = oldOrder.ExtraYield * 100,
                            Interest = (long)(oldOrder.Interest * 100),
                            IsRepaid = oldOrder.IsRepaid,
                            OrderId = new Guid(oldOrder.OrderId),
                            OrderNo = oldOrder.OrderNo,
                            OrderTime = oldOrder.OrderTime,
                            Principal = (long)(oldOrder.Principal * 100),
                            ProductCategory = product.ProductCategory,
                            ProductId = product.ProductId,
                            ProductSnapshot = new RegularProductInfo
                            {
                                Args = product.Args,
                                BankName = product.BankName,
                                Drawee = product.Drawee,
                                DraweeInfo = product.DraweeInfo,
                                EndorseImageLink = product.EndorseImageLink,
                                EndSellTime = product.EndSellTime,
                                EnterpriseInfo = product.EnterpriseInfo,
                                EnterpriseLicense = product.EnterpriseInfo,
                                EnterpriseName = product.EnterpriseName,
                                FinancingSumAmount = product.FinancingSumAmount,
                                IssueNo = product.IssueNo,
                                IssueTime = product.IssueTime,
                                Period = product.Period,
                                PledgeNo = product.PledgeNo,
                                ProductCategory = product.ProductCategory,
                                ProductName = product.ProductName,
                                ProductNo = product.ProductNo,
                                ProductId = product.ProductId,
                                Repaid = product.Repaid,
                                RepaymentDeadline = product.RepaymentDeadline,
                                RiskManagement = product.RiskManagement,
                                RiskManagementInfo = product.RiskManagementInfo,
                                RiskManagementMode = product.RiskManagementMode,
                                SettleDate = product.SettleDate,
                                SoldOut = product.SoldOut,
                                SoldOutTime = product.SoldOutTime,
                                StartSellTime = product.StartSellTime,
                                UnitPrice = product.UnitPrice,
                                Usage = product.Usage,
                                ValueDateMode = 0,
                                Yield = product.Yield
                            },
                            RepaidTime = null,
                            ResultCode = 10000,
                            ResultTime = oldOrder.ResultTime,
                            SettleDate = Utils.GetDate(oldOrder.SettleDate),
                            TransDesc = "充值成功，购买理财产品",
                            UserId = new Guid(oldOrder.UserId),
                            UserInfo = userInfo,
                            ValueDate = Utils.GetDate(oldOrder.ValueDate),
                            Yield = (int)(oldOrder.Yield * 100)
                        };
                        if (product.ProductId == JBYProductId)
                        {
                            await GenerateJBYTransactionAsync(new List<TranscationState>
                            {
                                TranscationState.ChongZhi, TranscationState.ToJBY, TranscationState.RecieveByQianBao,
                                TranscationState.ToQianBao, TranscationState.RecieveByJBY, TranscationState.QuXian
                            }, orderInfo, userInfo);
                        }
                        else
                        {
                            await GenerateRegularTransactionAsync(new List<TranscationState>
                            {
                                TranscationState.ChongZhi, TranscationState.GouMai,
                                TranscationState.BenJin, TranscationState.LiXi, TranscationState.QuXian
                            }, orderInfo, userInfo);
                        }
                        orders.Add(orderInfo.OrderId, orderInfo);
                    }

                    #endregion orders

                    product.Orders = orders;
                    context.JsonProduct.Add(new JsonProduct { Data = JsonConvert.SerializeObject(product) });
                    Console.WriteLine("product transfer start,threadId: " + threadId + ", count" + ++i);

                    #endregion product
                }
                await context.SaveChangesAsync();
            }
        }

        #endregion ProductTransfer

        #region UserTransfer

        [SuppressMessage("ReSharper", "LoopCanBePartlyConvertedToQuery")]
        private static async Task UserTransferAsync(int skipCount, int takeCount, int threadId)
        {
            int i = 0;
            using (var context = new OldDBContext())
            {
                var transUserInfos = context.TransUserInfo.OrderBy(x => x.UserId).Skip(skipCount).Take(takeCount);
                foreach (var transUserInfo in transUserInfos)
                {
                    if (transUserInfo == null) continue;

                    #region userinfo

                    UserInfo userInfo = new UserInfo
                    {
                        Args = UserArgs,
                        Balance = -1,
                        BankCardsCount = transUserInfo.BankCardsCount.GetValueOrDefault(),
                        Cellphone = transUserInfo.Cellphone,
                        ClientType = transUserInfo.ClientType,
                        Closed = false,
                        ContractId = transUserInfo.ContractId,
                        Credential = Utils.GetCredential(transUserInfo.Credential),
                        CredentialNo = !string.IsNullOrWhiteSpace(transUserInfo.CredentialNo) ? transUserInfo.CredentialNo : string.Empty,
                        Crediting = -1,
                        Debiting = 0,
                        HasSetPassword = transUserInfo.HasSetPassword.GetValueOrDefault() > 0,
                        HasSetPaymentPassword = transUserInfo.HasSetPaymentPassword.GetValueOrDefault() > 0,
                        InvestingInterest = -1,
                        InvestingPrincipal = -1,
                        InviteBy = !string.IsNullOrWhiteSpace(transUserInfo.InviteBy) ? transUserInfo.InviteBy : string.Empty,
                        JBYAccrualAmount = -1,
                        JBYLastInterest = -1,
                        JBYTotalAmount = -1,
                        JBYTotalInterest = -1,
                        JBYTotalPricipal = -1,
                        JBYWithdrawalableAmount = -1,
                        LoginNames = new List<string> { transUserInfo.LoginNames },
                        MonthWithdrawalCount = transUserInfo.MonthWithdrawalCount,
                        OutletCode = Utils.GetOutletCode(transUserInfo.OutletCode),
                        PasswordErrorCount = transUserInfo.PasswordErrorCount,
                        PaymentPasswordErrorCount = transUserInfo.PaymentPasswordErrorCount.GetValueOrDefault(),
                        RealName = string.IsNullOrWhiteSpace(transUserInfo.RealName) ? string.Empty : transUserInfo.RealName,
                        RegisterTime = transUserInfo.RegisterTime,
                        TodayJBYWithdrawalAmount = transUserInfo.TodayJBYWithdrawalAmount,
                        TodayWithdrawalCount = transUserInfo.TodayWithdrawalCount,
                        TotalInterest = transUserInfo.TotalInterest,
                        TotalPrincipal = transUserInfo.TotalPrincipal,
                        UserId = new Guid(transUserInfo.UserId),
                        Verified = transUserInfo.Verified.GetValueOrDefault(),
                        VerifiedTime = transUserInfo.VerifiedTime,
                        WithdrawalableAmount = transUserInfo.WithdrawalableAmount
                    };

                    #endregion userinfo

                    #region Order

                    var listOrder = new List<Order>();

                    foreach (var x in context.TransOrderInfo.Where(o => userInfo.Verified && o.UserId == transUserInfo.UserId))
                    {
                        var accountTransactionId = await GetSettleTransactionIdAsync(x.OrderId, x.ProductId);
                        listOrder.Add(new Order
                        {
                            AccountTransactionId = accountTransactionId,
                            Args = OrderArgs,
                            Cellphone = x.Cellphone,
                            ExtraInterest = (long)x.ExtraInterest,
                            ExtraInterestRecords = new List<ExtraInterestRecord>(),
                            ExtraYield = (x.ExtraYield * 100),
                            Interest = (long)x.Interest,
                            IsRepaid = x.IsRepaid,
                            OrderId = new Guid(x.OrderId),
                            OrderNo = x.OrderNo,
                            OrderTime = x.OrderTime,
                            Principal = (long)(x.Principal * 100),
                            ProductCategory = await Utils.GetProductCategoryAsync(x.ProductCategory, x.ProductType),
                            ProductId = new Guid(x.ProductId),
                            ProductSnapshot = null,
                            RepaidTime = null,
                            ResultCode = 10000,
                            SettleDate = Utils.GetDate(x.SettleDate),
                            TransDesc = "充值成功，购买理财产品",
                            UserId = new Guid(x.UserId),
                            UserInfo = userInfo,
                            ValueDate = Utils.GetDate(x.ValueDate),
                            Yield = (int)(x.Yield * 100)
                        });
                    }

                    var orders = listOrder.ToDictionary(x => x.OrderId);

                    #endregion Order

                    var user = new UserMigrationDto
                    {
                        Args = UserArgs,
                        BankCards = await Utils.GetBankCards(transUserInfo.UserId),
                        Cellphone = transUserInfo.Cellphone,
                        ClientType = transUserInfo.ClientType,
                        Closed = false,
                        ContractId = transUserInfo.ContractId,
                        Credential = userInfo.Credential,
                        CredentialNo = transUserInfo.CredentialNo,
                        EncryptedPassword = transUserInfo.EncryptedPassword,
                        EncryptedPaymentPassword = string.IsNullOrWhiteSpace(transUserInfo.EncryptedPaymentPassword) ? string.Empty : transUserInfo.EncryptedPaymentPassword,
                        InviteBy = userInfo.InviteBy,
                        JBYAccount = await GetJBYAccountTransactionAsync(transUserInfo.UserId),
                        LoginNames = userInfo.LoginNames,
                        Orders = orders,
                        OutletCode = transUserInfo.OutletCode,
                        PaymentSalt = string.IsNullOrEmpty(transUserInfo.PaymentSalt) ? string.Empty : transUserInfo.PaymentSalt,
                        RealName = userInfo.RealName,
                        RegisterTime = transUserInfo.RegisterTime,
                        Salt = transUserInfo.Salt,
                        SettleAccount = await GetSettleAccountTransactionAsync(transUserInfo.UserId),
                        UserId = userInfo.UserId,
                        Verified = userInfo.Verified,
                        VerifiedTime = transUserInfo.VerifiedTime
                    };

                    string json = JsonConvert.SerializeObject(user);
                    context.JsonUser.Add(new JsonUser { Data = json });
                    Console.WriteLine("user transfer start,threadId: " + threadId + ", count" + ++i);
                    //Console.WriteLine(json);
                }
                await context.SaveChangesAsync();
            }
        }

        #endregion UserTransfer

        #region 生成流水

        private static async Task GenerateJBYTransactionAsync(IEnumerable<TranscationState> listType, OrderInfo order, UserInfo user)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "Comment", "由原流水数据迁移" },
                { "IsRepaid", order.IsRepaid }
            };

            using (var context = new OldDBContext())
            {
                var id = new Guid();
                foreach (var type in listType)
                {
                    var oldTransaction = context.TransSettleAccountTransaction.FirstOrDefault(t => t.OrderId == order.OrderId.ToString().Replace("-", ""));

                    // TODO: oldTransaction null 值判断
                    if (oldTransaction == null) return;
                    //pre deal
                    JBYAccountTransaction transaction = new JBYAccountTransaction
                    {
                        Amount = order.Principal * 100,
                        ProductId = JBYProductId,
                        Args = dic,
                        //BankCardNo = oldTransaction.BankCardNo,
                        //ChannelCode
                        //OrderId = order.OrderId,
                        PredeterminedResultDate = null,
                        ResultCode = 1,
                        ResultTime = oldTransaction.CallbackTime ?? order.OrderTime,
                        //SequenceNo = order.OrderNo,
                        //SettleAccountTransactionId = null,
                        //Trade
                        //TradeCode
                        //TransactionId
                        TransactionTime = order.OrderTime,
                        //TransDesc
                        UserId = order.UserId,
                        UserInfo = user
                    };

                    //suf deal
                    switch (type)
                    {
                        case TranscationState.ChongZhi:

                            transaction.Trade = Trade.Debit;
                            transaction.TradeCode = 1005051001;
                            transaction.TransactionId = Guid.NewGuid();
                            transaction.TransDesc = "个人钱包账户充值";
                            id = transaction.TransactionId;
                            //transaction.OrderId = Guid.Empty;

                            break;

                        case TranscationState.ToJBY:
                            transaction.Trade = Trade.Credit;
                            transaction.TradeCode = 1005012003;
                            transaction.TransactionId = order.AccountTransactionId;
                            transaction.TransDesc = "钱包金额转为金包银金额";
                            transaction.SettleAccountTransactionId = id;
                            break;

                        case TranscationState.RecieveByQianBao:
                            transaction.Trade = Trade.Debit;
                            transaction.TradeCode = 2001051102;
                            transaction.TransactionId = Guid.NewGuid();
                            transaction.TransDesc = "金包银金额收到钱包转入金额";
                            break;

                        case TranscationState.ToQianBao:
                            transaction.Trade = Trade.Credit;
                            transaction.TradeCode = 2001012002;
                            transaction.TransactionId = Guid.NewGuid();
                            transaction.TransDesc = "金包银金额转为钱包金额";
                            break;

                        case TranscationState.RecieveByJBY:
                            transaction.Trade = Trade.Debit;
                            transaction.TradeCode = 1005011103;
                            transaction.TransactionId = Guid.NewGuid();
                            transaction.TransDesc = "钱包收到金包银转入金额";
                            break;

                        case TranscationState.QuXian:
                            transaction.Trade = Trade.Credit;
                            transaction.TradeCode = 1005052001;
                            transaction.TransactionId = Guid.NewGuid();
                            transaction.TransDesc = "个人钱包账户取现";
                            break;
                    }
                    context.JsonJBYAccountTransaction.Add(
                        new JsonJBYAccountTransaction { OrderId = order.OrderId.ToString(), UserId = user.UserId.ToString(), Data = JsonConvert.SerializeObject(transaction) });
                }
                await context.SaveChangesAsync();
            }
        }

        private static async Task GenerateRegularTransactionAsync(IEnumerable<TranscationState> listType, OrderInfo order, UserInfo user)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "Comment", "由原流水数据迁移" },
                { "IsRepaid", order.IsRepaid }
            };

            using (var context = new OldDBContext())
            {
                foreach (var type in listType)
                {
                    var oldTransaction = context.TransSettleAccountTransaction.FirstOrDefault(t => t.OrderId == order.OrderId.ToString().Replace("-", ""));
                    if (oldTransaction == null) return;
                    //pre deal
                    SettleAccountTransaction transaction = new SettleAccountTransaction
                    {
                        Amount = order.Principal * 100,
                        Args = dic,
                        BankCardNo = oldTransaction.BankCardNo,
                        //ChannelCode
                        OrderId = order.OrderId,
                        ResultCode = 1,
                        ResultTime = oldTransaction.CallbackTime ?? order.OrderTime,
                        SequenceNo = order.OrderNo,
                        //Trade
                        //TradeCode
                        //TransactionId
                        TransactionTime = order.OrderTime,
                        //TransDesc
                        UserId = order.UserId,
                        UserInfo = user
                    };

                    //suf deal
                    switch (type)
                    {
                        case TranscationState.ChongZhi:
                            transaction.ChannelCode = 10010;
                            transaction.Trade = Trade.Debit;
                            transaction.TradeCode = 1005051001;
                            transaction.TransactionId = Guid.NewGuid();
                            transaction.TransDesc = "个人钱包账户充值";
                            //transaction.OrderId = Guid.Empty;

                            break;

                        case TranscationState.GouMai:
                            transaction.ChannelCode = 10000;
                            transaction.Trade = Trade.Debit;
                            transaction.TradeCode = 1005012004;
                            transaction.TransactionId = order.AccountTransactionId;
                            transaction.TransDesc = "购买银票或者商票产品(银行专区)";
                            transaction.BankCardNo = string.Empty;

                            break;

                        case TranscationState.BenJin:
                            transaction.ChannelCode = 10000;
                            transaction.Trade = Trade.Credit;
                            transaction.TradeCode = 1005011104;
                            transaction.TransactionId = Guid.NewGuid();
                            transaction.TransDesc = "钱包收到银票或者商票产品返还本金(银行专区)";

                            break;

                        case TranscationState.LiXi:
                            transaction.ChannelCode = 10000;
                            transaction.Trade = Trade.Credit;
                            transaction.TradeCode = 1005011105;
                            transaction.TransactionId = Guid.NewGuid();
                            transaction.TransDesc = "钱包收到银票或者商票产品结算利息(银行专区)";

                            break;

                        case TranscationState.QuXian:
                            transaction.ChannelCode = 10010;
                            transaction.Trade = Trade.Credit;
                            transaction.TradeCode = 1005052001;
                            transaction.TransactionId = Guid.NewGuid();
                            transaction.TransDesc = "个人钱包账户取现";

                            break;

                        default:
                            transaction.ChannelCode = -1;

                            break;
                    }
                    context.JsonSettleAccountTransaction.Add(
                        new JsonSettleAccountTransaction { OrderId = order.OrderId.ToString(), UserId = user.UserId.ToString(), Data = JsonConvert.SerializeObject(transaction) });
                }
                await context.SaveChangesAsync();
            }
        }

        #endregion 生成流水

        #region 通过UserId查询流水

        /// <summary>
        ///     通过UserId查询金包银流水
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static async Task<Dictionary<Guid, JBYAccountTransaction>> GetJBYAccountTransactionAsync(string userId)
        {
            using (var context = new OldDBContext())
            {
                var list = context.JsonJBYAccountTransaction.Where(x => x.UserId == userId).ToList();
                return await Task.Run(() => list.Select(item => JsonConvert.DeserializeObject<JBYAccountTransaction>(item.Data)).ToDictionary(x => x.TransactionId));
            }
        }

        /// <summary>
        ///     通过UserId查询流水
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static async Task<Dictionary<Guid, SettleAccountTransaction>> GetSettleAccountTransactionAsync(string userId)
        {
            using (var context = new OldDBContext())
            {
                var list = context.JsonSettleAccountTransaction.Where(x => x.UserId == userId).ToList();
                return await Task.Run(() => list.Select(item => JsonConvert.DeserializeObject<SettleAccountTransaction>(item.Data)).ToDictionary(x => x.TransactionId));
            }
        }

        #endregion 通过UserId查询流水
    }
}