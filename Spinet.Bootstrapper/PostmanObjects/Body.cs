public class Body
{
    public string mode { get; set; }
    public Urlencoded[] urlencoded { get; set; }
    public string raw { get; set; }
    public Formdata[] formdata { get; set; }
    public Options options { get; set; }
}
