using Microsoft.EntityFrameworkCore;

namespace UploadDB
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
            EnsureTableCreated();
            EnsureStoredProcedureCreated();
        }

        private void EnsureStoredProcedureCreated()
        {
            Database.ExecuteSqlRaw("CREATE or ALTER PROCEDURE InsertWords (@word varchar(20), @Count integer)\r\n" +
                "as\r\n" +
                "BEGIN\r\n    " +
                "IF EXISTS (SELECT id FROM dbo.Words WHERE Word=@word ) \t\t\r\n\t\t" +
                "UPDATE dbo.Words SET Count = Count + @Count where Word=@word;\t\t\r\n\telse\r\n\t\t" +
                "INSERT INTO dbo.Words (Word, Count) VALUES(@word, @Count);\r\n" +
                "END;");
        }

        private void EnsureTableCreated()
        {
            Database.ExecuteSqlRaw("IF OBJECT_ID(N'dbo.Words', N'U') IS NULL\r\n" +
                "CREATE TABLE Words ( id INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY, word VARCHAR(20), Count integer )");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        }
    }
}
