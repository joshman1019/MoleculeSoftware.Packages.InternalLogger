namespace MoleculeSoftware.Packages.InternalLogger;

public static class InternalLoggerService
{
	/// <summary>
	/// Saves a new log to the database 
	/// </summary>
	/// <param name="log"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentException"></exception>
    public static async Task<int> SaveNewLogAsync(IInternalLog log)
    {
		var convertedLog = InternalLog.ConvertInternalLog(log);

        if (convertedLog is null)
            throw new ArgumentException("The log was null");
		try
		{
			return await convertedLog.WriteLogAsync();
		}
		catch (Exception)
		{
			throw;
		}
    }    
	
	/// <summary>
	/// Updates an existing log
	/// </summary>
	/// <param name="log"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentException"></exception>
	public static async Task<int> UpdateLogAsync(IInternalLog log)
    {
		var convertedLog = InternalLog.ConvertInternalLog(log);
        if (convertedLog is null)
            throw new ArgumentException("The log was null");
		try
		{
			return await convertedLog.UpdateLogAsync();
		}
		catch (Exception)
		{
			throw;
		}
    }	
	
	/// <summary>
	/// Deletes an existing log
	/// </summary>
	/// <param name="log"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentException"></exception>
	public static async Task<int> DeleteLogAsync(IInternalLog log)
    {
		var convertedLog = InternalLog.ConvertInternalLog(log);
        if (convertedLog is null)
            throw new ArgumentException("The log was null");
		try
		{
			return await convertedLog.DeleteLogAsync();
		}
		catch (Exception)
		{
			throw;
		}
    }

	/// <summary>
	/// Retrieves all logs from the system 
	/// </summary>
	/// <returns></returns>
	/// <exception cref="Exception"></exception>
	public static IEnumerable<IInternalLog>? RetrieveAllLogs()
	{
		using InternalLoggerController controller = new InternalLoggerController();
		if (controller is null)
			throw new Exception("The logging controller was null. This is an internal system error. Please provide this info to a system administrator LG001"); 
		try
		{
			var results = controller?.InternalLogs?.ToList();
			return results; 
		}
		catch (Exception)
		{
			throw;
		}
	}
}
