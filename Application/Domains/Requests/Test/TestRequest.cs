using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domains.Responses.Test;
using MediatR;

namespace Application.Domains.Requests.Test;

public class TestRequest : IRequest<TestResponse>
{
    public string TestData { get; set; }
}

