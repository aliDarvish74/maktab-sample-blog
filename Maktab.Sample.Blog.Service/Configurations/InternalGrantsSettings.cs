namespace Maktab.Sample.Blog.Service.Configurations;

public class InternalGrantsSettings
{
    public List<Grant> Grants { get; set; }
}

public class Grant
{
    public string ServiceName { get; set; }
    public string Credentials { get; set; }
    public string Password { get; set; }
}