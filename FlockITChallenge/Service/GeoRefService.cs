using FlockITChallenge.Entitie;
using FlockITChallenge.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlockITChallenge.Service
{
    public class GeoRefService : IGeoRefService
    {
        public async Task<string> getGeoRefByState(StateEntitie state)
        {
            GeoRefRepository geoRef = new GeoRefRepository();
            List<object> list = new List<object>();
            string result = "";

            list = await geoRef.GetGeoRefJson(state);
            result = JsonConvert.SerializeObject(list);
            return result;
        }
    }
}
