using FlockITChallenge.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlockITChallenge.Service
{
    public interface IGeoRefService
    {
        public Task<string> getGeoRefByState(StateEntitie state);

    }
}
