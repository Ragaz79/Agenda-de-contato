namespace AgendaContatos.Helpers
{
    public static class SqlConnectionExemplo
    {
        static string nomeDesktop = "nomeDoComputador";

        static string nomeBancoDados = "nomeDoBanco";

        public static string connectionString = $"Data Source={nomeDesktop}\\SQLEXPRESS;" +
            $"Initial Catalog={nomeBancoDados};" +
            "Integrated Security=True;Pooling=False;TrustServerCertificate = true;";
    }
}
