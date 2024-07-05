using System.Collections.Generic;

namespace ACH_Transform.BaiFileProcessor.Models
{
    public class GroupHeaderRecord : BaiBaseRecord
    {
        public List<AccountIdentifierRecord> Accounts = new();
        public GroupTrailerRecord GroupTrailer = new();

        public string ReceiverId
        {
            get;
            set;
        }

        public string OriginatorId
        {
            get;
            set;
        }

        public string GroupStatus
        {
            get;
            set;
        }

        public string AsOfDate
        {
            get;
            set;
        }

        public string AsOfTime
        {
            get;
            set;
        }

        public string CurrencyCode
        {
            get;
            set;
        }

        public int AsOfDateModifier
        {
            get;
            set;
        }

        //public GroupTotals GroupTotals
        //{
        //    get;
        //    set;
        //}
    }
}
