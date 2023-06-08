namespace intuito.application.models.DTOs
{
    public class DtoResponseError
    {
        public int code { get; set; }
        public string? message { get; set; }
        public bool error { get; set; }
    }
}
