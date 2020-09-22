using System.Threading;
using System.Threading.Tasks;
using AutoCreateApiTest.Models;

namespace AutoCreateApiTest
{
    public interface IAutoCreateApplicationService
    {
        Task<CreateApplicationResponse> CreateApplication(
          CreateApplicationModel userData, CancellationToken cancellationToken);
    }
}
