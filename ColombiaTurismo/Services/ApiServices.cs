using System;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ColombiaTurismo.Models;
using System.Diagnostics;

namespace ColombiaTurismo.Services
{
    public class ApiServices
    {

        /// <summary>
        /// Función para obtener parametros iniciales como Tiempo por Fotografia
        /// y Cantidad de fotografias a tomar 
        /// </summary>
        /// <param name="myurl"></param>
        /// <returns></returns>
        public static async Task<List<TouristAttraction>> GetListTouristAttraction(string myurl)
        {
            try
            {
                var httpClient = new HttpClient();
                var httpMethod = HttpMethod.Get;

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(myurl),
                    Method = httpMethod
                };
                //request.Headers.Add("Authorization", Token);

                var httpResponse = await httpClient.SendAsync(request);
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    var myData = JsonConvert.DeserializeObject<List<TouristAttraction>>(result);
                    return myData;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"No fue posible conectarse {ex.Message}");
                
                return null;
            }
        }
    }

}

