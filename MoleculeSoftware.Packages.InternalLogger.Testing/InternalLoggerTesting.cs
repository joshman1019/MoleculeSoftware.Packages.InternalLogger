namespace MoleculeSoftware.Packages.InternalLogger.Testing;

public class InternalLoggerTesting
{

    [Theory(DisplayName = "Testing of InternalLogger CRUD operations")]
    [TestingBeforeAndAfter]
    [InlineData("Test 001", "Message 001", LogTypes.Information)]
    [InlineData("Test 002", "Message 002", LogTypes.Warning)]
    [InlineData("Test 003", "Message 003", LogTypes.Critical)]
    [InlineData("Test 004", "Message 004", LogTypes.Information)]
    [InlineData("Test 005", "Message 005", LogTypes.Warning)]
    [InlineData("Test 006", "Message 006", LogTypes.Critical)]
    [InlineData("Test 007", "Message 007", LogTypes.Information)]
    [InlineData("Test 008", "Message 008", LogTypes.Warning)]
    [InlineData("Test 009", "Message 009", LogTypes.Critical)]
    [InlineData("Test 010", "Message 010", LogTypes.Information)]
    public async Task T0002_CRUD_Operations(string title, string message, LogTypes logType, string? addtlInformation = null)
    {
        try
        {
            // Add
            var log = new InternalLogClone(title, message, logType, addtlInformation);
            var result = await InternalLoggerService.SaveNewLogAsync(log);
            log.Id = result; 
            Assert.NotNull(log);
            Assert.True(result > 0);

            // Update
            log.Title = log.Title + " ::: Updated";
            var updateResult = await InternalLoggerService.UpdateLogAsync(log);
            Assert.NotNull(log);
            Assert.True(updateResult == result);

            // Delete
            var deleteResult = await InternalLoggerService.DeleteLogAsync(log);
            Assert.True(deleteResult == result);
        }
        catch (Exception ex)
        {
#if DEBUG
            Console.WriteLine(ex.Message);
#endif
            throw;
        }
    }
}
