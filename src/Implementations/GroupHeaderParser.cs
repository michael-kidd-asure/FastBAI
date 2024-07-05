using ACH_Transform.BaiFileProcessor.Interfaces;
using ACH_Transform.BaiFileProcessor.Models;
using FastBAI.Helpers;

namespace FastBAI.Implementations
{
    internal class GroupHeaderParser : IBaiParserService
    {

        public BaiBaseRecord ParseRecord(string data)
        {
            var splitData = data.Split(new char[] { ',' });

            if (splitData == null || splitData.Length == 0)
            {
                throw new ArgumentException($"Invalid File Trailer (98 record) length: No data returned.");
            }

            GroupHeaderRecord twoRecord = new();

            twoRecord.ReceiverId = splitData[1].Trim();
            twoRecord.OriginatorId = splitData[2].Trim();
            twoRecord.GroupStatus = splitData[3].Trim();
            twoRecord.AsOfDate = splitData[4].Trim();
            twoRecord.AsOfTime = splitData[5].Trim();
            twoRecord.CurrencyCode = splitData[6].Trim();

            var cleanData = DataFormatHelper.CleanupLastBaiDataElementOnLine(splitData[7].Trim());
            twoRecord.AsOfDateModifier = DataFormatHelper.ParseInt(cleanData);

            return twoRecord;
        }
    }
}
