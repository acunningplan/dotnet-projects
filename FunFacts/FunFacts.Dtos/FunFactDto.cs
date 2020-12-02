namespace FunFacts.Dtos
{
    public class FunFactDto
    {
        public string Description { get; set; }
        public virtual User Author { get; set; }
        public virtual TopicDto Topic { get; set; }
    }
}
