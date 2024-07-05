using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ACH_Transform.BaiFileProcessor.Models
{
    public class BaiFile
    {

        public BaiFile()
        {
        }

        public FileHeaderRecord FileHeader = new();
        public FileTrailerRecord FileTrailer = new();

        //public void SaveFileToDisk(string filePath)
        //{
        //    // Create a memory stream to store the lines
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        // Create a StreamWriter to write to the memory stream
        //        using (StreamWriter streamWriter = new StreamWriter(memoryStream))
        //        {
        //            BuildFileContents(streamWriter);

        //            // Flush the writer to ensure content is in the memory stream
        //            streamWriter.Flush();

        //            // Create a FileStream to write the memory stream content to a file
        //            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                // Get the content of the memory stream as a byte array
        //                byte[] memoryStreamContent = memoryStream.ToArray();

        //                // Write the content to the file stream
        //                fileStream.Write(memoryStreamContent, 0, memoryStreamContent.Length);
        //            }
        //        }
        //    }
        //}

        //private void BuildFileContents(StreamWriter streamWriter)
        //{
        //    WriteToStream(streamWriter, OneRecord.WriteAsText());

        //    for (int i = 0; i < BatchRecordList.Count; i++)
        //    {
        //        if (_shouldRecalculate)
        //            BatchRecordList[i].RecalculateTotals(i + 1);

        //        WriteToStream(streamWriter, BatchRecordList[i].WriteAsText());

        //        foreach (var batchDetailRecord in BatchRecordList[i].SixRecordList)
        //        {
        //            WriteToStream(streamWriter, batchDetailRecord.WriteAsText());

        //            if (batchDetailRecord.AddendaRecord != null)
        //            {
        //                WriteToStream(streamWriter, batchDetailRecord.AddendaRecord.WriteAsText());
        //            }
        //        }

        //        WriteToStream(streamWriter, BatchRecordList[i].EightRecord.WriteAsText());
        //    }

        //    // need to increment line count before the recalc to ensure the block count is correct
        //    _fileLineCount++;
        //    if (_shouldRecalculate)
        //        RecalculateFileTotals();

        //    WriteToStream(streamWriter, NineRecord.WriteAsText(), false);

        //    // write extra fillers so block count is even at 10
        //    for (int i = 0; i < ((NineRecord.BlockCount * 10) - _fileLineCount); i++)
        //    {
        //        WriteToStream(streamWriter, new string('9', 94), false);
        //    }
        //}

        //private void WriteToStream(StreamWriter streamWriter, string text, bool incrementLineCount = true)
        //{
        //    // we track line nums in order to use the block fillers of 9999's at EOF
        //    if (incrementLineCount)
        //        _fileLineCount++;
            
        //    streamWriter.WriteLine(text);
        //}

        //private void RecalculateFileTotals()
        //{
        //    NineRecord.BatchCount = BatchRecordList.Count;
        //    NineRecord.BlockCount = (int)Math.Ceiling(_fileLineCount / 10.0);
        //    NineRecord.EntryAddendaCount = BatchRecordList.Select(x => x.SixRecordList.Count()).Sum();
        //    NineRecord.EntryHash = BatchRecordList.Select(x => x.EightRecord.EntryHash).Sum();
        //    NineRecord.TotalCreditEntryDollarAmount = BatchRecordList.Select(x => x.SixRecordList.Where(y => DataFormatHelper.CreditCodes.Contains(y.TransactionCode)).Select(x => x.Amount).Sum()).Sum();
        //    NineRecord.TotalDebitEntryDollarAmount = BatchRecordList.Select(x => x.SixRecordList.Where(y => DataFormatHelper.DebitCodes.Contains(y.TransactionCode)).Select(x => x.Amount).Sum()).Sum();
        //}

        //public void SaveFileToS3(string key)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OutputFileToConsole()
        //{
        //    _fileLineCount++;
        //    OneRecord.WriteToConsole();

        //    for (int i = 0; i < BatchRecordList.Count; i++)
        //    {
        //        if (_shouldRecalculate)
        //            BatchRecordList[i].RecalculateTotals(i + 1);

        //        _fileLineCount++;
        //        BatchRecordList[i].WriteToConsole();

        //        foreach (var batchDetailRecord in BatchRecordList[i].SixRecordList)
        //        {
        //            _fileLineCount++;
        //            batchDetailRecord.WriteToConsole();

        //            if (batchDetailRecord.AddendaRecord != null)
        //            {
        //                _fileLineCount++;
        //                batchDetailRecord.AddendaRecord.WriteToConsole();
        //            }
        //        }

        //        _fileLineCount++;
        //        BatchRecordList[i].EightRecord.WriteToConsole();
        //    }

        //    // need to increment line count before the recalc to ensure the block count is correct
        //    _fileLineCount++;
        //    if (_shouldRecalculate)
        //        RecalculateFileTotals();

        //    NineRecord.WriteToConsole();

        //    // write extra fillers so block count is even at 10
        //    for (int i = 0; i < ((NineRecord.BlockCount * 10) - _fileLineCount); i++)
        //    {
        //       new string('9', 94);
        //    }
        //}
    }
}
