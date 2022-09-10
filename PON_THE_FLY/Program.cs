using System;
using System.Collections.Generic;

namespace PON_THE_FLY
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ///////////////////////////
            

            Voo voo = new();
            List<Voo> listaVoo = new();
            List<string> IATA = new();
            List<string> IDAeronave = new();

            ///////////////////////////
            PassagemVoo passagem = new();
            List<PassagemVoo> listaPassagem = new();

            ///////////////////////////

            IATA.Add("GRU");
            IATA.Add("MSU");

            IDAeronave.Add("1");
            IDAeronave.Add("2");

            voo.CadastrarVoo(listaVoo, IATA, IDAeronave);
            //voo.CadastrarVoo(listaVoo, IATA, IDAeronave);

            //Console.WriteLine("Digite o Id (4 numeros) do voo que deseja buscar ");
            //int id = int.Parse(Console.ReadLine());
            //voo.LocalizarVoo(listaVoo, id);

            voo.ImprimirVoo(listaVoo);

            //voo.EditarVoo(listaVoo);

            //voo.ImprimirVoo(listaVoo);

            passagem.CadastrarPassagem(listaPassagem, listaVoo);
            passagem.imprimirpassagem(listaPassagem);

            Console.WriteLine("\nDigite o Id (4 numeros) do voo que deseja buscar a passagem: ");
            int idvoo = int.Parse(Console.ReadLine());
            Console.WriteLine("\nDigite o Id da passagem que deseja buscar: ");
            int idp = int.Parse(Console.ReadLine());
            passagem.LocalizarPassagem(listaPassagem, listaVoo,idvoo, idp);

            passagem.EditarPassagem(listaPassagem, listaVoo);

        }
    }
}
