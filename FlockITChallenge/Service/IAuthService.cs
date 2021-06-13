using FlockITChallenge.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlockITChallenge.Service
{
    public interface IAuthService
    {
        public Task<string> getAuth(UserEntitie user, ILogService _logService);
    }
}
