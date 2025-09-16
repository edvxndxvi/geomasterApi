namespace geomasterApi.DTO
{
    public class ValidacaoFormasDTO
    {
        public required FormaRequestDTO FormaExterna { get; set; }

        public required FormaRequestDTO FormaInterna { get; set; }
    }
}