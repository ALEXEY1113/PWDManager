
namespace PWDManager.Shared.Entities
{
    public class CredentialDTO
    {
        public DateTime LastUpdated { get; set; }

        public Object? Data { get; set; }

        public CredentialDTO()
        {
            this.LastUpdated = DateTime.Now;
        }
    }
}
