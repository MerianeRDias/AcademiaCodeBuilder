using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaCodeBuilder
{
    internal class Fluxo
    {

        public void Importacao()
        {

            var alunos = ObterAlunos();
            var sql = new Conexoes.Sql();
            foreach (var aluno in alunos)
            {
                if (sql.VerificarExistenciaAluno(aluno.Identificador) == true)
                {
                    sql.AtualizarAlunos(aluno);
                }
                else
                {
                    sql.InserirAlunos(aluno);
                }

            }


            var faturamentos = ObterFaturamentos();
            foreach (var faturamento in faturamentos)
            {
                if (sql.VerificarExistenciaFaturamento(faturamento.Identificador) == true)
                {
                    sql.AtualizarFaturamento(faturamento);
                }
                else
                {
                    sql.InserirFaturamento(faturamento);
                }

            }

            var propagandas = ObterPropagandas();
            foreach (var propaganda in propagandas)
            {
                if (sql.VerificarExistenciaPropaganda(propaganda.Identificador) == true)
                {
                    sql.AtualizarPropaganda(propaganda);
                }
                else
                {
                    sql.InserirPropaganda(propaganda);
                }
            }


        }
        public List<Entidades.Aluno> ObterAlunos()
        {
            string[] linhas = System.IO.File.ReadAllLines(@"C:\Users\Meriane\Documents\RumoAcademy\VisualStudio\Exercicios\AcademiaCodeBuilder\csv\AlunosV2.csv");
            int indexToRemove = 0;
            linhas = linhas.Where((source, index) => index != indexToRemove).ToArray();

            var alunos = new List<Entidades.Aluno>();

            var nomes = new List<string>();

            var nome = "";

            foreach (string linha in linhas)
            {
                string[] colunas = linha.Split(',');
                var aluno = new Entidades.Aluno();
                aluno.Identificador = colunas[0];
                aluno.Nome = colunas[1];
                aluno.Email = colunas[2];
                aluno.Telefone = Convert.ToInt64(colunas[3].Replace("(", "").Replace(") ", "").Replace("-", ""));

                aluno.Endereco = colunas[4];
                aluno.DataCadastro = Convert.ToDateTime(colunas[5]);

                alunos.Add(aluno);

                if (aluno.DataCadastro >= Convert.ToDateTime("2019/01/01 00:00:00"))
                {

                    nome = aluno.Nome;

                    nomes.Add(nome);

                }

            }


            StreamWriter sr = new StreamWriter(@"C:\Users\Meriane\Documents\RumoAcademy\VisualStudio\Exercicios\AcademiaCodeBuilder\csv\alunosMensalidadeGratis.txt");
            sr.WriteLine("Clientes que entraram em 2019 vão ganhar 3 meses de mensalidade grátis: " +
                        "\n");
            foreach (var item in nomes)
            {
                sr.WriteLine(item);
            }
            sr.Close();

            return alunos;
        }

        public List<Servicos.Faturamento> ObterFaturamentos()
        {
            string[] linhas = System.IO.File.ReadAllLines(@"C:\Users\Meriane\Documents\RumoAcademy\VisualStudio\Exercicios\AcademiaCodeBuilder\csv\Faturamentos.csv");
            int indexToRemove = 0;
            linhas = linhas.Where((source, index) => index != indexToRemove).ToArray();

            var faturamentos = new List<Servicos.Faturamento>();
            decimal somaFaturamento = 0;
            decimal somaDespesas = 0;
            decimal lucro = 0;

            foreach (string linha in linhas)
            {
                string[] colunas = linha.Split('"');
                var faturamento = new Servicos.Faturamento();
                faturamento.TotalEntrada = Convert.ToDecimal(colunas[1].Replace("-R$", "").Replace("R$", ""));
                faturamento.TotalSaida = Convert.ToDecimal(colunas[3].Replace("-R$", "").Replace("R$", ""));
                colunas = linha.Split(",");
                faturamento.Identificador = colunas[0];
                faturamento.DiaReferencia = Convert.ToDateTime(colunas[1]);


                faturamentos.Add(faturamento);

                somaFaturamento += faturamento.TotalEntrada;
                somaDespesas += faturamento.TotalSaida;
                lucro = somaFaturamento - somaDespesas;

            }

            StreamWriter sr = new StreamWriter(@"C:\Users\Meriane\Documents\RumoAcademy\VisualStudio\Exercicios\AcademiaCodeBuilder\csv\resultados.txt");
            sr.WriteLine("RESULTADOS: " +
                        "\nFaturamento total durante todo o período: R$" + somaFaturamento +
                         "\nDespesas totais durante todo o período:   R$" + somaDespesas +
                         "\nLucro total durante todo o período:       R$" + lucro);

            sr.Close();

            return faturamentos;


        }

        public List<Servicos.Propaganda> ObterPropagandas()
        {
            string[] linhas = System.IO.File.ReadAllLines(@"C:\Users\Meriane\Documents\RumoAcademy\VisualStudio\Exercicios\AcademiaCodeBuilder\csv\Propagandas.csv");
            int indexToRemove = 0;
            linhas = linhas.Where((source, index) => index != indexToRemove).ToArray();

            var propagandas = new List<Servicos.Propaganda>();

            foreach (string linha in linhas)
            {
                string[] colunas = linha.Split('"');
                var propaganda = new Servicos.Propaganda();
                propaganda.Custo = Convert.ToDecimal(colunas[1]);
                colunas = linha.Split(',');
                propaganda.Identificador = colunas[0];
                propaganda.EmpresaDivulgadora = colunas[1];
                propaganda.DataPropaganda = Convert.ToDateTime(colunas[4]);

                propagandas.Add(propaganda);

            }

            return propagandas;
        }

    }
}
