namespace Ops.Services.Library.Mediator;

public interface IMediator
{
  Task<TResult> Send<TRequest, TResult>(TRequest request) where TRequest : IRequest<TResult>;
}
