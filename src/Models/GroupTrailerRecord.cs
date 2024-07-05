namespace ACH_Transform.BaiFileProcessor.Models
{
    public class GroupTrailerRecord : BaiBaseRecord
    {
        public decimal GroupControlTotal
        {
            get;
            set;
        }

        public long NumberOfAccounts
        {
            get;
            set;
        }

        public long NumberOfRecords
        {
            get;
            set;
        }
    }
}
