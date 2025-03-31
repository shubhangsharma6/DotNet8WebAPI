using System.Text.Json.Serialization;

namespace DotNet8WebAPI.Model
{
    public class InvestmentUser
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public required string Username { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public string Password { get; set; } = string.Empty;        
    }
}
