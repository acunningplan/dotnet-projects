namespace TravelBug.Infrastructure.PhotoLogic
{
    public class PhotoUploadResponse
    {
        public int Status { get; set; }
        public bool Success { get; set; }
        public ResponseData Data { get; set; }
    }

    public class ResponseData
    {
        public string Id { get; set; }
        public string Link { get; set; }
        public string DeleteHash { get; set; }
    }
}
