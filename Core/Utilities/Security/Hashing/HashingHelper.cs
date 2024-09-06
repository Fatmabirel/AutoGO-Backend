using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        // password değerini alır ve passwordHash ile passwordSalt döndürür
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) //HmacSha ile şifrelenir
            {
                passwordSalt = hmac.Key; // salt için Key kullanılır
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // şifre hashlenir
            }
        }

        // password değerini gelen passwordHash ve passwordSalt ile karşılaştırarak şifrenin doğru olup olmadığını kontrol eder
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // Yeni hash oluşturuluyor
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])// Hash'ler karşılaştırılıyor
                    {
                        return false; // Eğer eşleşmezse false döner
                    }
                }
                return true;  // Eğer eşleşirse true döner
            }
        }
    }
}
