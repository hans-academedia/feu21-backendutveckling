using WebApi.Models.Data;

namespace WebApi.Services
{
    public class UserManager
    {
        private readonly DataContext _context;

        public UserManager(DataContext context)
        {
            _context = context;
        }



    }
}


/*   
        DataContext _context = new DataContext();
 
        Dependency Injection
        - singleton         en instans i hela vår applikation, alla får exakt samma listor och uppgifter (undvik)
        - scoped            en ny instans per kontroller/service alla får olika listor och uppgifter
        - transient         en ny instans för varje sak jag gör samma sak som var _context = new DataContext();
*/