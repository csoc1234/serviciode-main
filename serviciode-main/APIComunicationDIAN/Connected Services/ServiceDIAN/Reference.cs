﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceDIAN
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ExchangeEmailResponse", Namespace="http://schemas.datacontract.org/2004/07/ExchangeEmailResponse")]
    public partial class ExchangeEmailResponse : object
    {
        
        private byte[] CsvBase64BytesField;
        
        private string MessageField;
        
        private string StatusCodeField;
        
        private bool SuccessField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] CsvBase64Bytes
        {
            get
            {
                return this.CsvBase64BytesField;
            }
            set
            {
                this.CsvBase64BytesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success
        {
            get
            {
                return this.SuccessField;
            }
            set
            {
                this.SuccessField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DianResponse", Namespace="http://schemas.datacontract.org/2004/07/DianResponse")]
    public partial class DianResponse : object
    {
        
        private string[] ErrorMessageField;
        
        private bool IsValidField;
        
        private string StatusCodeField;
        
        private string StatusDescriptionField;
        
        private string StatusMessageField;
        
        private byte[] XmlBase64BytesField;
        
        private byte[] XmlBytesField;
        
        private string XmlDocumentKeyField;
        
        private string XmlFileNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] ErrorMessage
        {
            get
            {
                return this.ErrorMessageField;
            }
            set
            {
                this.ErrorMessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsValid
        {
            get
            {
                return this.IsValidField;
            }
            set
            {
                this.IsValidField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusDescription
        {
            get
            {
                return this.StatusDescriptionField;
            }
            set
            {
                this.StatusDescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusMessage
        {
            get
            {
                return this.StatusMessageField;
            }
            set
            {
                this.StatusMessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] XmlBase64Bytes
        {
            get
            {
                return this.XmlBase64BytesField;
            }
            set
            {
                this.XmlBase64BytesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] XmlBytes
        {
            get
            {
                return this.XmlBytesField;
            }
            set
            {
                this.XmlBytesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string XmlDocumentKey
        {
            get
            {
                return this.XmlDocumentKeyField;
            }
            set
            {
                this.XmlDocumentKeyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string XmlFileName
        {
            get
            {
                return this.XmlFileNameField;
            }
            set
            {
                this.XmlFileNameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UploadDocumentResponse", Namespace="http://schemas.datacontract.org/2004/07/UploadDocumentResponse")]
    public partial class UploadDocumentResponse : object
    {
        
        private ServiceDIAN.XmlParamsResponseTrackId[] ErrorMessageListField;
        
        private string ZipKeyField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceDIAN.XmlParamsResponseTrackId[] ErrorMessageList
        {
            get
            {
                return this.ErrorMessageListField;
            }
            set
            {
                this.ErrorMessageListField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ZipKey
        {
            get
            {
                return this.ZipKeyField;
            }
            set
            {
                this.ZipKeyField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="XmlParamsResponseTrackId", Namespace="http://schemas.datacontract.org/2004/07/XmlParamsResponseTrackId")]
    public partial class XmlParamsResponseTrackId : object
    {
        
        private string DocumentKeyField;
        
        private string ProcessedMessageField;
        
        private string SenderCodeField;
        
        private bool SuccessField;
        
        private string XmlFileNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DocumentKey
        {
            get
            {
                return this.DocumentKeyField;
            }
            set
            {
                this.DocumentKeyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProcessedMessage
        {
            get
            {
                return this.ProcessedMessageField;
            }
            set
            {
                this.ProcessedMessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SenderCode
        {
            get
            {
                return this.SenderCodeField;
            }
            set
            {
                this.SenderCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success
        {
            get
            {
                return this.SuccessField;
            }
            set
            {
                this.SuccessField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string XmlFileName
        {
            get
            {
                return this.XmlFileNameField;
            }
            set
            {
                this.XmlFileNameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NumberRangeResponseList", Namespace="http://schemas.datacontract.org/2004/07/NumberRangeResponseList")]
    public partial class NumberRangeResponseList : object
    {
        
        private string OperationCodeField;
        
        private string OperationDescriptionField;
        
        private ServiceDIAN.NumberRangeResponse[] ResponseListField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OperationCode
        {
            get
            {
                return this.OperationCodeField;
            }
            set
            {
                this.OperationCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OperationDescription
        {
            get
            {
                return this.OperationDescriptionField;
            }
            set
            {
                this.OperationDescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceDIAN.NumberRangeResponse[] ResponseList
        {
            get
            {
                return this.ResponseListField;
            }
            set
            {
                this.ResponseListField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NumberRangeResponse", Namespace="http://schemas.datacontract.org/2004/07/NumberRangeResponse")]
    public partial class NumberRangeResponse : object
    {
        
        private string ResolutionNumberField;
        
        private string ResolutionDateField;
        
        private string PrefixField;
        
        private long FromNumberField;
        
        private long ToNumberField;
        
        private string ValidDateFromField;
        
        private string ValidDateToField;
        
        private string TechnicalKeyField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ResolutionNumber
        {
            get
            {
                return this.ResolutionNumberField;
            }
            set
            {
                this.ResolutionNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string ResolutionDate
        {
            get
            {
                return this.ResolutionDateField;
            }
            set
            {
                this.ResolutionDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string Prefix
        {
            get
            {
                return this.PrefixField;
            }
            set
            {
                this.PrefixField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public long FromNumber
        {
            get
            {
                return this.FromNumberField;
            }
            set
            {
                this.FromNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public long ToNumber
        {
            get
            {
                return this.ToNumberField;
            }
            set
            {
                this.ToNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string ValidDateFrom
        {
            get
            {
                return this.ValidDateFromField;
            }
            set
            {
                this.ValidDateFromField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public string ValidDateTo
        {
            get
            {
                return this.ValidDateToField;
            }
            set
            {
                this.ValidDateToField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public string TechnicalKey
        {
            get
            {
                return this.TechnicalKeyField;
            }
            set
            {
                this.TechnicalKeyField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EventResponse", Namespace="http://schemas.datacontract.org/2004/07/EventResponse")]
    public partial class EventResponse : object
    {
        
        private string CodeField;
        
        private string MessageField;
        
        private string XmlBytesBase64Field;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code
        {
            get
            {
                return this.CodeField;
            }
            set
            {
                this.CodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string XmlBytesBase64
        {
            get
            {
                return this.XmlBytesBase64Field;
            }
            set
            {
                this.XmlBytesBase64Field = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DocIdentifierWithEventsResponse", Namespace="http://schemas.datacontract.org/2004/07/DocIdentifierWithEventsResponse")]
    public partial class DocIdentifierWithEventsResponse : object
    {
        
        private byte[] CsvBase64BytesField;
        
        private string MessageField;
        
        private string StatusCodeField;
        
        private bool SuccessField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] CsvBase64Bytes
        {
            get
            {
                return this.CsvBase64BytesField;
            }
            set
            {
                this.CsvBase64BytesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusCode
        {
            get
            {
                return this.StatusCodeField;
            }
            set
            {
                this.StatusCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success
        {
            get
            {
                return this.SuccessField;
            }
            set
            {
                this.SuccessField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://wcf.dian.colombia", ConfigurationName="ServiceDIAN.IWcfDianCustomerServices")]
    public interface IWcfDianCustomerServices
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetExchangeEmails", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetExchangeEmailsResponse")]
        ServiceDIAN.ExchangeEmailResponse GetExchangeEmails();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetExchangeEmails", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetExchangeEmailsResponse")]
        System.Threading.Tasks.Task<ServiceDIAN.ExchangeEmailResponse> GetExchangeEmailsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetStatus", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetStatusResponse")]
        ServiceDIAN.DianResponse GetStatus(string trackId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetStatus", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetStatusResponse")]
        System.Threading.Tasks.Task<ServiceDIAN.DianResponse> GetStatusAsync(string trackId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetStatusZip", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetStatusZipResponse")]
        ServiceDIAN.DianResponse[] GetStatusZip(string trackId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetStatusZip", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetStatusZipResponse")]
        System.Threading.Tasks.Task<ServiceDIAN.DianResponse[]> GetStatusZipAsync(string trackId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetStatusEvent", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetStatusEventResponse")]
        ServiceDIAN.DianResponse GetStatusEvent(string trackId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetStatusEvent", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetStatusEventResponse")]
        System.Threading.Tasks.Task<ServiceDIAN.DianResponse> GetStatusEventAsync(string trackId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/SendBillAsync", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/SendBillAsyncResponse")]
        ServiceDIAN.UploadDocumentResponse SendBillAsync(string fileName, byte[] contentFile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/SendBillAsync", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/SendBillAsyncResponse")]
        System.Threading.Tasks.Task<ServiceDIAN.UploadDocumentResponse> SendBillAsyncAsync(string fileName, byte[] contentFile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/SendTestSetAsync", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/SendTestSetAsyncResponse")]
        ServiceDIAN.UploadDocumentResponse SendTestSetAsync(string fileName, byte[] contentFile, string testSetId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/SendTestSetAsync", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/SendTestSetAsyncResponse")]
        System.Threading.Tasks.Task<ServiceDIAN.UploadDocumentResponse> SendTestSetAsyncAsync(string fileName, byte[] contentFile, string testSetId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/SendBillSync", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/SendBillSyncResponse")]
        ServiceDIAN.DianResponse SendBillSync(string fileName, byte[] contentFile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/SendBillSync", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/SendBillSyncResponse")]
        System.Threading.Tasks.Task<ServiceDIAN.DianResponse> SendBillSyncAsync(string fileName, byte[] contentFile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/SendBillAttachmentAsync", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/SendBillAttachmentAsyncResponse" +
            "")]
        ServiceDIAN.UploadDocumentResponse SendBillAttachmentAsync(string fileName, byte[] contentFile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/SendBillAttachmentAsync", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/SendBillAttachmentAsyncResponse" +
            "")]
        System.Threading.Tasks.Task<ServiceDIAN.UploadDocumentResponse> SendBillAttachmentAsyncAsync(string fileName, byte[] contentFile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/SendEventUpdateStatus", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/SendEventUpdateStatusResponse")]
        ServiceDIAN.DianResponse SendEventUpdateStatus(byte[] contentFile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/SendEventUpdateStatus", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/SendEventUpdateStatusResponse")]
        System.Threading.Tasks.Task<ServiceDIAN.DianResponse> SendEventUpdateStatusAsync(byte[] contentFile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/SendNominaSync", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/SendNominaSyncResponse")]
        ServiceDIAN.DianResponse SendNominaSync(byte[] contentFile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/SendNominaSync", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/SendNominaSyncResponse")]
        System.Threading.Tasks.Task<ServiceDIAN.DianResponse> SendNominaSyncAsync(byte[] contentFile);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetNumberingRange", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetNumberingRangeResponse")]
        ServiceDIAN.NumberRangeResponseList GetNumberingRange(string accountCode, string accountCodeT, string softwareCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetNumberingRange", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetNumberingRangeResponse")]
        System.Threading.Tasks.Task<ServiceDIAN.NumberRangeResponseList> GetNumberingRangeAsync(string accountCode, string accountCodeT, string softwareCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetXmlByDocumentKey", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetXmlByDocumentKeyResponse")]
        ServiceDIAN.EventResponse GetXmlByDocumentKey(string trackId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetXmlByDocumentKey", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetXmlByDocumentKeyResponse")]
        System.Threading.Tasks.Task<ServiceDIAN.EventResponse> GetXmlByDocumentKeyAsync(string trackId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetDocIdentifierWithEvents", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetDocIdentifierWithEventsRespo" +
            "nse")]
        ServiceDIAN.DocIdentifierWithEventsResponse GetDocIdentifierWithEvents(string contributorCode, string dateNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetDocIdentifierWithEvents", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetDocIdentifierWithEventsRespo" +
            "nse")]
        System.Threading.Tasks.Task<ServiceDIAN.DocIdentifierWithEventsResponse> GetDocIdentifierWithEventsAsync(string contributorCode, string dateNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetReferenceNotes", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetReferenceNotesResponse")]
        ServiceDIAN.DianResponse GetReferenceNotes(string trackId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://wcf.dian.colombia/IWcfDianCustomerServices/GetReferenceNotes", ReplyAction="http://wcf.dian.colombia/IWcfDianCustomerServices/GetReferenceNotesResponse")]
        System.Threading.Tasks.Task<ServiceDIAN.DianResponse> GetReferenceNotesAsync(string trackId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface IWcfDianCustomerServicesChannel : ServiceDIAN.IWcfDianCustomerServices, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class WcfDianCustomerServicesClient : System.ServiceModel.ClientBase<ServiceDIAN.IWcfDianCustomerServices>, ServiceDIAN.IWcfDianCustomerServices
    {
        
        public WcfDianCustomerServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public ServiceDIAN.ExchangeEmailResponse GetExchangeEmails()
        {
            return base.Channel.GetExchangeEmails();
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.ExchangeEmailResponse> GetExchangeEmailsAsync()
        {
            return base.Channel.GetExchangeEmailsAsync();
        }
        
        public ServiceDIAN.DianResponse GetStatus(string trackId)
        {
            return base.Channel.GetStatus(trackId);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.DianResponse> GetStatusAsync(string trackId)
        {
            return base.Channel.GetStatusAsync(trackId);
        }
        
        public ServiceDIAN.DianResponse[] GetStatusZip(string trackId)
        {
            return base.Channel.GetStatusZip(trackId);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.DianResponse[]> GetStatusZipAsync(string trackId)
        {
            return base.Channel.GetStatusZipAsync(trackId);
        }
        
        public ServiceDIAN.DianResponse GetStatusEvent(string trackId)
        {
            return base.Channel.GetStatusEvent(trackId);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.DianResponse> GetStatusEventAsync(string trackId)
        {
            return base.Channel.GetStatusEventAsync(trackId);
        }
        
        public ServiceDIAN.UploadDocumentResponse SendBillAsync(string fileName, byte[] contentFile)
        {
            return base.Channel.SendBillAsync(fileName, contentFile);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.UploadDocumentResponse> SendBillAsyncAsync(string fileName, byte[] contentFile)
        {
            return base.Channel.SendBillAsyncAsync(fileName, contentFile);
        }
        
        public ServiceDIAN.UploadDocumentResponse SendTestSetAsync(string fileName, byte[] contentFile, string testSetId)
        {
            return base.Channel.SendTestSetAsync(fileName, contentFile, testSetId);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.UploadDocumentResponse> SendTestSetAsyncAsync(string fileName, byte[] contentFile, string testSetId)
        {
            return base.Channel.SendTestSetAsyncAsync(fileName, contentFile, testSetId);
        }
        
        public ServiceDIAN.DianResponse SendBillSync(string fileName, byte[] contentFile)
        {
            return base.Channel.SendBillSync(fileName, contentFile);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.DianResponse> SendBillSyncAsync(string fileName, byte[] contentFile)
        {
            return base.Channel.SendBillSyncAsync(fileName, contentFile);
        }
        
        public ServiceDIAN.UploadDocumentResponse SendBillAttachmentAsync(string fileName, byte[] contentFile)
        {
            return base.Channel.SendBillAttachmentAsync(fileName, contentFile);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.UploadDocumentResponse> SendBillAttachmentAsyncAsync(string fileName, byte[] contentFile)
        {
            return base.Channel.SendBillAttachmentAsyncAsync(fileName, contentFile);
        }
        
        public ServiceDIAN.DianResponse SendEventUpdateStatus(byte[] contentFile)
        {
            return base.Channel.SendEventUpdateStatus(contentFile);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.DianResponse> SendEventUpdateStatusAsync(byte[] contentFile)
        {
            return base.Channel.SendEventUpdateStatusAsync(contentFile);
        }
        
        public ServiceDIAN.DianResponse SendNominaSync(byte[] contentFile)
        {
            return base.Channel.SendNominaSync(contentFile);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.DianResponse> SendNominaSyncAsync(byte[] contentFile)
        {
            return base.Channel.SendNominaSyncAsync(contentFile);
        }
        
        public ServiceDIAN.NumberRangeResponseList GetNumberingRange(string accountCode, string accountCodeT, string softwareCode)
        {
            return base.Channel.GetNumberingRange(accountCode, accountCodeT, softwareCode);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.NumberRangeResponseList> GetNumberingRangeAsync(string accountCode, string accountCodeT, string softwareCode)
        {
            return base.Channel.GetNumberingRangeAsync(accountCode, accountCodeT, softwareCode);
        }
        
        public ServiceDIAN.EventResponse GetXmlByDocumentKey(string trackId)
        {
            return base.Channel.GetXmlByDocumentKey(trackId);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.EventResponse> GetXmlByDocumentKeyAsync(string trackId)
        {
            return base.Channel.GetXmlByDocumentKeyAsync(trackId);
        }
        
        public ServiceDIAN.DocIdentifierWithEventsResponse GetDocIdentifierWithEvents(string contributorCode, string dateNumber)
        {
            return base.Channel.GetDocIdentifierWithEvents(contributorCode, dateNumber);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.DocIdentifierWithEventsResponse> GetDocIdentifierWithEventsAsync(string contributorCode, string dateNumber)
        {
            return base.Channel.GetDocIdentifierWithEventsAsync(contributorCode, dateNumber);
        }
        
        public ServiceDIAN.DianResponse GetReferenceNotes(string trackId)
        {
            return base.Channel.GetReferenceNotes(trackId);
        }
        
        public System.Threading.Tasks.Task<ServiceDIAN.DianResponse> GetReferenceNotesAsync(string trackId)
        {
            return base.Channel.GetReferenceNotesAsync(trackId);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
    }
}