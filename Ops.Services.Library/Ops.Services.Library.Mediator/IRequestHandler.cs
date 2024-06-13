namespace Ops.Services.Library.Mediator;

public interface IRequest<TResult>
{
}

public interface IRequestHandler<TRequest, TResult>
  where TRequest : IRequest<TResult>
{
  Task<TResult> Handle(TRequest request);
}
