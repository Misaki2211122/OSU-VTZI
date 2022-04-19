using Application.Domains.Requests.Test;
using Application.Domains.Responses.Test;
using MediatR;

namespace Application.Handlers.Test;

public class TestMetod: IRequestHandler<TestRequest, TestResponse>
{
    //private readonly IRepository<AdminEntity> _repositoryUser;
    //private readonly IMapper _mapper;   


    public TestMetod()
    {

    }

    public async Task<TestResponse> Handle(TestRequest request, CancellationToken cancellationToken)
    {
        var res = 1;
        
        if (res == 1)
            return new TestResponse() {Success = true, TestData = request.TestData};
        else
            return new TestResponse()
                {Success = false, ErrorMessage = "Не удалось удалить пользователя! Попробуйте позже.."};
    }
}