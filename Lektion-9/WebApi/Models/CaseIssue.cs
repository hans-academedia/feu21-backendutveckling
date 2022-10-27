namespace WebApi.Models
{
    public enum CaseStatus
    {
        NotStarted,
        Processing,
        Completed
    }

    public class CaseIssue
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Subject { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
        public CaseStatus Status { get; set; } = CaseStatus.NotStarted;
    }
}
