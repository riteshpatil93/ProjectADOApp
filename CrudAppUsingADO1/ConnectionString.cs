namespace CrudAppUsingADO1
{
    public static class ConnectionString
    {
        private static string cs = "Server = LAPTOP-FLBU116V\\SQLEXPRESS; Database = CrudADOdb1; Trusted_Connection  = True;";
        public static string dbcs { get => cs; }
    }
}
