using System.Collections.Generic;

namespace ACH_Transform.BaiFileProcessor.Models
{
    public class AccountIdentifierRecord : BaiBaseRecord
    {
        public List<TxDetailRecord> TransactionRecords = new();
        public AccountTrailerRecord AccountTrailer = new();
        public List<AccountDetails> AccountDetails = new();

        public string AccountNumber
        {
            get;
            set;
        }

        public string CurrencyCode
        {
            get;
            set;
        }
    }
}
