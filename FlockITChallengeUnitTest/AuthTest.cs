using FlockITChallenge.Entitie;
using FlockITChallenge.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlockITChallengeUnitTest
{
    [TestClass]
    public class TestAuth
    {

        [TestMethod]
        public async Task GetReturnsProduct()
        {
            GeoRefRepository respository = new GeoRefRepository();
            StateEntitie state = new StateEntitie();
            state.State = "tierra del fuego";


            LatLonEntitie latLon = new LatLonEntitie();
            latLon.Lat = -82.52151781221;
            latLon.Long = -50.7427486049785;

            List<object> list = new List<object>();
            list.Add(latLon);

            var geoRefStateExpected = JsonConvert.SerializeObject(list);

            List<object> result = await respository.GetGeoRefJson(state);
            string geoRefState = JsonConvert.SerializeObject(result);



            Assert.AreEqual(geoRefStateExpected, geoRefState);
        }

    }

}
