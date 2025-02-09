using MediatR;

namespace Hemen.Infrastructure.Result;

public interface IBaseApiRequest : IRequest<BaseApiResult> {
}

public interface IBaseApiRequest<TResponse> : IRequest<BaseApiResult<TResponse>> {
}





