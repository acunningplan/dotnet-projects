namespace TravelBug.Infrastructure.PhotoLogic
{
  public class PhotoUploadResult
  {
    public PhotoUploadResult(PhotoUploadResponse responseObject)
    {
      Url = responseObject.Data.Link;
      Id = responseObject.Data.Id;
    }
    // public string PublicId { get; set; }
    public string Url { get; set; }
    public string Id { get; set; }
  }
}