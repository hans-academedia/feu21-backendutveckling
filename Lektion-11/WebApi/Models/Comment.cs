namespace WebApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
        public DateTime Created { get; set; }
        public int UserId { get; set; }
        public int IssueId { get; set; }
    }
}
