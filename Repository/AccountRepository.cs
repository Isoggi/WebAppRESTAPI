using WebAppRESTAPI.Models;
using WebAppRESTAPI.Repository.Interface;

namespace WebAppRESTAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository() { }

        public async Task<List<Account>> GetList(string keyword = null)
        {
            List<Account> result = new List<Account>();
            return result;
        }

        public async Task<Account> GetDetail(string id)
        {
            Account result = new Account();
            return result;
        }
        public async Task<Account> Create(Account account)
        {
            Account result = new Account();
            return result;
        }
        public async Task<Account> Update(Account company)
        {
            Account result = new Account();

            Func<Account, Account> Test = (input) =>
            {
                Account resAcc = new Account();
                return resAcc;
            };
            return result;
        }
        public async Task<bool> Delete(string id)
        {
            bool result = false;
            return result; ;
        }
    }
}
