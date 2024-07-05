using System.Collections.Generic;

namespace ACH_Transform.BaiFileProcessor.Models
{
    public class TxDetailRecord : BaiBaseRecord
    {
        public string TypeCode
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public string FundsType
        {
            get;
            set;
        }

        public string BankRefeneceNumber
        {
            get;
            set;
        }

        public string CustomerReferenceNumber
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public List<string> SupportingTextList = new();
    }
}
