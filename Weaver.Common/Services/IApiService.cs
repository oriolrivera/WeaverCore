 namespace Weaver.Common.Services
{
    using System.Threading.Tasks;
    using Models;

    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string path);

        Task<Response> PostAsync<T>(string path, T model);
    }
}
