using ACH_Transform.BaiFileProcessor.Models;

namespace ACH_Transform.BaiFileProcessor.Services
{
    internal interface IBaiFileService
    {
        public BaiFile ProcessFile(string filePath);
    }
}
