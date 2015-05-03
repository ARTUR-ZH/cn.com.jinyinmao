//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998

namespace Yuyi.Jinyinmao.Domain
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Orleans.CodeGeneration;
    using Orleans;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [SerializableAttribute()]
    [global::Orleans.CodeGeneration.GrainStateAttribute("Yuyi.Jinyinmao.Domain.Yuyi.Jinyinmao.Domain.Cellphone")]
    public class CellphoneState : global::Orleans.CodeGeneration.GrainState, ICellphoneState
    {
        

            public String @Cellphone { get; set; }

            public Boolean @Registered { get; set; }

            public Nullable<Guid> @UserId { get; set; }

            public override void SetAll(System.Collections.Generic.IDictionary<string,object> values)
            {   
                object value;
                if (values == null) { InitStateFields(); return; }
                if (values.TryGetValue("Cellphone", out value)) @Cellphone = (String) value;
                if (values.TryGetValue("Registered", out value)) @Registered = (Boolean) value;
                if (values.TryGetValue("UserId", out value)) @UserId = (Nullable<Guid>) value;
            }

            public override System.String ToString()
            {
                return System.String.Format("CellphoneState( Cellphone={0} Registered={1} UserId={2} )", @Cellphone, @Registered, @UserId);
            }
        
        public CellphoneState() : 
                base("Yuyi.Jinyinmao.Domain.Cellphone")
        {
            this.InitStateFields();
        }
        
        public override System.Collections.Generic.IDictionary<string, object> AsDictionary()
        {
            System.Collections.Generic.Dictionary<string, object> result = new System.Collections.Generic.Dictionary<string, object>();
            result["Cellphone"] = this.Cellphone;
            result["Registered"] = this.Registered;
            result["UserId"] = this.UserId;
            return result;
        }
        
        private void InitStateFields()
        {
            this.Cellphone = default(String);
            this.Registered = default(Boolean);
            this.UserId = default(Nullable<Guid>);
        }
        
        [global::Orleans.CodeGeneration.CopierMethodAttribute()]
        public static object _Copier(object original)
        {
            CellphoneState input = ((CellphoneState)(original));
            return input.DeepCopy();
        }
        
        [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
        public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
        {
            CellphoneState input = ((CellphoneState)(original));
            input.SerializeTo(stream);
        }
        
        [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
        public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            CellphoneState result = new CellphoneState();
            result.DeserializeFrom(stream);
            return result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [SerializableAttribute()]
    [global::Orleans.CodeGeneration.GrainStateAttribute("Yuyi.Jinyinmao.Domain.Yuyi.Jinyinmao.Domain.RegularProduct")]
    public class RegularProductState : global::Orleans.CodeGeneration.GrainState, IRegularProductState
    {
        

            public ICommandStore @CommandStore { get; set; }

            public IEventStore @EventStore { get; set; }

            public Guid @Id { get; set; }

            public String @Agreement1 { get; set; }

            public String @Agreement2 { get; set; }

            public String @Args { get; set; }

            public String @BankName { get; set; }

            public String @Drawee { get; set; }

            public String @DraweeInfo { get; set; }

            public String @EndorseImageLink { get; set; }

            public DateTime @EndSellTime { get; set; }

            public String @EnterpriseInfo { get; set; }

            public String @EnterpriseLicense { get; set; }

            public String @EnterpriseName { get; set; }

            public Int32 @FinancingSumAmount { get; set; }

            public Int32 @IssueNo { get; set; }

            public DateTime @IssueTime { get; set; }

            public List<Order> @Orders { get; set; }

            public Int32 @Period { get; set; }

            public String @PledgeNo { get; set; }

            public Int64 @ProductCategory { get; set; }

            public String @ProductName { get; set; }

            public String @ProductNo { get; set; }

            public Boolean @Repaid { get; set; }

            public Nullable<DateTime> @RepaidTime { get; set; }

            public DateTime @RepaymentDeadline { get; set; }

            public String @RiskManagement { get; set; }

            public String @RiskManagementInfo { get; set; }

            public String @RiskManagementMode { get; set; }

            public DateTime @SettleDate { get; set; }

            public Boolean @SoldOut { get; set; }

            public Nullable<DateTime> @SoldOutTime { get; set; }

            public DateTime @StartSellTime { get; set; }

            public Int32 @UnitPrice { get; set; }

            public String @Usage { get; set; }

            public Nullable<DateTime> @ValueDate { get; set; }

            public Nullable<Int32> @ValueDateMode { get; set; }

            public Int32 @Yield { get; set; }

            public override void SetAll(System.Collections.Generic.IDictionary<string,object> values)
            {   
                object value;
                if (values == null) { InitStateFields(); return; }
                if (values.TryGetValue("CommandStore", out value)) @CommandStore = (ICommandStore) value;
                if (values.TryGetValue("EventStore", out value)) @EventStore = (IEventStore) value;
                if (values.TryGetValue("Id", out value)) @Id = (Guid) value;
                if (values.TryGetValue("Agreement1", out value)) @Agreement1 = (String) value;
                if (values.TryGetValue("Agreement2", out value)) @Agreement2 = (String) value;
                if (values.TryGetValue("Args", out value)) @Args = (String) value;
                if (values.TryGetValue("BankName", out value)) @BankName = (String) value;
                if (values.TryGetValue("Drawee", out value)) @Drawee = (String) value;
                if (values.TryGetValue("DraweeInfo", out value)) @DraweeInfo = (String) value;
                if (values.TryGetValue("EndorseImageLink", out value)) @EndorseImageLink = (String) value;
                if (values.TryGetValue("EndSellTime", out value)) @EndSellTime = (DateTime) value;
                if (values.TryGetValue("EnterpriseInfo", out value)) @EnterpriseInfo = (String) value;
                if (values.TryGetValue("EnterpriseLicense", out value)) @EnterpriseLicense = (String) value;
                if (values.TryGetValue("EnterpriseName", out value)) @EnterpriseName = (String) value;
                if (values.TryGetValue("FinancingSumAmount", out value)) @FinancingSumAmount = value is Int64 ? (Int32)(Int64)value : (Int32)value;
                if (values.TryGetValue("IssueNo", out value)) @IssueNo = value is Int64 ? (Int32)(Int64)value : (Int32)value;
                if (values.TryGetValue("IssueTime", out value)) @IssueTime = (DateTime) value;
                if (values.TryGetValue("Orders", out value)) @Orders = (List<Order>) value;
                if (values.TryGetValue("Period", out value)) @Period = value is Int64 ? (Int32)(Int64)value : (Int32)value;
                if (values.TryGetValue("PledgeNo", out value)) @PledgeNo = (String) value;
                if (values.TryGetValue("ProductCategory", out value)) @ProductCategory = value is Int32 ? (Int32)value : (Int64)value;
                if (values.TryGetValue("ProductName", out value)) @ProductName = (String) value;
                if (values.TryGetValue("ProductNo", out value)) @ProductNo = (String) value;
                if (values.TryGetValue("Repaid", out value)) @Repaid = (Boolean) value;
                if (values.TryGetValue("RepaidTime", out value)) @RepaidTime = (Nullable<DateTime>) value;
                if (values.TryGetValue("RepaymentDeadline", out value)) @RepaymentDeadline = (DateTime) value;
                if (values.TryGetValue("RiskManagement", out value)) @RiskManagement = (String) value;
                if (values.TryGetValue("RiskManagementInfo", out value)) @RiskManagementInfo = (String) value;
                if (values.TryGetValue("RiskManagementMode", out value)) @RiskManagementMode = (String) value;
                if (values.TryGetValue("SettleDate", out value)) @SettleDate = (DateTime) value;
                if (values.TryGetValue("SoldOut", out value)) @SoldOut = (Boolean) value;
                if (values.TryGetValue("SoldOutTime", out value)) @SoldOutTime = (Nullable<DateTime>) value;
                if (values.TryGetValue("StartSellTime", out value)) @StartSellTime = (DateTime) value;
                if (values.TryGetValue("UnitPrice", out value)) @UnitPrice = value is Int64 ? (Int32)(Int64)value : (Int32)value;
                if (values.TryGetValue("Usage", out value)) @Usage = (String) value;
                if (values.TryGetValue("ValueDate", out value)) @ValueDate = (Nullable<DateTime>) value;
                if (values.TryGetValue("ValueDateMode", out value)) @ValueDateMode = (Nullable<Int32>) value;
                if (values.TryGetValue("Yield", out value)) @Yield = value is Int64 ? (Int32)(Int64)value : (Int32)value;
            }

            public override System.String ToString()
            {
                return System.String.Format("RegularProductState( CommandStore={0} EventStore={1} Id={2} Agreement1={3} Agreement2={4} Args={5} BankName={6} Drawee={7} DraweeInfo={8} EndorseImageLink={9} EndSellTime={10} EnterpriseInfo={11} EnterpriseLicense={12} EnterpriseName={13} FinancingSumAmount={14} IssueNo={15} IssueTime={16} Orders={17} Period={18} PledgeNo={19} ProductCategory={20} ProductName={21} ProductNo={22} Repaid={23} RepaidTime={24} RepaymentDeadline={25} RiskManagement={26} RiskManagementInfo={27} RiskManagementMode={28} SettleDate={29} SoldOut={30} SoldOutTime={31} StartSellTime={32} UnitPrice={33} Usage={34} ValueDate={35} ValueDateMode={36} Yield={37} )", @CommandStore, @EventStore, @Id, @Agreement1, @Agreement2, @Args, @BankName, @Drawee, @DraweeInfo, @EndorseImageLink, @EndSellTime, @EnterpriseInfo, @EnterpriseLicense, @EnterpriseName, @FinancingSumAmount, @IssueNo, @IssueTime, @Orders, @Period, @PledgeNo, @ProductCategory, @ProductName, @ProductNo, @Repaid, @RepaidTime, @RepaymentDeadline, @RiskManagement, @RiskManagementInfo, @RiskManagementMode, @SettleDate, @SoldOut, @SoldOutTime, @StartSellTime, @UnitPrice, @Usage, @ValueDate, @ValueDateMode, @Yield);
            }
        
        public RegularProductState() : 
                base("Yuyi.Jinyinmao.Domain.RegularProduct")
        {
            this.InitStateFields();
        }
        
        public override System.Collections.Generic.IDictionary<string, object> AsDictionary()
        {
            System.Collections.Generic.Dictionary<string, object> result = new System.Collections.Generic.Dictionary<string, object>();
            result["CommandStore"] = this.CommandStore;
            result["EventStore"] = this.EventStore;
            result["Id"] = this.Id;
            result["Agreement1"] = this.Agreement1;
            result["Agreement2"] = this.Agreement2;
            result["Args"] = this.Args;
            result["BankName"] = this.BankName;
            result["Drawee"] = this.Drawee;
            result["DraweeInfo"] = this.DraweeInfo;
            result["EndorseImageLink"] = this.EndorseImageLink;
            result["EndSellTime"] = this.EndSellTime;
            result["EnterpriseInfo"] = this.EnterpriseInfo;
            result["EnterpriseLicense"] = this.EnterpriseLicense;
            result["EnterpriseName"] = this.EnterpriseName;
            result["FinancingSumAmount"] = this.FinancingSumAmount;
            result["IssueNo"] = this.IssueNo;
            result["IssueTime"] = this.IssueTime;
            result["Orders"] = this.Orders;
            result["Period"] = this.Period;
            result["PledgeNo"] = this.PledgeNo;
            result["ProductCategory"] = this.ProductCategory;
            result["ProductName"] = this.ProductName;
            result["ProductNo"] = this.ProductNo;
            result["Repaid"] = this.Repaid;
            result["RepaidTime"] = this.RepaidTime;
            result["RepaymentDeadline"] = this.RepaymentDeadline;
            result["RiskManagement"] = this.RiskManagement;
            result["RiskManagementInfo"] = this.RiskManagementInfo;
            result["RiskManagementMode"] = this.RiskManagementMode;
            result["SettleDate"] = this.SettleDate;
            result["SoldOut"] = this.SoldOut;
            result["SoldOutTime"] = this.SoldOutTime;
            result["StartSellTime"] = this.StartSellTime;
            result["UnitPrice"] = this.UnitPrice;
            result["Usage"] = this.Usage;
            result["ValueDate"] = this.ValueDate;
            result["ValueDateMode"] = this.ValueDateMode;
            result["Yield"] = this.Yield;
            return result;
        }
        
        private void InitStateFields()
        {
            this.CommandStore = default(ICommandStore);
            this.EventStore = default(IEventStore);
            this.Id = default(Guid);
            this.Agreement1 = default(String);
            this.Agreement2 = default(String);
            this.Args = default(String);
            this.BankName = default(String);
            this.Drawee = default(String);
            this.DraweeInfo = default(String);
            this.EndorseImageLink = default(String);
            this.EndSellTime = default(DateTime);
            this.EnterpriseInfo = default(String);
            this.EnterpriseLicense = default(String);
            this.EnterpriseName = default(String);
            this.FinancingSumAmount = default(Int32);
            this.IssueNo = default(Int32);
            this.IssueTime = default(DateTime);
            this.Orders = new List<Order>();
            this.Period = default(Int32);
            this.PledgeNo = default(String);
            this.ProductCategory = default(Int64);
            this.ProductName = default(String);
            this.ProductNo = default(String);
            this.Repaid = default(Boolean);
            this.RepaidTime = default(Nullable<DateTime>);
            this.RepaymentDeadline = default(DateTime);
            this.RiskManagement = default(String);
            this.RiskManagementInfo = default(String);
            this.RiskManagementMode = default(String);
            this.SettleDate = default(DateTime);
            this.SoldOut = default(Boolean);
            this.SoldOutTime = default(Nullable<DateTime>);
            this.StartSellTime = default(DateTime);
            this.UnitPrice = default(Int32);
            this.Usage = default(String);
            this.ValueDate = default(Nullable<DateTime>);
            this.ValueDateMode = default(Nullable<Int32>);
            this.Yield = default(Int32);
        }
        
        [global::Orleans.CodeGeneration.CopierMethodAttribute()]
        public static object _Copier(object original)
        {
            RegularProductState input = ((RegularProductState)(original));
            return input.DeepCopy();
        }
        
        [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
        public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
        {
            RegularProductState input = ((RegularProductState)(original));
            input.SerializeTo(stream);
        }
        
        [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
        public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            RegularProductState result = new RegularProductState();
            result.DeserializeFrom(stream);
            return result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [SerializableAttribute()]
    [global::Orleans.CodeGeneration.GrainStateAttribute("Yuyi.Jinyinmao.Domain.Yuyi.Jinyinmao.Domain.User")]
    public class UserState : global::Orleans.CodeGeneration.GrainState, IUserState
    {
        

            public ICommandStore @CommandStore { get; set; }

            public IEventStore @EventStore { get; set; }

            public Guid @Id { get; set; }

            public String @Args { get; set; }

            public List<BankCard> @BankCards { get; set; }

            public String @Cellphone { get; set; }

            public Int64 @ClientType { get; set; }

            public Int64 @ContractId { get; set; }

            public Credential @Credential { get; set; }

            public String @CredentialNo { get; set; }

            public String @EncryptedPassword { get; set; }

            public String @EncryptedPaymentPassword { get; set; }

            public String @InviteBy { get; set; }

            public List<Transcation> @JBYAccount { get; set; }

            public List<String> @LoginNames { get; set; }

            public String @OutletCode { get; set; }

            public String @PaymentSalt { get; set; }

            public String @RealName { get; set; }

            public DateTime @RegisterTime { get; set; }

            public String @Salt { get; set; }

            public List<Transcation> @SettleAccount { get; set; }

            public Boolean @Verified { get; set; }

            public Nullable<DateTime> @VerifiedTime { get; set; }

            public override void SetAll(System.Collections.Generic.IDictionary<string,object> values)
            {   
                object value;
                if (values == null) { InitStateFields(); return; }
                if (values.TryGetValue("CommandStore", out value)) @CommandStore = (ICommandStore) value;
                if (values.TryGetValue("EventStore", out value)) @EventStore = (IEventStore) value;
                if (values.TryGetValue("Id", out value)) @Id = (Guid) value;
                if (values.TryGetValue("Args", out value)) @Args = (String) value;
                if (values.TryGetValue("BankCards", out value)) @BankCards = (List<BankCard>) value;
                if (values.TryGetValue("Cellphone", out value)) @Cellphone = (String) value;
                if (values.TryGetValue("ClientType", out value)) @ClientType = value is Int32 ? (Int32)value : (Int64)value;
                if (values.TryGetValue("ContractId", out value)) @ContractId = value is Int32 ? (Int32)value : (Int64)value;
                if (values.TryGetValue("Credential", out value)) @Credential = (Credential) value;
                if (values.TryGetValue("CredentialNo", out value)) @CredentialNo = (String) value;
                if (values.TryGetValue("EncryptedPassword", out value)) @EncryptedPassword = (String) value;
                if (values.TryGetValue("EncryptedPaymentPassword", out value)) @EncryptedPaymentPassword = (String) value;
                if (values.TryGetValue("InviteBy", out value)) @InviteBy = (String) value;
                if (values.TryGetValue("JBYAccount", out value)) @JBYAccount = (List<Transcation>) value;
                if (values.TryGetValue("LoginNames", out value)) @LoginNames = (List<String>) value;
                if (values.TryGetValue("OutletCode", out value)) @OutletCode = (String) value;
                if (values.TryGetValue("PaymentSalt", out value)) @PaymentSalt = (String) value;
                if (values.TryGetValue("RealName", out value)) @RealName = (String) value;
                if (values.TryGetValue("RegisterTime", out value)) @RegisterTime = (DateTime) value;
                if (values.TryGetValue("Salt", out value)) @Salt = (String) value;
                if (values.TryGetValue("SettleAccount", out value)) @SettleAccount = (List<Transcation>) value;
                if (values.TryGetValue("Verified", out value)) @Verified = (Boolean) value;
                if (values.TryGetValue("VerifiedTime", out value)) @VerifiedTime = (Nullable<DateTime>) value;
            }

            public override System.String ToString()
            {
                return System.String.Format("UserState( CommandStore={0} EventStore={1} Id={2} Args={3} BankCards={4} Cellphone={5} ClientType={6} ContractId={7} Credential={8} CredentialNo={9} EncryptedPassword={10} EncryptedPaymentPassword={11} InviteBy={12} JBYAccount={13} LoginNames={14} OutletCode={15} PaymentSalt={16} RealName={17} RegisterTime={18} Salt={19} SettleAccount={20} Verified={21} VerifiedTime={22} )", @CommandStore, @EventStore, @Id, @Args, @BankCards, @Cellphone, @ClientType, @ContractId, @Credential, @CredentialNo, @EncryptedPassword, @EncryptedPaymentPassword, @InviteBy, @JBYAccount, @LoginNames, @OutletCode, @PaymentSalt, @RealName, @RegisterTime, @Salt, @SettleAccount, @Verified, @VerifiedTime);
            }
        
        public UserState() : 
                base("Yuyi.Jinyinmao.Domain.User")
        {
            this.InitStateFields();
        }
        
        public override System.Collections.Generic.IDictionary<string, object> AsDictionary()
        {
            System.Collections.Generic.Dictionary<string, object> result = new System.Collections.Generic.Dictionary<string, object>();
            result["CommandStore"] = this.CommandStore;
            result["EventStore"] = this.EventStore;
            result["Id"] = this.Id;
            result["Args"] = this.Args;
            result["BankCards"] = this.BankCards;
            result["Cellphone"] = this.Cellphone;
            result["ClientType"] = this.ClientType;
            result["ContractId"] = this.ContractId;
            result["Credential"] = this.Credential;
            result["CredentialNo"] = this.CredentialNo;
            result["EncryptedPassword"] = this.EncryptedPassword;
            result["EncryptedPaymentPassword"] = this.EncryptedPaymentPassword;
            result["InviteBy"] = this.InviteBy;
            result["JBYAccount"] = this.JBYAccount;
            result["LoginNames"] = this.LoginNames;
            result["OutletCode"] = this.OutletCode;
            result["PaymentSalt"] = this.PaymentSalt;
            result["RealName"] = this.RealName;
            result["RegisterTime"] = this.RegisterTime;
            result["Salt"] = this.Salt;
            result["SettleAccount"] = this.SettleAccount;
            result["Verified"] = this.Verified;
            result["VerifiedTime"] = this.VerifiedTime;
            return result;
        }
        
        private void InitStateFields()
        {
            this.CommandStore = default(ICommandStore);
            this.EventStore = default(IEventStore);
            this.Id = default(Guid);
            this.Args = default(String);
            this.BankCards = new List<BankCard>();
            this.Cellphone = default(String);
            this.ClientType = default(Int64);
            this.ContractId = default(Int64);
            this.Credential = default(Credential);
            this.CredentialNo = default(String);
            this.EncryptedPassword = default(String);
            this.EncryptedPaymentPassword = default(String);
            this.InviteBy = default(String);
            this.JBYAccount = new List<Transcation>();
            this.LoginNames = new List<String>();
            this.OutletCode = default(String);
            this.PaymentSalt = default(String);
            this.RealName = default(String);
            this.RegisterTime = default(DateTime);
            this.Salt = default(String);
            this.SettleAccount = new List<Transcation>();
            this.Verified = default(Boolean);
            this.VerifiedTime = default(Nullable<DateTime>);
        }
        
        [global::Orleans.CodeGeneration.CopierMethodAttribute()]
        public static object _Copier(object original)
        {
            UserState input = ((UserState)(original));
            return input.DeepCopy();
        }
        
        [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
        public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
        {
            UserState input = ((UserState)(original));
            input.SerializeTo(stream);
        }
        
        [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
        public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            UserState result = new UserState();
            result.DeserializeFrom(stream);
            return result;
        }
    }
}
namespace Yuyi.Jinyinmao.Domain.Sagas
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Yuyi.Jinyinmao.Domain.Dtos;
    using Orleans.CodeGeneration;
    using Orleans;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [SerializableAttribute()]
    [global::Orleans.CodeGeneration.GrainStateAttribute("Yuyi.Jinyinmao.Domain.Sagas.Yuyi.Jinyinmao.Domain.Sagas.AddBankCardSaga")]
    public class AddBankCardSagaState : global::Orleans.CodeGeneration.GrainState, IAddBankCardSagaState
    {
        

            public Guid @SagaId { get; set; }

            public String @SagaType { get; set; }

            public AddBankCardSagaInitDto @InitData { get; set; }

            public override void SetAll(System.Collections.Generic.IDictionary<string,object> values)
            {   
                object value;
                if (values == null) { InitStateFields(); return; }
                if (values.TryGetValue("SagaId", out value)) @SagaId = (Guid) value;
                if (values.TryGetValue("SagaType", out value)) @SagaType = (String) value;
                if (values.TryGetValue("InitData", out value)) @InitData = (AddBankCardSagaInitDto) value;
            }

            public override System.String ToString()
            {
                return System.String.Format("AddBankCardSagaState( SagaId={0} SagaType={1} InitData={2} )", @SagaId, @SagaType, @InitData);
            }
        
        public AddBankCardSagaState() : 
                base("Yuyi.Jinyinmao.Domain.Sagas.AddBankCardSaga")
        {
            this.InitStateFields();
        }
        
        public override System.Collections.Generic.IDictionary<string, object> AsDictionary()
        {
            System.Collections.Generic.Dictionary<string, object> result = new System.Collections.Generic.Dictionary<string, object>();
            result["SagaId"] = this.SagaId;
            result["SagaType"] = this.SagaType;
            result["InitData"] = this.InitData;
            return result;
        }
        
        private void InitStateFields()
        {
            this.SagaId = default(Guid);
            this.SagaType = default(String);
            this.InitData = new AddBankCardSagaInitDto();
        }
        
        [global::Orleans.CodeGeneration.CopierMethodAttribute()]
        public static object _Copier(object original)
        {
            AddBankCardSagaState input = ((AddBankCardSagaState)(original));
            return input.DeepCopy();
        }
        
        [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
        public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
        {
            AddBankCardSagaState input = ((AddBankCardSagaState)(original));
            input.SerializeTo(stream);
        }
        
        [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
        public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            AddBankCardSagaState result = new AddBankCardSagaState();
            result.DeserializeFrom(stream);
            return result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [SerializableAttribute()]
    [global::Orleans.CodeGeneration.GrainStateAttribute("Yuyi.Jinyinmao.Domain.Sagas.Yuyi.Jinyinmao.Domain.Sagas.AuthenticateSaga")]
    public class AuthenticateSagaState : global::Orleans.CodeGeneration.GrainState, IAuthenticateSagaState
    {
        

            public Guid @SagaId { get; set; }

            public String @SagaType { get; set; }

            public AuthenticateSagaInitDto @InitData { get; set; }

            public override void SetAll(System.Collections.Generic.IDictionary<string,object> values)
            {   
                object value;
                if (values == null) { InitStateFields(); return; }
                if (values.TryGetValue("SagaId", out value)) @SagaId = (Guid) value;
                if (values.TryGetValue("SagaType", out value)) @SagaType = (String) value;
                if (values.TryGetValue("InitData", out value)) @InitData = (AuthenticateSagaInitDto) value;
            }

            public override System.String ToString()
            {
                return System.String.Format("AuthenticateSagaState( SagaId={0} SagaType={1} InitData={2} )", @SagaId, @SagaType, @InitData);
            }
        
        public AuthenticateSagaState() : 
                base("Yuyi.Jinyinmao.Domain.Sagas.AuthenticateSaga")
        {
            this.InitStateFields();
        }
        
        public override System.Collections.Generic.IDictionary<string, object> AsDictionary()
        {
            System.Collections.Generic.Dictionary<string, object> result = new System.Collections.Generic.Dictionary<string, object>();
            result["SagaId"] = this.SagaId;
            result["SagaType"] = this.SagaType;
            result["InitData"] = this.InitData;
            return result;
        }
        
        private void InitStateFields()
        {
            this.SagaId = default(Guid);
            this.SagaType = default(String);
            this.InitData = new AuthenticateSagaInitDto();
        }
        
        [global::Orleans.CodeGeneration.CopierMethodAttribute()]
        public static object _Copier(object original)
        {
            AuthenticateSagaState input = ((AuthenticateSagaState)(original));
            return input.DeepCopy();
        }
        
        [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
        public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
        {
            AuthenticateSagaState input = ((AuthenticateSagaState)(original));
            input.SerializeTo(stream);
        }
        
        [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
        public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            AuthenticateSagaState result = new AuthenticateSagaState();
            result.DeserializeFrom(stream);
            return result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Orleans-CodeGenerator", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    [SerializableAttribute()]
    [global::Orleans.CodeGeneration.GrainStateAttribute("Yuyi.Jinyinmao.Domain.Sagas.Yuyi.Jinyinmao.Domain.Sagas.DepositByYilianSaga")]
    public class DepositByYilianSagaState : global::Orleans.CodeGeneration.GrainState, IDepositByYilianSagaState
    {
        

            public Guid @SagaId { get; set; }

            public String @SagaType { get; set; }

            public DepositFromYilianSagaInitDto @InitData { get; set; }

            public override void SetAll(System.Collections.Generic.IDictionary<string,object> values)
            {   
                object value;
                if (values == null) { InitStateFields(); return; }
                if (values.TryGetValue("SagaId", out value)) @SagaId = (Guid) value;
                if (values.TryGetValue("SagaType", out value)) @SagaType = (String) value;
                if (values.TryGetValue("InitData", out value)) @InitData = (DepositFromYilianSagaInitDto) value;
            }

            public override System.String ToString()
            {
                return System.String.Format("DepositByYilianSagaState( SagaId={0} SagaType={1} InitData={2} )", @SagaId, @SagaType, @InitData);
            }
        
        public DepositByYilianSagaState() : 
                base("Yuyi.Jinyinmao.Domain.Sagas.DepositByYilianSaga")
        {
            this.InitStateFields();
        }
        
        public override System.Collections.Generic.IDictionary<string, object> AsDictionary()
        {
            System.Collections.Generic.Dictionary<string, object> result = new System.Collections.Generic.Dictionary<string, object>();
            result["SagaId"] = this.SagaId;
            result["SagaType"] = this.SagaType;
            result["InitData"] = this.InitData;
            return result;
        }
        
        private void InitStateFields()
        {
            this.SagaId = default(Guid);
            this.SagaType = default(String);
            this.InitData = new DepositFromYilianSagaInitDto();
        }
        
        [global::Orleans.CodeGeneration.CopierMethodAttribute()]
        public static object _Copier(object original)
        {
            DepositByYilianSagaState input = ((DepositByYilianSagaState)(original));
            return input.DeepCopy();
        }
        
        [global::Orleans.CodeGeneration.SerializerMethodAttribute()]
        public static void _Serializer(object original, global::Orleans.Serialization.BinaryTokenStreamWriter stream, System.Type expected)
        {
            DepositByYilianSagaState input = ((DepositByYilianSagaState)(original));
            input.SerializeTo(stream);
        }
        
        [global::Orleans.CodeGeneration.DeserializerMethodAttribute()]
        public static object _Deserializer(System.Type expected, global::Orleans.Serialization.BinaryTokenStreamReader stream)
        {
            DepositByYilianSagaState result = new DepositByYilianSagaState();
            result.DeserializeFrom(stream);
            return result;
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
