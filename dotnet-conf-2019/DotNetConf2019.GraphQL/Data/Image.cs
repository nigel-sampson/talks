namespace DotNetConf2019.GraphQL.Data
{
    public class Image
    {
        public int Id { get; set; }

        public ImageSize Size { get; set; }

        public string Url { get; set; }

        public int PostId { get; set; }
    }
}
