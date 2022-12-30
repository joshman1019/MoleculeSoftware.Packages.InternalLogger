using Microsoft.EntityFrameworkCore;

namespace MoleculeSoftware.Packages.InternalLogger
{
	public static class LibraryInitUtilities
    {
		/// <summary>
		/// Initializes the library and the associated database 
		/// </summary>
		/// <returns></returns>
        public static async Task<bool> Init()
        {
			using InternalLoggerController controller = new InternalLoggerController(); 
			try
			{
				await controller.Database.MigrateAsync();
				return true; 
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				controller.Dispose();
			}
        }
    }
}
