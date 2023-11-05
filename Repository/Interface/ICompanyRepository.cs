using System.ComponentModel;
using WebAppRESTAPI.Models;

namespace WebAppRESTAPI.Repository.Interface
{
    public interface ICompanyRepository
    {
        public Task<List<Company>> GetList(string keyword = null);
        public Task<Company> GetDetail(string id);
        public Task<Company> Create(Company company);
        public Task<Company> Update(Company company);
        public Task<bool> Delete(string id);
    }
}
