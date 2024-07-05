using ACH_Transform.BaiFileProcessor.Interfaces;
using ACH_Transform.BaiFileProcessor.Models;
using FastBAI.Helpers;

namespace FastBAI.Implementations
{
    internal class GroupTrailerParser : IBaiParserService
    {

        public BaiBaseRecord ParseRecord(string data)
        {
            var splitData = data.Split(new char[] { ',' });

            if (splitData == null || splitData.Length == 0)
            {
                throw new ArgumentException($"Invalid File Trailer (98 record) length: No data returned.");
            }

            GroupTrailerRecord ninetyEightRecord = new();

            ninetyEightRecord.GroupControlTotal = DataFormatHelper.ParseInt(splitData[1].Trim());
            ninetyEightRecord.NumberOfAccounts = DataFormatHelper.ParseInt(splitData[2].Trim());

            var cleanData = DataFormatHelper.CleanupLastBaiDataElementOnLine(splitData[3].Trim());
            ninetyEightRecord.NumberOfRecords = DataFormatHelper.ParseInt(cleanData);

            return ninetyEightRecord;
        }
    }
}
