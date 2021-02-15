using System.Threading;
using System.Threading.Tasks;

namespace TwitterStatsBlazorApp.Server.Interfaces
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}