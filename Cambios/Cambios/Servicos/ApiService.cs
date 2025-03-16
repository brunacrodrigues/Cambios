using Cambios.Modelos;
using Newtonsoft.Json;

namespace Cambios.Servicos
{
    public class ApiService
    {
        public async Task<Response> GetRates(string urlBase, string controller)
        {
            try
            {
                // fazer ligação externa via http
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);

                var response = await client.GetAsync(controller);

                var result = await response.Content.ReadAsStringAsync(); // carregar resultados no formato de um string para o objeto result


                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var rates = JsonConvert.DeserializeObject<List<Rate>>(result);


                return new Response
                {
                    IsSuccess = true,
                    Result = rates,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
