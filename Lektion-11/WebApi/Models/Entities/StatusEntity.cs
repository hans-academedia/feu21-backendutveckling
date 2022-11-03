namespace WebApi.Models.Entities
{
    public class StatusEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<IssueEntity> Issues { get; set; }
    }
}
