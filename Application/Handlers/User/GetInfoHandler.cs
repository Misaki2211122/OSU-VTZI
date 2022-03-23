using Application.Abstractions.Database;
using Application.Domains.Entities;
using Application.Domains.Requests.User;
using Application.Domains.Responses.User;
using MediatR;

namespace Application.Handlers.User;

public class GetInfoHandler: IRequestHandler<GetInfoRequest, GetInfoResponse>
{
    private readonly IRepository<AdminEntity> _repositoryUser;
    //private readonly IMapper _mapper;   


    public GetInfoHandler(IRepository<AdminEntity> repositoryUser)
    {
        _repositoryUser = repositoryUser;
    }

    public async Task<GetInfoResponse> Handle(GetInfoRequest request, CancellationToken cancellationToken)
    {
        var res = 1;
        
        if (res == 1)
            return new GetInfoResponse() {Success = true};
        else
            return new GetInfoResponse()
                {Success = false, ErrorMessage = "Не удалось удалить пользователя! Попробуйте позже.."};
    }
}