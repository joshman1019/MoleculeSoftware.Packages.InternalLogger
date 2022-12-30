using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MoleculeSoftware.Packages.InternalLogger;

/// <summary>
/// Class inheriting from <see cref="DbContext"/> which creates a full database context for the library 
/// </summary>
internal class InternalLoggerController : DbContext
{
    // Default database name
    private string m_DatabasePath = "Molecule.Software.AppLogbook.db"; 

    /// <summary>
    /// Logs recorded by the system ::: Note - This log is separate from the internal database. 
    /// </summary>
    public DbSet<InternalLog>? InternalLogs { get; set; }

    /// <summary>
    /// Set the output path of the database.
    /// NOTE    :::    The database does not support network shares
    /// NOTE    :::    The database should be located in a place where the logger has full access while the application is running
    /// NOTE    :::    The database name should be followed by .db | Ex: Database/Sample.db 
    /// </summary>
    /// <param name="databasePath"></param>
    public void SetDatabasePath(string databasePath)
    {
        m_DatabasePath = databasePath;
    }

    // Configures the connection and options for the database 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        SqliteConnectionStringBuilder csBuilder = new SqliteConnectionStringBuilder();
        csBuilder.Mode = SqliteOpenMode.ReadWriteCreate;
        csBuilder.DataSource = m_DatabasePath; 
        csBuilder.Pooling = false;
        // Apply SQLite     :::     Pooling is disabled due to performance issues with multiple users. 
        optionsBuilder.UseSqlite(csBuilder.ConnectionString);
    }
}
