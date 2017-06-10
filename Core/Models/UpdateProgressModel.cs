namespace Core.Models
{
    public class UpdateProgressModel
    {
        public UpdateState State { get; set; }

        public long CompletedBytes { get; set; }
        public long TotalBytes { get; set; }
    }
}
