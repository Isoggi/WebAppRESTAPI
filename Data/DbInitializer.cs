
using WebAppRESTAPI.Function;

namespace WebAppRESTAPI.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, InitializeAppData initializeAppData)
        {
            context.Database.EnsureCreated();

            //check for users
            if (context.Users.Any())
            {
                return; //if user is not empty, DB has been seed
            }

            //init app data
            await initializeAppData.Run();
        }
    }
}
