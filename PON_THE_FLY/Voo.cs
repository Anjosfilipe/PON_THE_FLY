using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PON_THE_FLY
{
    internal class Voo
    {
        internal int IDVoo { get; set; }
        public string Destino { get; set; }
        public string Aeronave { get; set; }
        public DateTime DataVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        public Voo()
        {

        }
        public Voo CadastrarVoo(List<Voo> listaVoo, List<string> IATA, List<string> IDAeronave)
        {
            Voo voo = new Voo();

            Console.Write("Informe o destino do voo: ");
            string destino = Console.ReadLine().ToUpper();

            //// ---- validação da IATA do voo ----- //// 
            bool achei = false;
            foreach (string d in IATA)
            {
                if (destino == d)
                {
                    achei = true;
                    Console.WriteLine("Destino  compativel !");
                    voo.Destino = destino;
                    // ----- continua o cadastro 
                }
            }
            if (achei == false)
            {
                Console.WriteLine("Informação não localizada. reinicie o cadatro com o Destino correto!");
                Console.WriteLine("Tecle enter para reiniciar");
                Console.ReadKey();
                Environment.Exit(0); // necessita de um break 
            }
            Console.WriteLine("Informe o ID da aeronave desejada: ");
            string IdAeronave = Console.ReadLine();
            achei = false;
            // ---- validação do ID da aeronave ------ //
            foreach (string id in IDAeronave)
            {
                if (IdAeronave == id)
                {
                    achei = true;
                    Console.WriteLine("Aeronave compativel !");
                    voo.Aeronave = IdAeronave;
                }
            }
            if (achei == false)
            {
                Console.WriteLine("Informação não localizada. reinicie o cadatro com o Destino correto!");
                Console.WriteLine("Tecle enter para reiniciar");
                Console.ReadKey();
                Environment.Exit(0); // necessita de um break 
            }
            else
            {
                // ----- continua cadastro 
                Console.WriteLine("Infome a data e hora do voo: ");
                DateTime DataVoo = DateTime.Parse(Console.ReadLine());
                voo.DataVoo = DataVoo;
                voo.DataCadastro = DateTime.Now;
                Console.WriteLine("Infome situação do voo:  A - ativo || C - Cancelado");
                char situacao = char.Parse(Console.ReadLine().ToUpper());
                voo.Situacao = situacao;
                Console.WriteLine("Cadastro Realizado com sucesso!");
            }
            if (voo.IDVoo < 9999)
            {

                voo.IDVoo = listaVoo.Count + 1;
                listaVoo.Add(voo);
            }
            else
            {
                Console.WriteLine("Numero maximo de voo cadastrados");
                Environment.Exit(0); // necessita de um break 
            }

            return voo;
        } /// funcionando
          /// 
          /// Rodando perfeitamente. já embutido nele um controle de dados.
          /// Necessita: Vincular o break correto para nossa aplicação e sincronizar a fonte de dados.  
        public Voo LocalizarVoo(List<Voo> listaVoo, int id)
        {
            bool achei = false;
            Voo v = new Voo();

            foreach (Voo i in listaVoo)
            {
                if (i.IDVoo == id)
                {
                    achei = true;
                    v = i;
                    Console.WriteLine("\n>>>>>>> VOO LOCALIZADO <<<<<<");
                    Console.WriteLine(v.ToString());
                    return v;

                }
            }
            if (achei)
            {
                Console.WriteLine("Voo não encontrado!");
            }
            return v;
        }/// funcionando
         /// 
         /// Rodando perfeitamente.
        public void ImprimirVoo(List<Voo> listaVoo)
        {
            foreach (Voo i in listaVoo)
            {

                Console.WriteLine("\n>>>>>>>  LISTA DE VOO <<<<<<");
                Console.WriteLine(i.ToString());

            }
        }/// funcionando
         /// 
         /// Rodando perfeitamente.
        public Voo EditarVoo(List<Voo> listaVoo)
        {
            //bool stop = false;
            Voo v = new Voo();
            Console.WriteLine("Informe o ID do voo para editar: ");
            int id = int.Parse(Console.ReadLine());
            // do
            // {
            v = LocalizarVoo(listaVoo, id);
            Console.WriteLine("1 - Editar Destino");
            Console.WriteLine("2 - Editar Aeronave");
            Console.WriteLine("3 - Editar Data do voo");
            Console.WriteLine("4 - Situação");
            Console.WriteLine("0 - Sair");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                //case 0:
                //stop = true;
                // break;
                case 1:
                    Console.WriteLine("Informe o NOVO destino:");
                    string destino = Console.ReadLine();
                    v.Destino = destino;
                    break;

                case 2:
                    Console.WriteLine("Informe A NOVA Aeronave:");
                    string aeronave = Console.ReadLine();
                    v.Aeronave = aeronave;
                    break;

                case 3:
                    Console.WriteLine("Informe o NOVO Data do voo:");
                    DateTime data = DateTime.Parse(Console.ReadLine());
                    v.DataVoo = data;
                    break;

                case 4:
                    Console.WriteLine("Informe o NOVO Aniversario:");
                    char situacao = char.Parse(Console.ReadLine());
                    v.Situacao = situacao;
                    break;

                default:
                    break;
            }
            //} while (stop == true);
            Console.WriteLine(" >> Voo editado com sucesso <<");
            return v;
        }/// funcionando
         /// 
         /// Rodando perfeitamente. <summary>
         /// funcionando

        public void Gravar_Dados(List<Voo> listaVoo)
        {
            Console.WriteLine("Iniciando a Gravação de Dados...");
            try
            {
                StreamWriter sw = new StreamWriter("c:\\Users\\Filipe Anjos\\Documents\\ATIVIDADES_ESTAGIO\\PON_THE_FLY\\Voo.dat");  //Instancia um Objeto StreamWriter (Classe de Manipulação de Arquivos)
                //sw.WriteLine("Treinamento de C#");  //Escreve uma linha no Arquivo
                //sw.WriteLine("maria;araraquara;190;contato;"); //Exemplo de escrita - formato da escrita será de acordo com a necessidade do projeto
                foreach (Voo i in listaVoo)
                {
                    sw.WriteLine("V"+i.IDVoo.ToString("D4") + i.Destino + i.Aeronave + i.DataVoo.ToString("g") + i.DataCadastro.ToString("g") + i.Situacao);
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
                StreamReader sr = new StreamReader("c:\\Users\\Filipe Anjos\\Documents\\ATIVIDADES_ESTAGIO\\PON_THE_FLY\\Voo.dat");//Instancia um Objeto StreamReader (Classe de Manipulação de Leitura de Arquivos)
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
            return "\nID do Voo: " + this.IDVoo + "\nDestino: " + this.Destino + "\nAernave: " + this.Aeronave + "\nData do voo: " + this.DataVoo + "\nData de Cadastro do Voo: " + this.DataCadastro + "\nSituação: " + this.Situacao;
        }
    }
}
    