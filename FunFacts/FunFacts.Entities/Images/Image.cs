namespace FunFacts.Entities
{
    // An Imgur image object
    public class Image : Base
    {
        public string ImgurId { get; set; } = "";
        public string DeleteHash { get; set; } = "";
        public string Url { get; set; } = "";
        public string Description { get; set; } = "";
    }
}