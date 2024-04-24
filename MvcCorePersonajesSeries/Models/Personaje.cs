using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MvcCorePersonajesSeries.Models
{
    public class Personaje
    {
        [JsonProperty("idPersonaje")]
        public int IdPersonaje { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("imagen")]
        public string Imagen { get; set; }
        [JsonProperty("serie")]
        public string Serie { get; set; }
    }
}
