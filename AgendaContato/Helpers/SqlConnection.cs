namespace AgendaContatos.Helpers
{
    public class SqlConnection
    {
        static string nomeDesktop = "desktop-8siv346";

        static string nomeBancoDados = "AgendaContatos";

        public static string connectionString = $"Data Source={nomeDesktop}\\SQLEXPRESS;" + 
            $"Initial Catalog={nomeBancoDados};" + 
            "Integrated Security=True;Pooling=False;TrustServerCertificate = true;";
    }
}
