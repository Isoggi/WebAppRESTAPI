using WebAppRESTAPI.Models;

namespace WebAppRESTAPI.Repository.Interface
{
    public interface IBaseRepository<T>
    {
        public Task<List<T>> GetList(string keyword = null);
        public Task<T> GetDetail(string id);
        public Task<T> Create(T company);
        public Task<T> Update(T company);
        public Task<bool> Delete(string id);
    }
}
