using System;
using System.Security.Cryptography;

namespace pt12lolMvc4Application.Web.Services
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        RandomNumberGenerator _generator;
        readonly Func<RandomNumberGenerator> _generatorInitializer; 

        public AuthenticationHelper()
        {
            _generatorInitializer = () => new RNGCryptoServiceProvider();
        }

        public AuthenticationHelper(Func<RandomNumberGenerator> generatorInitializer)
        {
            _generatorInitializer = generatorInitializer;
        }

        public string CreateSalt()
        {
            using (_generator = _generatorInitializer())
            {
                var byteArr = new byte[32];
                _generator.GetBytes(byteArr);
                return Convert.ToBase64String(byteArr);
            }
        }
    }
}