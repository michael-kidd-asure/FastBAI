using ACH_Transform.BaiFileProcessor.Interfaces;
using ACH_Transform.BaiFileProcessor.Models;
using FastBAI.Helpers;

namespace FastBAI.Implementations
{
    internal class FileHeaderParser : IBaiParserService
    {

        public BaiBaseRecord ParseRecord(string data)
        {
            var splitData = data.Split(new char[] { ',' });

            if (splitData == null || splitData.Length == 0)
            {
                throw new ArgumentException($"Invalid File Header (01 record) length: No data returned.");
            }

            FileHeaderRecord oneRecord = new();

            oneRecord.SenderId = splitData[1];
            oneRecord.ReceiverId = splitData[2];
            oneRecord.FileCreationDate = splitData[3];
            oneRecord.FileCreationTime = splitData[4];
            oneRecord.FileIdNumber = DataFormatHelper.ParseInt(splitData[5].Trim());
            oneRecord.RecordLength = DataFormatHelper.ParseInt(splitData[6].Trim());
            oneRecord.BlockSize = DataFormatHelper.ParseInt(splitData[7].Trim());

            var cleanData = DataFormatHelper.CleanupLastBaiDataElementOnLine(splitData[8].Trim());
            oneRecord.VersionNumber = DataFormatHelper.ParseInt(cleanData);

            return oneRecord;
        }
    }
}
