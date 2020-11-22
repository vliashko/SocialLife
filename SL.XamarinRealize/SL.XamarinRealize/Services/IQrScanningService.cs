using System.Threading.Tasks;

namespace SL.XamarinRealize.Services
{
    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
