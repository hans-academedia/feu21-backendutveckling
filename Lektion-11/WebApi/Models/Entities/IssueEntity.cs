namespace WebApi.Models.Entities
{
    public class IssueEntity
    {
        public int Id { get; set; }
        public string Subject { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int StatusId { get; set; }

        public UserEntity User { get; set; }
        public StatusEntity Status { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }

    }
}
