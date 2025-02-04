﻿using System.Text.Json;
using System.Text.Json.Serialization;
using MovidaBrcSharedLibrary.Contracts;
using MovidaBrcSharedLibrary.Models;
using MovidaBrcSharedLibrary.Responses;

namespace MovidaBrcClient.Services
{
    public class ClientServices(HttpClient httpClient) : IFiesta
    {
        private const string BaseUrl = "api/fiesta";

        private static string SerializeObj(object modelObject) => JsonSerializer.Serialize(modelObject, JsonOptions());
        private static T DeserializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;
        private static StringContent GenerateStringContent(string serializedObj) => new(serializedObj, System.Text.Encoding.UTF8, "application/json");
        private static IList<T> DeserializeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IList<T>>(jsonString, JsonOptions())!;
        private static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
            };
        }

        public async Task<ServiceResponse> AddFiesta(Fiesta model)
        {
            try
            {
                var response = await httpClient.PostAsync(BaseUrl, GenerateStringContent(SerializeObj(model)));

                if (!response.IsSuccessStatusCode)
                    return new ServiceResponse(false, "Error. Vuelva a intentar en unos momentos...");

                var apiResponse = await response.Content.ReadAsStringAsync();
                return DeserializeJsonString<ServiceResponse>(apiResponse);
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, $"Excepción: {ex.Message}");
            }
        }

        public async Task<List<Fiesta>> GetAllFiestas()
        {
            var response = await httpClient.GetAsync($"{BaseUrl}");
            if (!response.IsSuccessStatusCode)
                return null!;
            var result = await response.Content.ReadAsStringAsync();
            return [.. DeserializeJsonStringList<Fiesta>(result)];
        }
    }
}
