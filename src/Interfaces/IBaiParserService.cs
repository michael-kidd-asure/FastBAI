using ACH_Transform.BaiFileProcessor.Models;

namespace ACH_Transform.BaiFileProcessor.Interfaces
{
    public interface IBaiParserService
    {
        public BaiBaseRecord ParseRecord(string data);
    }
}
