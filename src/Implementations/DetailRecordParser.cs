using ACH_Transform.BaiFileProcessor.Interfaces;
using ACH_Transform.BaiFileProcessor.Models;
using FastBAI.Helpers;

namespace FastBAI.Implementations
{
    internal class DetailRecordParser : IBaiParserService
    {

        public BaiBaseRecord ParseRecord(string data)
        {
            var splitData = data.Split(new char[] { ',' });

            if (splitData == null || splitData.Length == 0)
            {
                throw new ArgumentException($"Invalid File Trailer (16 record) length: No data returned.");
            }

            TxDetailRecord sixteenRecord = new();

            sixteenRecord.TypeCode = splitData[1].Trim();
            sixteenRecord.Amount = DataFormatHelper.ParseDecimal(splitData[2].Trim());
            sixteenRecord.FundsType = splitData[3].Trim();
            sixteenRecord.BankRefeneceNumber = splitData[4].Trim();
            sixteenRecord.CustomerReferenceNumber = splitData[5].Trim();

            for (int i = 6; i < splitData.Length; i++)
            {
                if (i > 6)
                    sixteenRecord.Text += ", " + splitData[i].Trim();
                else
                    sixteenRecord.Text = splitData[i].Trim();
            }

            return sixteenRecord;
        }
    }
}
