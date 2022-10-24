using System.Security.Cryptography;
using System.Text;

namespace _00_Repetition.WebApiEFC.Models.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }


        public void GenerateSecurePassword(string password)
        {
            using var hmac = new HMACSHA512();
            Salt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
