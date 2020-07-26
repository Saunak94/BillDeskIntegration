
using System.Threading.Tasks;

namespace BillDesk
{
    public interface Iintegration
    {
        Task<string> CreateHMAC();

        Task<string> CreateHMAC(DataEntryModel dataEntry);
    }
}
