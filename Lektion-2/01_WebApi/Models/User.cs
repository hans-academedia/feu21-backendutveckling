using System.Security.Cryptography;
using System.Text;

namespace _01_WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }


        public void GeneratePassword(string password)
        {
            using var hmac = new HMACSHA512();
            PasswordSalt = hmac.Key;
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool ValidatePassword(string password)
        {
            using var hmac = new HMACSHA512(PasswordSalt);
            var _hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < PasswordHash.Length; i++)
            {
                if (_hash[0] != PasswordHash[0])
                    return false;
            }

            return true;
        }

    }
}
/* 
    function generatePasword(password) {

    }
 
    function validatePassword(password) {

        if(_hash[0] != PasswordHash[0])
            return "blahahaa"

        return true
    }
 
*/