namespace Ops.Services.Library.Mediator;

public interface IMediator
{
  Task<object> Send<TRequest>(TRequest request) where TRequest : class;
}
