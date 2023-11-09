namespace GADistribuidora.Domain.Entities
{
    public abstract class BaseClass
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public void GenerateId() 
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        public void DeleteMe() 
        {
            Deleted = true;
            UpdateMe();
        }

        public void UpdateMe() => UpdatedAt = DateTime.UtcNow;
    }
}
