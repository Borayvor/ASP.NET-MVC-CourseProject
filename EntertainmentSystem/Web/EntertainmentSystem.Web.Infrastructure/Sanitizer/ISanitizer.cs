namespace EntertainmentSystem.Web.Infrastructure.Sanitizer
{
    public interface ISanitizer
    {
        string Sanitize(string html);
    }
}
