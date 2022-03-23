using RestSharp;

namespace Application.Domains;

public class BaseRequest
{
    public string EndPoint { get; set; }
    public Method Method { get; set; }
    public object Body { get; set; }
    public Dictionary<string, string> Headers { get; set; }
}