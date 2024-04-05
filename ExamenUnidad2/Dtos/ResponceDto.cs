using System.Text.Json.Serialization;

namespace ExamenUnidad2.Dtos
{
    public class ResponceDto<T>
    {
        public bool Status { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
