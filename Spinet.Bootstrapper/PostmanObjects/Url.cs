public class Url
{
    public string raw { get; set; }
    public string protocol { get; set; }
    public string[] host { get; set; }
    public string[] path { get; set; }
    public Query[] query { get; set; }
}
