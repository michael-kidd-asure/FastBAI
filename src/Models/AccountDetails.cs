namespace ACH_Transform.BaiFileProcessor.Models
{
    public class AccountDetails
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

        public int ItemCount
        {
            get;
            set;
        }

        public string FundsType
        {
            get;
            set;
        }
    }
}
