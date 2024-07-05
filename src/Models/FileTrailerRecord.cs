namespace ACH_Transform.BaiFileProcessor.Models
{
    public class FileTrailerRecord : BaiBaseRecord
    {
        public decimal FileControlTotal
        {
            get;
            set;
        }

        public long NumberOfGroups
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
