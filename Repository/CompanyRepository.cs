using WebAppRESTAPI.Models;
using WebAppRESTAPI.Repository.Interface;

namespace WebAppRESTAPI.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        public CompanyRepository() { }

        public async Task<List<Company>> GetList(string keyword = null)
        {
            List<Company> result = new List<Company>();
            return result;
        }

        public async Task<Company> GetDetail(string id)
        {
            Company result = new Company();
            return result;
        }
        public async Task<Company> Create(Company company)
        {
            Company result = new Company();
            return result;
        }
        public async Task<Company> Update(Company company)
        {
            Company result = new Company();

            Func<Company, Company> Test = (input) =>
            {
                Company result = new Company();
                return result;
            };
            return result;
        }
        public async Task<bool> Delete(string id)
        {
            bool result = false;
            return result;;
        }
    }
}

