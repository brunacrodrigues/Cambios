using Cambios.Modelos;
using System.Net;

namespace Cambios.Servicos
{
    public class NetworkService
    {
        public async Task <Response> CheckConnection()
        {            
            var client = new HttpClient();

            try
            {
                //using (client.OpenRead("http://clients3.google.com/generate_204"))
                //{
                //    return new Response
                //    {
                //        IsSuccess = true,
                //    };
                //}

                var response = await client.GetAsync("http://clients3.google.com/generate_204");
                               
                return new Response
                {
                    IsSuccess = true,
                };           

            }
            catch
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Configure a sua ligação à Internet",
                };
            }
        }
    }
}
