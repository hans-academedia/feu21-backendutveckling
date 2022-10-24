using _00_Repetition.WebApiEFC.Models;
using _00_Repetition.WebApiEFC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _00_Repetition.WebApiEFC.Services
{
    public class UserManager
    {
        private readonly DataContext context;

        public UserManager(DataContext context)
        {
            this.context = context;
        }


        public async Task CreateAsync(UserRequest req)
        {
            var userEntity = new UserEntity()
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Email = req.Email,
            };
            userEntity.GenerateSecurePassword(req.Password);

            context.Users.Add(userEntity);
            await context.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            try
            {
                var userEntity = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (userEntity != null)
                    return new User()
                    {
                        Id = userEntity.Id,
                        FirstName = userEntity.FirstName,
                        LastName = userEntity.LastName,
                        Email = userEntity.Email
                    };
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = new List<User>();

            try
            {
                foreach (var userEntity in await context.Users.ToListAsync())
                    users.Add(new User
                    {
                        Id = userEntity.Id,
                        FirstName = userEntity.FirstName,
                        LastName = userEntity.LastName,
                        Email = userEntity.Email
                    });
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return users;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            try
            {
                var userEntity = await context.Users.FindAsync(user.Id);
                if (userEntity != null)
                {
                    userEntity.FirstName = user.FirstName;
                    userEntity.LastName = user.LastName;
                    userEntity.Email = user.Email;

                    context.Entry(userEntity).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    user.FirstName = userEntity.FirstName;
                    user.LastName = userEntity.LastName;
                    user.Email = userEntity.Email;
                }

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return user;
        }
    }
}
