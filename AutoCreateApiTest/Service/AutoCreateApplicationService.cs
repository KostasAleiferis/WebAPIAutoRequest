using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoCreateApiTest.Models;
using Newtonsoft.Json;

namespace AutoCreateApiTest.Service
{
    public class AutoCreateApplicationService : IAutoCreateApplicationService
    {
        public async Task<CreateApplicationResponse> CreateApplication(CreateApplicationModel userData, CancellationToken cancellationToken)
        {
            CreateApplicationResponse responseModel = new CreateApplicationResponse();

            try
            {
                var httpRequestMessage = new HttpRequestMessage

                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("YourServerUri"),
                    Content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json")
                };

                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.SendAsync(httpRequestMessage);

                if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();

                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    throw new ApplicationException($"inner exception : {await response.Content.ReadAsStringAsync()}");
                }

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        responseModel = JsonConvert.DeserializeObject<CreateApplicationResponse>(await response.Content.ReadAsStringAsync());
                    }
                    catch (Exception e)
                    {
                        throw new ApplicationException("Failed while deserializing the object of a not successful response", e);
                    }
                }
                else
                {
                    throw new ApplicationException($" Wrong response with status {response.StatusCode} , {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return responseModel;
        }
    }
}
