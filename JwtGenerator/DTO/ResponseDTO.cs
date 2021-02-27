namespace JwtGenerator.DTO
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public string Data { get; set; }
        public ResponseDTO()
        {
            Success = false;
            Data = null;
        }

        public ResponseDTO(bool success, string data)
        {
            Success = success;
            Data = data;
        }
    }
}
