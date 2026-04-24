using Microsoft.AspNetCore.Mvc;
using MiPrimerAPI.Models;
using MiPrimerAPI.Services;

namespace MiPrimerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalController : ControllerBase
    {
        private readonly ExternalApiService _externalService;

        public ExternalController(ExternalApiService externalService)
        {
            _externalService = externalService;
        }

        // GET: api/external/users
        // Devuelve todos los usuarios de jsonplaceholder (como UserResponse simplificado)
        [HttpGet("users")]
        public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
        {
            try
            {
                var users = await _externalService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(503, $"Error al conectar con la API externa: {ex.Message}");
            }
        }

        // GET: api/external/users/3
        // Devuelve un usuario por ID
        [HttpGet("users/{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(int id)
        {
            try
            {
                var user = await _externalService.GetUserByIdAsync(id);

                if (user is null)
                    return NotFound($"No se encontró el usuario con Id = {id}");

                return Ok(user);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(503, $"Error al conectar con la API externa: {ex.Message}");
            }
        }

        // GET: api/external/users/3/posts
        // Devuelve todos los posts de un usuario (JSON crudo de jsonplaceholder)
        [HttpGet("users/{userId}/posts")]
        public async Task<ActionResult> GetPostsByUser(int userId)
        {
            try
            {
                var json = await _externalService.GetPostsByUserIdAsync(userId);

                // Retornamos el JSON directamente para que Postman lo vea formateado
                return Content(json, "application/json");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(503, $"Error al conectar con la API externa: {ex.Message}");
            }
        }
    }
}
