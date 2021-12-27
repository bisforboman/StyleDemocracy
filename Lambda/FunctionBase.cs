using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace StyleDemocracy.Lambda
{
    public abstract class FunctionBase<TCommand> where TCommand : INotification
    {
        private readonly INotificationHandler<TCommand> _commandHandler;

        protected FunctionBase(IServiceProvider provider)
        {
            _commandHandler = provider.GetRequiredService<INotificationHandler<TCommand>>();
        }

        [LambdaSerializer(typeof(CamelCaseLambdaJsonSerializer))]
        public Task Invoke(TCommand command, ILambdaContext lambdaContext)
        {
            var source = new CancellationTokenSource(lambdaContext.RemainingTime);
            return _commandHandler.Handle(command, source.Token);
        }
    }
}
