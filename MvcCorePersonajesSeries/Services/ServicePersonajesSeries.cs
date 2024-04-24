using MvcCorePersonajesSeries.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace MvcCorePersonajesSeries.Services
{
    public class ServicePersonajesSeries
    {
        private MediaTypeWithQualityHeaderValue header;
        private string ApiUrl;

        public ServicePersonajesSeries(IConfiguration configuration)
        {
            this.ApiUrl =
                configuration.GetValue<string>("ApiUrls:ApiPersonajesSeries");

            this.header =
                new MediaTypeWithQualityHeaderValue("appplication/json");
        }

        #region CALL API ASYNC
        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }
        #endregion
        public async Task<List<Personaje>> GetAllPersonajes()
        {
            string request = "api/Series/Personajes";

            List<Personaje> data =
                await this.CallApiAsync<List<Personaje>>(request);

            return data;
        }

        public async Task<Personaje> GetPersonajeByIdAsync(int id)
        {
            string request = "api/Series/Personaje/" + id;
            Personaje personaje =
                await this.CallApiAsync<Personaje>(request);

            return personaje;
        }

        public async Task<List<Personaje>> GetAllPersonajesSerie(string serie)
        {
            string request = "/api/Series/PersonajesSerie/" + serie;
            List<Personaje> data =
                await this.CallApiAsync<List<Personaje>>(request);

            return data;
        }

        public async Task<Personaje> CreatePersonaje(Personaje personaje)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/Series/CreatePersonaje";

                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                Personaje model = new Personaje
                {
                    IdPersonaje = 0,
                    Nombre = personaje.Nombre,
                    Serie = personaje.Serie,
                    Imagen = personaje.Imagen,
                };

                string jsonData =
    JsonConvert.SerializeObject(model);
                StringContent content =
                    new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response =
                   await client.PostAsync(request, content);

                if (response.IsSuccessStatusCode)
                {
                    Personaje data =
                        await response.Content.ReadAsAsync<Personaje>();

                    return data;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Personaje> UpdatePersonajeAsync(Personaje personaje)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/Series/UpdatePersonaje";

                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                Personaje model = new Personaje
                {
                    IdPersonaje = personaje.IdPersonaje,
                    Nombre = personaje.Nombre,
                    Serie = personaje.Serie,
                    Imagen = personaje.Imagen,
                };

                string jsonData =
    JsonConvert.SerializeObject(model);
                StringContent content =
                    new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response =
                   await client.PutAsync(request, content);

                if (response.IsSuccessStatusCode)
                {
                    Personaje data =
                        await response.Content.ReadAsAsync<Personaje>();

                    return data;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
