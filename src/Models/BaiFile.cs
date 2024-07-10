using FastBAI.Services;

namespace ACH_Transform.BaiFileProcessor.Models
{
    public class BaiFile
    {
        public FileHeaderRecord FileHeader = new();
        public FileTrailerRecord FileTrailer = new();

        public BaiFile()
        {
        }

        /// <summary>
        /// Breaks file into objects, based on the NACHA file specification.
        /// </summary>
        /// <exception cref="AchFileReadingException">Thrown when the file is not in the correct format.</exception></exception>
        public static async Task<BaiFile> Read(string filePath, CancellationToken cancellationToken = default)
        {
            BaiFileService service = new();
            return await Task.Run(() => service.ProcessFile(filePath));
        }
    }
}
