using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encyrption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) // bizim için JWT'nin oluşturulabilmesi için 
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        } 
    }
}
