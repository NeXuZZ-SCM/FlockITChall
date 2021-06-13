using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlockITChallenge.Entitie
{
    public class GeoRefEntitie
    {
        public class Parametros
        {
            public string nombre { get; set; }
        }

        public class Centroide
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }

        public class Provincia
        {
            public Centroide centroide { get; set; }
            public string id { get; set; }
            public string nombre { get; set; }
        }

        public class Root
        {
            public int cantidad { get; set; }
            public int inicio { get; set; }
            public Parametros parametros { get; set; }
            public List<Provincia> provincias { get; set; }
            public int total { get; set; }
        }
    }
}
