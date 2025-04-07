namespace AgendaContatos.Helpers
{
    public class SqlConnection
    {
        static string nomeDesktop = "DESKTOP-M7GU6EU";

        static string nomeBancoDados = "AGENDACONTATOS";

        public static string connectionString = $"Data Source={nomeDesktop}\\SQLEXPRESS;" +
            $"Initial Catalog={nomeBancoDados};" +
            "Integrated Security=True;Pooling=False;TrustServerCertificate = true;";
    }
}
