using ACH_Transform.BaiFileProcessor.Interfaces;
using ACH_Transform.BaiFileProcessor.Models;
using FastBAI.Helpers;
using System.Text.RegularExpressions;

namespace FastBAI.Implementations
{
    internal class AccountSummaryParser : IBaiParserService
    {

        public BaiBaseRecord ParseRecord(string data)
        {
            var splitData = data.Split(new char[] { ',' });

            if (splitData == null || splitData.Length == 0)
            {
                throw new ArgumentException($"Invalid File Trailer (03 record) length: No data returned.");
            }

            AccountIdentifierRecord threeRecord = new();

            threeRecord.AccountNumber = splitData[1].Trim();
            threeRecord.CurrencyCode = splitData[2].Trim();
            decimal arrayLength = splitData.Length - 3;
            //Console.WriteLine($"Groups Length {arrayLength}: ");

            // groups of 4 denote account balances, regex to start trys to match 3 digit codes that 
            // signify account balance start
            for (int i = 3; i < arrayLength; i += 4)
            {
                int groupIndex = i;

                if (Regex.IsMatch(splitData[groupIndex], @"\d{3}"))
                {
                    threeRecord.AccountDetails.Add(new AccountDetails
                    {
                        TypeCode = splitData[groupIndex],
                        Amount = DataFormatHelper.ParseDecimal(splitData[groupIndex + 1]),
                        ItemCount = DataFormatHelper.ParseInt(splitData[groupIndex + 2]),
                        FundsType = DataFormatHelper.CleanupLastBaiDataElementOnLine(splitData[groupIndex + 3])
                    });
                    //Console.WriteLine($"Group {groupIndex}: [1]: {splitData[groupIndex]} [2]: {splitData[groupIndex + 1]} [3]: {splitData[groupIndex + 2]} [4]: {splitData[accountIndex + 3]}");
                }
                else
                    throw new ArgumentException("03 Account Balances are not in the correct format. Balance groupings should start with a 3 digit code");

            }

            return threeRecord;
        }
    }
}
