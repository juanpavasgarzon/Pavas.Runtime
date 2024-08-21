namespace Pavas.Runtime.ApplicationContext;

public enum ApplicationState
{
    Starting = 0,
    Running = 1,
    Idle = 2,
    Stopping = 3,
    Stopped = 4,
    Maintenance = 5,
    Error = 6
}