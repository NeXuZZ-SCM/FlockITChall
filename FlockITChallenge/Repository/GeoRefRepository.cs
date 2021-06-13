using FlockITChallenge.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace FlockITChallenge.Repository
{
    public class GeoRefRepository
    {
        public async Task<List<object>> GetGeoRefJson(StateEntitie state)
        {
            List<object> list = new List<object>();
            string baseUrl = $"https://apis.datos.gob.ar/georef/api/provincias?nombre={state.State}";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                GeoRefEntitie.Root geoRefState = new GeoRefEntitie.Root();
                                geoRefState = JsonConvert.DeserializeObject<GeoRefEntitie.Root>(data);

                                LatLonEntitie latLon = new LatLonEntitie();
                                latLon.Lat = geoRefState.provincias[0].centroide.lat;
                                latLon.Long = geoRefState.provincias[0].centroide.lon;
                                list.Add(latLon);
                                return list;
                            }
                            else
                            {
                                return list;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string exception = $"Manejar la excepcion segun corresponda {ex.Message}";
                return list;
            }
        }
    }
}
