using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eturn
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Alfabeto = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            List<string> ListaCombinacao = new List<string>();

            int Tamanho = 3;
            while (Tamanho <= 8)
            {
                Recursividade(Alfabeto, Tamanho, string.Empty, ListaCombinacao);
                Tamanho++;
            }

            foreach (string Combinacao in ListaCombinacao)
            {

            }

        }

        public static void Recursividade(List<string> Alfabeto, int Tamanho, string Combinacao, List<string> ListaCombinacao)
        {
            foreach (string Letra in Alfabeto)
            {
                string CombinacaoAuxiliar = Combinacao;
                int TamanhoAuxiliar = Tamanho;

                CombinacaoAuxiliar += Letra;

                if (TamanhoAuxiliar > 1) Recursividade(Alfabeto.Where(x => !CombinacaoAuxiliar.Contains(x)).ToList(), TamanhoAuxiliar - 1, CombinacaoAuxiliar, ListaCombinacao);
                else ListaCombinacao.Add(CombinacaoAuxiliar);
            }
        }
    }

}
