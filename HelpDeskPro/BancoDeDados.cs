using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HelpDeskPro
{
    public class DashboardChamados
    {
        public string Periodo { get; set; }
        public int Total { get; set; }
        public int Resolvidos { get; set; }
        public int EmAberto { get; set; }
        public int EmAndamento { get; set; }
    }


    public class BancoDeDados
    {
        public string GetDatabasePath()
        {
#if DEBUG
            string dbPath = Path.Combine("C:\\Projetos\\HelpDeskPro\\HelpDeskPro\\Data", "HelpDeskBD.db");
            Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
#else
    string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    string appFolder = Path.Combine(folder, "HelpDeskPro", "Data");
    Directory.CreateDirectory(appFolder);

    string dbPath = Path.Combine(appFolder, "HelpDeskBD.db");

    if (!File.Exists(dbPath))
    {
        string origem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "HelpDeskBD.db");
        if (File.Exists(origem))
            File.Copy(origem, dbPath);
    }
#endif

            return dbPath;
        }

        public SqliteConnection GetConnection()
        {
            Batteries.Init();
            string con = $"Data Source={GetDatabasePath()};";
            return new SqliteConnection(con);
        }

        public void CriarBancoSeNaoExistir()
        {
            using var connection = GetConnection();
            connection.Open();
            using var cmd = connection.CreateCommand();

            // Cria tabela Usuarios
            cmd.CommandText = @"
        CREATE TABLE IF NOT EXISTS Usuarios (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Usuario TEXT NOT NULL UNIQUE,
            Senha TEXT NOT NULL,
            Nivel_Acesso TEXT
        );";
            cmd.ExecuteNonQuery();

            // Cria tabela Chamados
            cmd.CommandText = @"
        CREATE TABLE IF NOT EXISTS Chamados (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Titulo TEXT NOT NULL,
            Descricao TEXT,
            DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
            Status TEXT,
            Responsavel TEXT
        );";
            cmd.ExecuteNonQuery();
        }


        public bool Login(string usuario, string senha)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM Usuarios WHERE Usuario = @usuario AND Senha = @senha";
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    using var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                        return true;
                    else
                        return false;
                }
            }
        }

        public bool Cadastro(string usuario, string senha)
        {
            if (Login(usuario, senha))
            {
                MessageBox.Show("Usuário já cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO Usuarios (Usuario, Senha) VALUES (@usuario, @senha)";
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    if (linhasAfetadas >= 1)
                        return true;
                    else
                        return false;
                }
            }
        }

        public bool CriarChamado(string titulo, string descricao, string status, string responsavel)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"INSERT INTO Chamados (Titulo, Descricao, Status, Responsavel) VALUES (@titulo, @descricao, @status, @responsavel)";
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@responsavel", string.IsNullOrEmpty(responsavel) ? DBNull.Value : (object)responsavel);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public List<DashboardChamados> ObterDashboardChamados(string tipoAgrupamento)
        {
            List<DashboardChamados> lista = new List<DashboardChamados>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    string query;

                    if (tipoAgrupamento == "todos")
                    {
                        // Query sem agrupamento -> retorna 1 linha com totais gerais
                        query = @"
                    SELECT 
                        'Todos' AS Periodo,
                        COUNT(*) AS Total,
                        SUM(CASE WHEN Status = 'Resolvido' THEN 1 ELSE 0 END) AS Resolvidos,
                        SUM(CASE WHEN Status = 'Aberto' THEN 1 ELSE 0 END) AS EmAberto,
                        SUM(CASE WHEN Status = 'Em Andamento' THEN 1 ELSE 0 END) AS EmAndamento
                    FROM Chamados;";
                    }
                    else
                    {
                        // Define a expressão de agrupamento conforme o tipo
                        string agrupamentoSql = tipoAgrupamento switch
                        {
                            "diario" => "strftime('%Y-%m-%d', DataCriacao)",
                            "semanal" => "strftime('%Y-W%W', DataCriacao)",
                            "mensal" => "strftime('%Y-%m', DataCriacao)",
                            _ => "strftime('%Y-%m-%d', DataCriacao)" // default = diário
                        };

                        // Query agrupada
                        query = $@"
                    SELECT 
                        {agrupamentoSql} AS Periodo,
                        COUNT(*) AS Total,
                        SUM(CASE WHEN Status = 'Resolvido' THEN 1 ELSE 0 END) AS Resolvidos,
                        SUM(CASE WHEN Status = 'Aberto' THEN 1 ELSE 0 END) AS EmAberto,
                        SUM(CASE WHEN Status = 'Em Andamento' THEN 1 ELSE 0 END) AS EmAndamento
                    FROM Chamados
                    GROUP BY {agrupamentoSql}
                    ORDER BY Periodo DESC;";
                    }

                    cmd.CommandText = query;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DashboardChamados
                            {
                                Periodo = reader["Periodo"].ToString(),
                                Total = reader.IsDBNull(reader.GetOrdinal("Total")) ? 0 : Convert.ToInt32(reader["Total"]),
                                Resolvidos = reader.IsDBNull(reader.GetOrdinal("Resolvidos")) ? 0 : Convert.ToInt32(reader["Resolvidos"]),
                                EmAberto = reader.IsDBNull(reader.GetOrdinal("EmAberto")) ? 0 : Convert.ToInt32(reader["EmAberto"]),
                                EmAndamento = reader.IsDBNull(reader.GetOrdinal("EmAndamento")) ? 0 : Convert.ToInt32(reader["EmAndamento"])
                            });
                        }

                    }
                }
            }

            return lista;
        }


        public DataTable ExibirChamados()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM Chamados";
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }
            }
        }

        public void ExcluirChamado(int Id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "DELETE FROM Chamados WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Chamado excluído com sucesso!", "Succeso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public bool AlterarChamado(int id, string titulo, string descricao, string status, string responsavel)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Chamados SET Titulo = @titulo, Descricao = @descricao, Status = @status, Responsavel = @responsavel WHERE ID = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@responsavel", string.IsNullOrEmpty(responsavel) ? DBNull.Value : (object)responsavel);

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Chamado alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Nenhum chamado encontrado para alteração.");
                        return false;
                    }
                }
            }
        }

        public bool AlterarSenha(string usuario, string senhaAntiga ,string senhaNova)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Usuarios SET Senha = @senhaNova WHERE Usuario = @usuario AND Senha = @senhaAntiga";
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@senhaAntiga", senhaAntiga);
                    cmd.Parameters.AddWithValue("@senhaNova", senhaNova);
                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                        return true;
                    else
                        return false;
                }
            }
        }
    }
}
