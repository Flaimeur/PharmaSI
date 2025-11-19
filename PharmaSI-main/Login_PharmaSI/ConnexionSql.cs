using System.Data;
using MySql.Data.MySqlClient;

namespace Login_PharmaSI
{
    
    public class ConnexionSql
    {
        private static ConnexionSql _instance;
        private MySqlConnection _cnx;

        private string _host, _db, _user, _pwd;

        private ConnexionSql(string host, string db, string user, string pwd)
        {
            _host = host; _db = db; _user = user; _pwd = pwd;
            _cnx = new MySqlConnection(BuildCs(host, db, user, pwd));
        }

        private static string BuildCs(string host, string db, string user, string pwd)
            => $"Server={host};Port=3306;Database={db};Uid={user};Pwd={pwd};SslMode=None;CharSet=utf8mb4;";

        
        public static ConnexionSql getInstance(string host, string db, string user, string pwd)
        {
            if (_instance == null)
            {
                _instance = new ConnexionSql(host, db, user, pwd);
            }
            else if (_instance._host != host || _instance._db != db || _instance._user != user || _instance._pwd != pwd)
            {
                
                _instance.CloseConnexion();
                _instance = new ConnexionSql(host, db, user, pwd);
            }
            return _instance;
        }

        public void OpenConnexion()
        {
            if (_cnx.State != ConnectionState.Open)
                _cnx.Open();
        }

        public void CloseConnexion()
        {
            if (_cnx.State != ConnectionState.Closed)
                _cnx.Close();
        }

        
        public MySqlCommand reqExec(string sql)
        {
            var cmd = _cnx.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            return cmd;
        }

        
        public MySqlConnection Raw() => _cnx;
    }
}
