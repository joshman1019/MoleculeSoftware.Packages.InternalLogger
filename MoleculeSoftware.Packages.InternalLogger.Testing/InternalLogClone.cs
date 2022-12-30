namespace MoleculeSoftware.Packages.InternalLogger.Testing;

/// <summary>
/// Mockup of the <see cref="IInternalLog"/> model that can be passed to the logging system
/// </summary>
public class InternalLogClone : IInternalLog
{
    public int Id { get; set; }
    public LogTypes LogType { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? AdditionalInformation { get; set; }

    public InternalLogClone(string title, string message, LogTypes type, string? addtlInformation = null)
    {
        Title = title;
        Message = message;
        LogType = type; 
        AdditionalInformation = addtlInformation;
    }
}
