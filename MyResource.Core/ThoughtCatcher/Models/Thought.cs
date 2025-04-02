namespace MyResource.Core.ThoughtCatcher.Models
{
    public class Thought
    {
        public int ThoughtId { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
