using System.Globalization;

namespace Pavas.Runtime.ApplicationContext;

public sealed class ApplicationContext
{
    public string ApplicationName { get; set; } = "Anonymous";
    public Version ApplicationVersion { get; set; } = new("v1.0");
    public ApplicationBuildMode BuildMode { get; set; } = ApplicationBuildMode.Release;
    public CultureInfo CultureInfo { get; set; } = new("en-US");
    public ApplicationEnvironment EnvironmentName { get; set; } = ApplicationEnvironment.Develop;
    public Dictionary<string, string> EnvironmentVariables { get; set; } = new();
    public string BaseUrl { get; set; } = string.Empty;
    public DateTime StartTime { get; set; } = DateTime.UtcNow;
    public Guid InstanceId { get; set; } = Guid.NewGuid();
    public ApplicationState CurrentState { get; set; } = ApplicationState.Running;
    public int RequestCount { get; set; } = 0;
    public TimeSpan AverageResponseTime { get; set; } = TimeSpan.Zero;
    public LanguageCode DefaultLanguage { get; set; } = LanguageCode.EnUs;
    public List<LanguageCode> SupportedLanguages { get; set; } = [LanguageCode.EnUs];
    public DateTimeFormatInfo DateTimeFormat { get; set; } = new();
    public DateTime DeploymentDate { get; set; } = DateTime.UtcNow;
    public Dictionary<string, object> SharedCache { get; set; } = new();
    public Dictionary<string, object> GlobalObjects { get; set; } = new();
}