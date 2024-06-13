using Microsoft.Extensions.DependencyInjection;

namespace Ops.Services.Library.Mediator;

public class MediatorContext : IMediator
{
  private readonly IServiceProvider _provider;

  public MediatorContext(IServiceProvider provider)
  {
    _provider = provider;
  }

  public Task<TResult> Send<TRequest, TResult>(TRequest request)
    where TRequest : IRequest<TResult>
  {
    var scope = _provider.CreateScope();
    var handler = scope.ServiceProvider.GetRequiredService<IRequestHandler<TRequest, TResult>>();
    return handler.Handle(request);
  }
}
