namespace FunFacts.Entities.Images
{
    public class FunFactImage : Image
    {
        public virtual FunFact FunFact { get; set; }
    }
}
