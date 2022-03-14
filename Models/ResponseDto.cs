using MySqlConnector.Logging;

namespace test.Models
{
    public class ResponseDto
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}