public class Request
{
    public Auth auth { get; set; }
    public string method { get; set; }
    public Header[] header { get; set; }
    public Url url { get; set; }
    public Body body { get; set; }
}
