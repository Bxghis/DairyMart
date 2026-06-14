using Npgsql;

namespace DairyMart.Models
{
    public class Koneksi
    {
        private string connString = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=DairyMart9";
        public NpgsqlConnection GetConnection() => new NpgsqlConnection(connString);
    }
}