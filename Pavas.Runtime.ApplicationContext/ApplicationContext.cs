using System.Globalization;

namespace Pavas.Runtime.ApplicationContext;

public sealed class ApplicationContext
{
    public string ApplicationName { get; set; } = "Anonymous";
    public Version ApplicationVersion { get; set; } = new();
    public ApplicationBuildMode BuildMode { get; set; } = ApplicationBuildMode.Release;
    public string BuildModeName => BuildMode.ToString();
    public ApplicationEnvironment Environment { get; set; } = ApplicationEnvironment.Develop;
    public string EnvironmentName => Environment.ToString();
    public Dictionary<string, string> EnvironmentVariables { get; set; } = new();
    public string BaseUrl { get; set; } = string.Empty;
    public DateTime StartTime { get; set; } = DateTime.UtcNow;
    public Guid InstanceId { get; set; } = Guid.NewGuid();
    public ApplicationState CurrentState { get; set; } = ApplicationState.Running;
    public int RequestCount { get; set; }
    public DateTimeFormatInfo DateTimeFormat { get; set; } = new();
    public DateTime DeploymentDate { get; set; } = DateTime.UtcNow;
    public Dictionary<string, object> SharedCache { get; set; } = new();
    public Dictionary<string, object> GlobalObjects { get; set; } = new();

    public int IncreaseRequestCount() => RequestCount += 1;
}