using System;
using System.Collections.Generic;

namespace PON_THE_FLY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <Voo> listaVoo = new();
            List<string> IATA = new();
            List<string> IDAeronave = new();

            IATA.Add("GRU");
            IATA.Add("MSU");

            IDAeronave.Add("1");
            IDAeronave.Add("2");

            Voo voo = new();

            voo.CadastrarVoo(listaVoo, IATA, IDAeronave);
            voo.CadastrarVoo(listaVoo, IATA, IDAeronave);

            Console.WriteLine("Digite o Id (4 numeros) do voo que deseja buscar ");
            int id = int.Parse(Console.ReadLine());
            voo.BuscarVoo(listaVoo, id);

            voo.ImprimirVoo(listaVoo);

            voo.EditarVoo(listaVoo);

            voo.ImprimirVoo(listaVoo);

        }
    }
}
