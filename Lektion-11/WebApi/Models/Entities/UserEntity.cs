namespace WebApi.Models.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    
        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<IssueEntity> Issues { get; set; }
    }
}
