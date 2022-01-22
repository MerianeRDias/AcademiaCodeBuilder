using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaCodeBuilder.Conexoes
{
    public class Sql
    {

        private readonly SqlConnection _conexao;

        public Sql()
        {
            string conexao = System.IO.File.ReadAllText(@"C:\Users\Meriane\Documents\RumoAcademy\VisualStudio\conexao\stringConexao.txt");
            this._conexao = new SqlConnection(conexao);

        }



        public bool VerificarExistenciaAluno(string identificador)
        {
            try
            {
                _conexao.Open();

                string sql = @"select Count(Identificador) AS total 
                                 from Aluno WHERE Identificador = @identificador;";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("identificador", identificador);
                    return Convert.ToBoolean(cmd.ExecuteScalar());

                }
            }
            finally
            {
                _conexao.Close();
            }

        }

        public void InserirAlunos(Entidades.Aluno aluno)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO Aluno
                                        (Identificador,Nome,Email,Telefone,Endereco, DataCadastro)
                                       VALUES
                                        (@identificador, @nome, @email , @telefone, @endereco, @dataCadastro);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("identificador", aluno.Identificador);
                    cmd.Parameters.AddWithValue("nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("email", aluno.Email);
                    cmd.Parameters.AddWithValue("telefone", aluno.Telefone);
                    cmd.Parameters.AddWithValue("endereco", aluno.Endereco);
                    cmd.Parameters.AddWithValue("dataCadastro", aluno.DataCadastro);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }

        }

        public void AtualizarAlunos(Entidades.Aluno aluno)
        {
            try
            {
                _conexao.Open();

                string sql = @"UPDATE Aluno
                               SET Nome = @Nome
                                   ,Email = @Email
                                   ,Telefone = @Telefone
                                   ,Endereco = @Endereco
                                   ,DataCadastro = @DataCadastro
                               WHERE  Identificador = @Identificador";


                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("Identificador", aluno.Identificador);
                    cmd.Parameters.AddWithValue("Nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("Email", aluno.Email);
                    cmd.Parameters.AddWithValue("Telefone", aluno.Telefone);
                    cmd.Parameters.AddWithValue("Endereco", aluno.Endereco);
                    cmd.Parameters.AddWithValue("DataCadastro", aluno.DataCadastro);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }
        }


        public bool VerificarExistenciaFaturamento(string identificador)
        {
            try
            {
                _conexao.Open();

                string sql = @"select Count(Identificador) AS total 
                                 from Faturamento WHERE Identificador = @identificador;";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("identificador", identificador);
                    return Convert.ToBoolean(cmd.ExecuteScalar());

                }
            }
            finally
            {
                _conexao.Close();
            }

        }


        public void InserirFaturamento(Servicos.Faturamento faturamento)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO Faturamento
                                        (Identificador,DiaReferencia,TotalEntrada,TotalSaida)
                                       VALUES
                                        (@identificador, @diaReferencia, @totalEntrada , @totalSaida);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("identificador", faturamento.Identificador);
                    cmd.Parameters.AddWithValue("diaReferencia", faturamento.DiaReferencia);
                    cmd.Parameters.AddWithValue("totalEntrada", faturamento.TotalEntrada);
                    cmd.Parameters.AddWithValue("totalSaida", faturamento.TotalSaida);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }

        }

        public void AtualizarFaturamento(Servicos.Faturamento faturamento)
        {
            try
            {
                _conexao.Open();

                string sql = @"UPDATE Faturamento
                               SET DiaReferencia = @diaReferencia
                                   ,TotalEntrada = @totalEntrada
                                   ,TotalSaida = @totalSaida
                               WHERE  Identificador = @identificador";


                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("identificador", faturamento.Identificador);
                    cmd.Parameters.AddWithValue("diaReferencia", faturamento.DiaReferencia);
                    cmd.Parameters.AddWithValue("totalEntrada", faturamento.TotalEntrada);
                    cmd.Parameters.AddWithValue("totalSaida", faturamento.TotalSaida);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }

        }


        public bool VerificarExistenciaPropaganda(string identificador)
        {
            try
            {
                _conexao.Open();

                string sql = @"select Count(Identificador) AS total 
                                 from Propaganda WHERE Identificador = @identificador;";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("identificador", identificador);
                    return Convert.ToBoolean(cmd.ExecuteScalar());

                }
            }
            finally
            {
                _conexao.Close();
            }

        }

        public void InserirPropaganda(Servicos.Propaganda propaganda)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO Propaganda
                                        (Identificador,EmpresaDivulgadora,Custo,DataPropaganda)
                                       VALUES
                                        (@identificador, @empresaDivulgadora, @custo , @dataPropaganda);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("identificador", propaganda.Identificador);
                    cmd.Parameters.AddWithValue("empresaDivulgadora", propaganda.EmpresaDivulgadora);
                    cmd.Parameters.AddWithValue("custo", propaganda.Custo);
                    cmd.Parameters.AddWithValue("dataPropaganda", propaganda.DataPropaganda);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }

        }

        public void AtualizarPropaganda(Servicos.Propaganda propaganda)
        {
            try
            {
                _conexao.Open();

                string sql = @"UPDATE Propaganda
                               SET EmpresaDivulgadora = @empresaDivulgadora
                                   ,Custo = @custo
                                   ,DataPropaganda = @dataPropaganda 
                               WHERE Identificador = @identificador";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("identificador", propaganda.Identificador);
                    cmd.Parameters.AddWithValue("empresaDivulgadora", propaganda.EmpresaDivulgadora);
                    cmd.Parameters.AddWithValue("custo", propaganda.Custo);
                    cmd.Parameters.AddWithValue("dataPropaganda", propaganda.DataPropaganda);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }

        }








    }
}
