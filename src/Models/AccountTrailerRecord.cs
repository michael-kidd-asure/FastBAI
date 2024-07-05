namespace ACH_Transform.BaiFileProcessor.Models
{
    public class AccountTrailerRecord : BaiBaseRecord
    {
        public decimal AccountControlTotal
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
