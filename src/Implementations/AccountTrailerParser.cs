using ACH_Transform.BaiFileProcessor.Interfaces;
using ACH_Transform.BaiFileProcessor.Models;
using FastBAI.Helpers;

namespace FastBAI.Implementations
{
    internal class AccountTrailerParser : IBaiParserService
    {

        public BaiBaseRecord ParseRecord(string data)
        {
            var splitData = data.Split(new char[] { ',' });

            if (splitData == null || splitData.Length == 0)
            {
                throw new ArgumentException($"Invalid File Trailer (49 record) length: No data returned.");
            }

            AccountTrailerRecord fourtyNineRecord = new();

            fourtyNineRecord.AccountControlTotal = DataFormatHelper.ParseInt(splitData[1].Trim());

            var cleanData = DataFormatHelper.CleanupLastBaiDataElementOnLine(splitData[2].Trim());
            fourtyNineRecord.NumberOfRecords = DataFormatHelper.ParseInt(cleanData);

            return fourtyNineRecord;
        }
    }
}
