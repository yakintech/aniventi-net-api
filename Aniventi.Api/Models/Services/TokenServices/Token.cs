namespace Aniventi.Api.Models.Services.TokenServices
{
    public class Token
    {
        public string AccessToken { get; set; }

        public string Refreshtoken { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
