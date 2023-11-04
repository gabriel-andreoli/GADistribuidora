namespace GADistribuidora.Domain.Entities
{
    public abstract class BaseClass
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public void InitializeEntity() 
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.Now;
        }

        public void DeleteMe() 
        {
            Deleted = true;
            UpdateMe();
        }

        public void UpdateMe() => UpdatedAt = DateTimeOffset.Now;
    }
}
