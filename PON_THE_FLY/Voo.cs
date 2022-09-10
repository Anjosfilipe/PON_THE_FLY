using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PON_THE_FLY
{
    internal class Voo
    {
        private int IDVoo { get; set; }
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
            if(voo.IDVoo < 9999)
            {
            voo.IDVoo = IDVoo + 1;
            listaVoo.Add(voo);
            }
            else
            {
                voo.IDVoo = 00;
                voo.IDVoo = IDVoo + 1;
                listaVoo.Add(voo);
            }

            return voo;
        } /// funcionando
          /// 
          /// Rodando perfeitamente. já embutido nele um controle de dados.
          /// Necessita: Realizar encrementação de id 
          /// Necessita: Vincular o break correto para nossa aplicação e sincronizar a fonte de dados.  

        public Voo BuscarVoo(List<Voo> listaVoo, int id)
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
            bool stop = false;
            Voo v = new Voo();
            Console.WriteLine("Informe o ID do voo para busca: ");
            int id = int.Parse(Console.ReadLine());
            do
            {
                v = BuscarVoo(listaVoo, id);
                Console.WriteLine("1 - Editar Destino");
                Console.WriteLine("2 - Editar Aeronave");
                Console.WriteLine("3 - Editar Data do voo");
                Console.WriteLine("4 - Situação");
                Console.WriteLine("0 - Sair");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 0:
                        stop = true;
                        break;
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
            } while (stop == true);
            Console.WriteLine(" >> Voo editado com sucesso <<");
            return v;
        }/// funcionando
         /// 
         /// Rodando perfeitamente.

        public override string ToString()
        {
            return "\nID do Voo: " + this.IDVoo + "\nDestino: " + this.Destino + "\nAernave: " + this.Aeronave + "\nData do voo: " + this.DataVoo + "\nData de Cadastro do Voo: " + this.DataCadastro + "\nSituação: " + this.Situacao;
        }
    }
}