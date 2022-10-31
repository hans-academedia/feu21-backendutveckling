namespace WebApi.Sql.Models
{
    public class IssueUpdateRequest
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public int StatusId { get; set; }
    }
}
