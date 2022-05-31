namespace Kendo.Data
{
    public interface IJwtAuthenticationManager
    {
        public string MakeNewToken(string username, string id);
        public string GetIDFromToken(string token);
    }
}
