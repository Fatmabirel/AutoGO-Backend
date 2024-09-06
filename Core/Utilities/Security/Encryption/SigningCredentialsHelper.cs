using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper // imzalama bilgileri (SigningCredentials) oluşturan bir yardımcı sınıfı (SigningCredentialsHelper) tanımlar. 
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            // SigningCredentials sınıfı, token imzalama işlemi için gerekli olan bilgileri içerir.
            // SecurityKey: Token'ın güvenliği için kullanılacak anahtar (simetrik veya asimetrik).
            // SecurityAlgorithms.HmacSha512Signature: İmzalama işlemi için kullanılacak algoritma.
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
