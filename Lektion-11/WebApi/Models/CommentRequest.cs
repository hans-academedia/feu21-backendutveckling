namespace WebApi.Models
{
    public class CommentRequest
    {
        public string Message { get; set; } = null!;
        public int UserId { get; set; }
        public int IssueId { get; set; }
    }
}
