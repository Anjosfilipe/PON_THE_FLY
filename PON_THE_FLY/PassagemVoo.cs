using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PON_THE_FLY
{
    internal class PassagemVoo
    {
        private int IdPassagem { get; set; }
        private int IdVoo { get; set; }
        public DateTime DataUltimaOperacao { get; set; }
        public double Valor { get; set; }
        public char Situacao { get; set; }

        public PassagemVoo()
        {

        }

        public void CadastrarPassagem(List<PassagemVoo> listaPassagem, List<Voo> listaVoo)
        {
            foreach (Voo i in listaVoo)
            {

                int assentos;
                assentos = 3; //i.Aeronave.assentos;
                Console.WriteLine("Digite o valor das passagens deste voo:");
                double valor = double.Parse(Console.ReadLine());
                if (valor > 9999.99 || valor < 0)
                {
                    Console.WriteLine("Valor de Passagem fora do limite!");
                    break;
                }
                else
                {
                    for (int p = 0; p < assentos; p++)
                    {
                        PassagemVoo passagem = new();
                        passagem.IdVoo = i.IDVoo;
                        passagem.DataUltimaOperacao = DateTime.Now;
                        passagem.Valor = valor;
                        char situacao = 'L';
                        passagem.Situacao = situacao;
                        passagem.IdPassagem = p;
                        listaPassagem.Add(passagem);
                    }

                    Console.WriteLine("Passagens geradas com sucesso!");
                }
            }
        }/// funcionando
         /// 
         /// Rodando perfeitamente.

        public void imprimirpassagem(List<PassagemVoo> listaPassagem)
        {
            foreach (PassagemVoo p in listaPassagem)
            {

                Console.WriteLine("\n>>>>>>>  PASSAGEM <<<<<<");
                Console.WriteLine(p.ToString());

            }
        }/// funcionando
         /// 
         /// Rodando perfeitamente.

        public PassagemVoo LocalizarPassagem(List<PassagemVoo> listaPassagem, List<Voo> listaVoo, int idVoo, int idPassagem)
        {
            bool achei = false;

            PassagemVoo p = new();

            foreach (Voo i in listaVoo)
            {
                if (i.IDVoo == idVoo)
                {
                    foreach (PassagemVoo pv in listaPassagem)
                    {
                        achei = true;
                        p = pv;
                        Console.WriteLine("\n>>>>>>> PASSAGEM LOCALIZADA <<<<<<");
                        Console.WriteLine(p.ToString());
                        return p;
                    }
                }
            }
            if (achei)
            {
                Console.WriteLine("Passagem não encontrada!");
            }
            return p;
        }/// funcionando
         /// 
         /// Rodando perfeitamente.

        public PassagemVoo EditarPassagem(List<PassagemVoo> listaPassagem, List<Voo> listaVoo)
        {
            PassagemVoo p = new();

            Console.WriteLine("\nDigite o Id (4 numeros) do voo que deseja buscar a passagem: ");
            int idvoo = int.Parse(Console.ReadLine());
            Console.WriteLine("\nDigite o Id da passagem que deseja editar: ");
            int idp = int.Parse(Console.ReadLine());

            p.LocalizarPassagem(listaPassagem, listaVoo, idvoo, idp);


            Console.WriteLine("1 - Valor");
            Console.WriteLine("2 - Situação");
            Console.WriteLine("0 - Sair");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                //case 0:
                //stop = true;
                // break;
                case 1:
                    Console.WriteLine("Informe o NOVO Valor da passagem:");
                    double valor = double.Parse(Console.ReadLine());
                    if (valor > 9999.99 || valor < 0)
                    {
                        Console.WriteLine("Valor de Passagem fora do limite!");
                        break;
                    }
                    else
                    {
                        p.Valor = valor;
                        Console.WriteLine(" >> Pasagem editada com sucesso <<");
                    }
                    break;
                case 2:
                    Console.WriteLine("Informe A NOVA Situação:");
                    char situacao = char.Parse(Console.ReadLine());
                    p.Situacao = situacao;
                    Console.WriteLine(" >> Pasagem editada com sucesso <<");
                    break;
                default:
                    break;
            }
            //} while (stop == true);

            return p;
        }/// funcionando
         /// 
         /// Rodando perfeitamente.
        public void Gravar_Dados(List<PassagemVoo> listaPassagem)
        {
            Console.WriteLine("Iniciando a Gravação de Dados...");
            try
            {
                StreamWriter sw = new StreamWriter("c:\\Users\\Filipe Anjos\\Documents\\ATIVIDADES_ESTAGIO\\PON_THE_FLY\\PassagemVoo.dat");  //Instancia um Objeto StreamWriter (Classe de Manipulação de Arquivos)
                //sw.WriteLine("Treinamento de C#");  //Escreve uma linha no Arquivo
                //sw.WriteLine("maria;araraquara;190;contato;"); //Exemplo de escrita - formato da escrita será de acordo com a necessidade do projeto
                foreach (PassagemVoo i in listaPassagem)
                {
                    sw.WriteLine("PA" + i.IdPassagem + i.IdVoo + i.DataUltimaOperacao + i.Valor + i.Situacao);
                }
                sw.Close();  // Comando para Fechar o Arquivo
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o Bloco de Comandos.");
            }
            Console.WriteLine("FIM DA GRAVAÇÃO");
            Console.ReadKey();

        }

        public void Ler_Arquivo()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader("c:\\Users\\Filipe Anjos\\Documents\\ATIVIDADES_ESTAGIO\\PON_THE_FLY\\PassagemVoo.dat");//Instancia um Objeto StreamReader (Classe de Manipulação de Leitura de Arquivos)
                line = sr.ReadLine(); //Faz a Leitura de uma linha do arquivo e atribui a string line
                while (line != null)// Laço de Repetição para fazer a leitura de linhas do arquivo até o EOF (End Of File - Fim do Arquivo)
                {
                    Console.WriteLine(line);//Imprime o retorno do arquivo no Console
                    line = sr.ReadLine(); //Faz a Leitura de linha do arquivo e atribui a string line
                }
                sr.Close();//Fecha o Arquivo
                Console.WriteLine("Fim da Leitura do Arquivo");
                Console.ReadLine();
            }
            catch (Exception e) // Tratamento de erro na abertura do arquivo
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executando o Bloco de Comando - Sem Erros");
            }
            Console.WriteLine("FIM DA LEITURA");
            Console.ReadKey();
        }
        public override string ToString()
        {
            return "\nID da passagem: " + this.IdPassagem + "\nID do Voo: " + this.IdVoo + "\nData da Ultima Operação: " + this.DataUltimaOperacao + "\nValor da Passagem: " + this.Valor + "\nSituação da passagem: " + this.Situacao;
        }
    }
}
