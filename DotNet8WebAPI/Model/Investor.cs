namespace DotNet8WebAPI.Model
{
    public class Investor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool isActive { get; set; }
    }
}
