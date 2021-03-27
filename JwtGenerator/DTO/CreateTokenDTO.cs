using System.Collections.Generic;

namespace JwtGenerator.DTO
{
    public class CreateTokenDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Time { get; set; }
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
