using ACH_Transform.BaiFileProcessor.Interfaces;
using ACH_Transform.BaiFileProcessor.Models;
using FastBAI.Helpers;

namespace FastBAI.Implementations
{
    internal class FileTrailerParser : IBaiParserService
    {

        public BaiBaseRecord ParseRecord(string data)
        {
            var splitData = data.Split(new char[] { ',' });

            if (splitData == null || splitData.Length == 0)
            {
                throw new ArgumentException($"Invalid File Trailer (99 record) length: No data returned.");
            }

            FileTrailerRecord ninetyNineRecord = new();

            ninetyNineRecord.FileControlTotal = DataFormatHelper.ParseInt(splitData[1].Trim());
            ninetyNineRecord.NumberOfGroups = DataFormatHelper.ParseInt(splitData[2].Trim());

            var cleanData = DataFormatHelper.CleanupLastBaiDataElementOnLine(splitData[3].Trim());
            ninetyNineRecord.NumberOfRecords = DataFormatHelper.ParseInt(cleanData);

            return ninetyNineRecord;
        }
    }
}
