 namespace Weaver.Common.Services
{
    using System.Threading.Tasks;
    using Models;

    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string path);

        Task<Response> PostAsync<T>(string path, T model);

        Task<Response> PutAsync<T>(string path, int id, T model);

        Task<Response> DeleteAsync(string path, int id);
    }
}
