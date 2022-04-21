using Application.Domains.Requests.Math;
using Application.Domains.Responses.Math;
using MediatR;

namespace Application.Handlers.Math;

public class SummMetodHandler: IRequestHandler<SummMetodRequest, SummMetodResponse>
{
    //private readonly IRepository<AdminEntity> _repositoryUser;
    //private readonly IMapper _mapper;   


    public SummMetodHandler()
    {

    }

    public async Task<SummMetodResponse> Handle(SummMetodRequest request, CancellationToken cancellationToken)
    {
        int res = request.a + request.b;
        
        if (res != null)
            return new SummMetodResponse() {Success = true, c = res};
        else
            return new SummMetodResponse()
                {Success = false, ErrorMessage = "Не удалось удалить пользователя! Попробуйте позже.."};
    }
}