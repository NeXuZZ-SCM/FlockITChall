using FlockITChallenge.Entitie;
using FlockITChallenge.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlockITChallenge.Service
{
    public class AuthService : IAuthService
    {
        public async Task<string> getAuth(UserEntitie user, ILogService _logService)
        {
            AuthRepository Auth = new AuthRepository();
            List<object> list = new List<object>();
            string result = "";

            list = await Auth.getAuthJson(user, _logService);
            result = JsonConvert.SerializeObject(list);
            return result;
        }
    }
}
