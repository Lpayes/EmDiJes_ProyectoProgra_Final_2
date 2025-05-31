using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

public class ServicioOpenAI
{
    private readonly HttpClient _httpClient;
    private readonly string _model;

    public ServicioOpenAI(string apiKey, string model)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        _model = model;
    }

    public async Task<string> ObtenerRespuestaAsync(string prompt)
    {
        var requestBody = new
        {
            model = _model,
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };

        var response = await _httpClient.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestBody);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al consultar IA: {response.StatusCode}. Detalle: {error}");
        }

        var jsonResponse = await response.Content.ReadFromJsonAsync<JsonElement>();

        var mensaje = jsonResponse
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return mensaje;
    }
}