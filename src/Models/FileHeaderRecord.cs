using System.Collections.Generic;

namespace ACH_Transform.BaiFileProcessor.Models
{
    public class FileHeaderRecord : BaiBaseRecord
    {
        public List<GroupHeaderRecord> Groups = new();

        public string SenderId
        {
            get;
            set;
        }

        public string ReceiverId
        {
            get;
            set;
        }

        public string FileCreationDate
        {
            get;
            set;
        }

        public string FileCreationTime
        {
            get;
            set;
        }

        public long FileIdNumber
        {
            get;
            set;
        }


        public long RecordLength
        {
            get;
            set;
        }

        public long? BlockSize
        {
            get;
            set;
        }

        public decimal VersionNumber
        {
            get;
            set;
        }
    }
}
