using Polly;

namespace Pavas.Runtime.Outbox.Contracts;

public interface IPipelineFactory
{
    public ResiliencePipeline GetPipeline();
}