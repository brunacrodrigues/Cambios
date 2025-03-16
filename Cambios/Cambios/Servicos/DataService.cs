using Cambios.Modelos;
using Microsoft.Data.Sqlite;
using System.Security.Cryptography.X509Certificates;

namespace Cambios.Servicos
{
    public class DataService
    {
        SqliteConnection _connection;
        SqliteCommand _command;
        DialogService _dialogService;

        public DataService()
        {
            _dialogService = new DialogService();

            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }

            var path = @"Data\Rates.sqlite";

            try
            {
                _connection = new SqliteConnection("Data Source=" + path);
                _connection.Open();

                string sqlcommand = "create table if not exists rates(RateId int, Code varchar(5), TaxRate real, Name varchar(250))";

                _command = new SqliteCommand(sqlcommand, _connection);

                _command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _dialogService.ShowMessage("Erro", e.Message);
            }

        }

        public void SaveData(List<Rate> Rates)
        {
            try
            {
                foreach (var rate in Rates)
                {
                    string sql = string.Format("insert into rates (RateId, Code, TaxRate, Name) values({0}, '{1}', {2}, '{3}')",
                        rate.RateId,rate.Code,rate.TaxRate,rate.Name);

                    _command = new SqliteCommand(sql, _connection);

                    _command.ExecuteNonQuery();
                }

                _connection.Close();
            }
            catch (Exception e)
            {
                _dialogService.ShowMessage("Erro", e.Message);
            }
        }

        public List<Rate> GetData()
        {
            List<Rate> Rates = new List<Rate>();

            try
            {
                string sql = "select RateId, Code, TaxRate, Name from Rates";

                _command = new SqliteCommand(sql, _connection);

                // Lê cada registo
                SqliteDataReader reader = _command.ExecuteReader();

                while (reader.Read())
                {
                    Rates.Add(new Rate
                    {
                        RateId = Convert.ToInt32( reader["RateId"]),
                        Code = (string) reader["Code"],
                        TaxRate = (double) reader["TaxRate"],
                        Name = (string) reader["Name"],
                    });
                }

                _connection.Close();

                return Rates;
            }
            catch (Exception e)
            {
                _dialogService.ShowMessage("Erro", e.Message);
                return null;
            }

            
        }

        public void DeleteData()
        {
            try
            {
                string sql = "delete from Rates";

                _command = new SqliteCommand(sql, _connection);

                _command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _dialogService.ShowMessage("Erro", e.Message);
            }
        }
    }
}
