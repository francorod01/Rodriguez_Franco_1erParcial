using Rodriguez_Franco.Models;
using System.Data.SqlClient;

namespace Rodriguez_Franco.Datos
{
    public class TorneoDatos
    {
        private string conexionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Torneo;Integrated Security=True;";

        public List<Competidor> ListarCompetidor()
        {
            List<Competidor> competidores = new List<Competidor>();
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                string query = "SELECT Competidores.IdCompetidor as IdCompetidor, Competidores.Nombre as NombreCompetidor," +
                    " Competidores.IdDisciplina, Competidores.Edad, Competidores.CiudadResidencia, Disciplinas.NombreDisciplina as NombreDisciplina " +
                    "FROM Competidores INNER JOIN Disciplinas ON Competidores.IdDisciplina = Disciplinas.IdDisciplina";
              
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    competidores.Add(new Competidor()
                    {
                        IdCompetidor = (int)reader["IdCompetidor"],
                        Nombre = reader["Nombre"].ToString(),
                        IdDisciplina = (int)reader["IdDisciplina"],
                        Edad = (int)reader["Edad"],
                        CiudadResidencia = reader["CiudadResidencia"].ToString(),
                        Disciplina = new Disciplina()
                        {
                            IdDisciplina = (int)reader["IdDisciplina"],
                            NombreDisciplina = reader["NombreDisciplina"].ToString()
                        }
                    });
                }
                return competidores;

            }
        }
        public string Crear(Competidor competidores)
        {
            string query = $"INSERT INTO Competidores (nombre, IdDisciplina, edad, ciudadresidencia) VALUES '{competidores.Nombre}'," +
                $" {competidores.IdDisciplina}, {competidores.Edad}, '{competidores.CiudadResidencia}'";
            try
            {
                using (SqlConnection conn = new SqlConnection(conexionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return "";
                }
            }
            catch (Exception ex) { return ex.Message; }
        }
        public List<Disciplina> ListarDisciplina()
        {
            List<Disciplina> disciplinas = new List<Disciplina>();
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                string query = "SELECT * FROM Disciplinas ORDER BY NombreDisciplina";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    disciplinas.Add(new Disciplina()
                    {
                        IdDisciplina = (int)reader["IdDisciplina"],
                        NombreDisciplina = reader["NombreDisciplina"].ToString()

                    });
                }
                return disciplinas;
            }
        }
    }
}
