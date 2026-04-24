namespace MiPrimerAPI.Models
{
    // DTO simplificado que devolvemos al cliente (solo los campos relevantes)
    public class UserResponse
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Empresa { get; set; } = string.Empty;
        public string Sitio { get; set; } = string.Empty;
    }
}
