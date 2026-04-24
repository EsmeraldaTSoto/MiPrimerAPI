using System.Text.Json;
using MiPrimerAPI.Models;

namespace MiPrimerAPI.Services
{
    public class ExternalApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://jsonplaceholder.typicode.com";

        // JsonSerializer opciones: acepta nombres en camelCase de la API externa
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        // Obtiene todos los usuarios y los convierte a UserResponse (BONUS deserialización)
        public async Task<List<UserResponse>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetAsync("/users");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            // Deserializamos al modelo completo User
            var users = JsonSerializer.Deserialize<List<User>>(json, _jsonOptions)
                        ?? new List<User>();

            // Mapeamos a UserResponse (solo campos que nos interesan)
            return users.Select(MapToResponse).ToList();
        }

        // Obtiene un solo usuario por ID
        public async Task<UserResponse?> GetUserByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/users/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<User>(json, _jsonOptions);

            return user is null ? null : MapToResponse(user);
        }

        // Obtiene los posts de un usuario por su ID
        public async Task<string> GetPostsByUserIdAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"/posts?userId={userId}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        // Convierte User → UserResponse
        private static UserResponse MapToResponse(User user) => new UserResponse
        {
            Id            = user.Id,
            NombreCompleto = user.Name,
            Email         = user.Email,
            Ciudad        = user.Address?.City ?? string.Empty,
            Empresa       = user.Company?.Name ?? string.Empty,
            Sitio         = user.Website
        };
    }
}
