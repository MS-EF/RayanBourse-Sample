using Microsoft.AspNetCore.Http;
using System.Linq;

namespace API.Helper
{
    public static class ExtentionMethods
    {
        public static string GetJWTTokenFromRequest(this HttpRequest request)
        {
            var authorizationHeader = request.Headers["Authorization"].FirstOrDefault();
            if (authorizationHeader == null)
            {
                return null;
            }

            var token = authorizationHeader.Replace("Bearer ", "");

            return token;
        }
    }
}
