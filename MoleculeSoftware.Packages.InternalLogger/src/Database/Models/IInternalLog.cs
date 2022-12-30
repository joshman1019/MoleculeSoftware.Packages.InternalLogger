namespace MoleculeSoftware.Packages.InternalLogger;

public interface IInternalLog
{
    int Id { get; set; }
    LogTypes LogType { get; set; }
    string Message { get; set; }
    string Title { get; set; }
    string? AdditionalInformation { get; set; }
}