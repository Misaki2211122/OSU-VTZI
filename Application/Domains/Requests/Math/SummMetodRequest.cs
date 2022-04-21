using Application.Domains.Responses.Math;
using MediatR;

namespace Application.Domains.Requests.Math;

public class SummMetodRequest : IRequest<SummMetodResponse>
{
    public int a { get; set; }
    
    public int b { get; set; }
}