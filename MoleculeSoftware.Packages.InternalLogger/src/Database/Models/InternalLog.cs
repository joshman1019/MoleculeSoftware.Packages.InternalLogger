using System.ComponentModel.DataAnnotations;

namespace MoleculeSoftware.Packages.InternalLogger;

internal class InternalLog : IInternalLog
{
    [Key]
    public int Id { get; set; } = 0; 

    /// <summary>
    /// Type of log that is being recorded
    /// NOTE    :::    Default is <see cref="LogTypes.None"/>
    /// </summary>
    public LogTypes LogType { get; set; } = LogTypes.None;

    /// <summary>
    /// Title of the log
    /// NOTE    :::    Default is empty;
    /// NOTE    :::    Required;
    /// NOTE    :::    Minimum length of 4 characters
    /// </summary>
    [Required]
    [MinLength(4)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Log message
    /// NOTE    :::    Default is empty;
    /// NOTE    :::    Required;
    /// NOTE    :::    Minimum length of 4 characters
    /// </summary>
    [Required]
    [MinLength(4)]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Any additional string information that the user would like to store. 
    /// NOTE    :::    Default is empty
    /// </summary>
    public string AdditionalInformation { get; set; } = string.Empty; 

    /// <summary>
    /// Sets the additional information property
    /// </summary>
    /// <param name="additionalInformation"></param>
    public void SetAdditionalInformation(string additionalInformation)
    {
        AdditionalInformation = additionalInformation;
    }


    /// <summary>
    /// Standard constructor
    /// </summary>
    /// <param name="title">Title of the log</param>
    /// <param name="message">Log message</param>
    /// <param name="logType">Type of the log. NOTE     :::    Default is <see cref="LogTypes.Information"/></param>
    /// <param name="id">ID of the log. NOTE    :::    Default is <see cref="0"/></param>
    /// <param name="additionalInfo">Any additional string information that the user would like to store</param>
    public InternalLog(string title, string message, LogTypes logType = LogTypes.Information, int id = 0)
    {
        Id = id; 
        Title = title;
        Message = message;
        LogType = logType;
    }

    /// <summary>
    /// Converts to the native version (<see cref="InternalLog"/>) of this object. 
    /// </summary>
    /// <param name="log"></param>
    /// <returns></returns>
    public static InternalLog ConvertInternalLog(IInternalLog log)
    {
        return new InternalLog(log.Title, log.Message, log.LogType, log.Id);
    }

    /// <summary>
    /// Write a <see cref="InternalLog"/> to the database 
    /// </summary>
    /// <returns></returns>
    internal async Task<int> WriteLogAsync()
    {
        InternalLoggerController controller = new InternalLoggerController();
        var transaction = await controller.Database.BeginTransactionAsync();
        try
        {
            controller.Add(this);
            await controller.SaveChangesAsync();
            await transaction.CommitAsync();
            return Id;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
        finally
        {
            await controller.DisposeAsync();
            await transaction.DisposeAsync();
        }
    }

    /// <summary>
    /// Update an <see cref="InternalLog"/> that is stored in the database 
    /// </summary>
    /// <returns></returns>
    internal async Task<int> UpdateLogAsync()
    {
        InternalLoggerController controller = new InternalLoggerController();
        var transaction = await controller.Database.BeginTransactionAsync();
        try
        {
            controller.Update(this);
            await controller.SaveChangesAsync();
            await transaction.CommitAsync();
            return Id; 
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
        finally
        {
            await controller.DisposeAsync();
            await transaction.DisposeAsync();
        }
    }

    /// <summary>
    /// Delete an <see cref="InternalLog"/> from the database 
    /// </summary>
    /// <returns></returns>
    internal async Task<int> DeleteLogAsync()
    {
        InternalLoggerController controller = new InternalLoggerController();
        var transaction = await controller.Database.BeginTransactionAsync();
        try
        {
            controller.Remove(this);
            await controller.SaveChangesAsync();
            await transaction.CommitAsync();
            return Id; 
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
        finally
        {
            await controller.DisposeAsync();
            await transaction.DisposeAsync();
        }
    }
}

