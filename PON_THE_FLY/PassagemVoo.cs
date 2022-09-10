using System;
using System.Collections.Generic;
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

        public override string ToString()
        {
            return "\nID da passagem: " + this.IdPassagem + "\nID do Voo: " + this.IdVoo + "\nData da Ultima Operação: " + this.DataUltimaOperacao + "\nValor da Passagem: " + this.Valor + "\nSituação da passagem: " + this.Situacao;
        }
    }
}
