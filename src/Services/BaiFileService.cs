using FastBAI.Implementations;
using ACH_Transform.BaiFileProcessor.Models;
using ACH_Transform.BaiFileProcessor.Services;
using System;
using System.IO;

namespace FastBAI.Services
{
    public class BaiFileService : IBaiFileService
    {
        private Stream? _fileStream;
        private BaiFile _baiFile = new();

        public void ParseFile()
        {
            GroupHeaderRecord currentGroup = new();
            AccountIdentifierRecord currentAccount = new();
            TxDetailRecord? currentDetail = null;

            if (_fileStream == null) 
                throw new Exception("File Stream is unexpectedly null.  Cannot proceed.");

            using (StreamReader reader = new StreamReader(_fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    switch (line.Substring(0, 2))
                    {
                        case "01":
                            FileHeaderParser oneRecordParser = new();
                            _baiFile.FileHeader = (FileHeaderRecord)oneRecordParser.ParseRecord(line);
                            break;

                        case "02":
                            GroupHeaderParser twoRecordParser = new();
                            currentGroup = (GroupHeaderRecord)twoRecordParser.ParseRecord(line);
                            break;

                        case "03":
                            AccountSummaryParser threeRecordParser = new();
                            currentAccount = (AccountIdentifierRecord)threeRecordParser.ParseRecord(line);
                            break;

                        case "16":
                            if (currentDetail != null)
                            {
                                currentAccount.TransactionRecords.Add(currentDetail);
                            }

                            currentDetail = new();

                            DetailRecordParser sixteenRecordParser = new();
                            currentDetail = (TxDetailRecord)sixteenRecordParser.ParseRecord(line);
                            break;

                        case "88":
                            //rec sixteenRecordParser = new();
                            //currentAccount.TransactionRecords.Add((BaiRecordType16)sixteenRecordParser.ParseRecord(line));
                            currentDetail.SupportingTextList.Add(line.Substring(3));
                            break;

                        case "49":
                            if (currentDetail != null)
                            {
                                currentAccount.TransactionRecords.Add(currentDetail);
                                currentDetail = new();
                            }
                            AccountTrailerParser fourtyNineParser = new();
                            currentAccount.AccountTrailer = (AccountTrailerRecord)fourtyNineParser.ParseRecord(line);
                            currentGroup.Accounts.Add(currentAccount);
                            currentAccount = new();
                            break;

                        case "98":
                            GroupTrailerParser ninetyEightParser = new();
                            currentGroup.GroupTrailer = (GroupTrailerRecord)ninetyEightParser.ParseRecord(line);
                            _baiFile.FileHeader.Groups.Add(currentGroup);
                            currentGroup = new();
                            break;

                        case "99":
                            FileTrailerParser ninetyNineParser = new();
                            _baiFile.FileTrailer = (FileTrailerRecord)ninetyNineParser.ParseRecord(line);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public BaiFile GetFile()
        {
            return _baiFile;
        }

        public BaiFile ProcessFile(string filePath)
        {
            ReadFile(filePath);
            ParseFile();
            return _baiFile;
        }

        public void ReadFile(string filePath)
        {
            try
            {
                // Open the file in FileMode.Open, FileAccess.Read, and FileShare.ReadWrite (optional).
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    // Create a MemoryStream and copy the content of the file into it.
                    MemoryStream memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);

                    // Reset the MemoryStream position to the beginning.
                    memoryStream.Position = 0;

                    _fileStream = memoryStream;
                    // Return the MemoryStream, which now contains the file data.
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during file reading.
                Console.WriteLine($"Error reading the file: {ex.Message}");
                throw;
            }
        }
    }
}
