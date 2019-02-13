using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eturn
{
    public class Palestra
    {
        public string Index { get; set; }
        public string Descricao { get; set; }
        public TimeSpan Duracao { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Palestra> ListaPaletra = new List<Palestra>()
            {
                new Palestra() { Index = "1", Descricao = "Escrevendo testes rápidos" , Duracao =  new TimeSpan(0, 60, 0) },
                new Palestra() { Index = "2", Descricao = "Uma visão sobre Python", Duracao = new TimeSpan(0, 45, 0) },
                new Palestra() { Index = "3", Descricao = "Angular", Duracao = new TimeSpan(0, 30, 0) },
                new Palestra() { Index = "4", Descricao = "Otimizando aplicações com o NodeJS", Duracao = new TimeSpan(0, 45, 0) },
                new Palestra() { Index = "5", Descricao = "Erros comuns no desenvolvimento de software", Duracao = new TimeSpan(0, 45, 0) },
                new Palestra() { Index = "6", Descricao = "Rails para Desenvolvedores Python", Duracao = new TimeSpan(0, 60, 0) },
                new Palestra() { Index = "7", Descricao = "ASP.net MVC", Duracao = new TimeSpan(0, 60, 0) },
                new Palestra() { Index = "8", Descricao = "TDD na prática", Duracao = new TimeSpan(0, 45, 0) },
                new Palestra() { Index = "9", Descricao = "Woah", Duracao = new TimeSpan(0, 30, 0) },
                new Palestra() { Index = "A", Descricao = "Sente e escreva", Duracao = new TimeSpan(0, 30, 0) },
                new Palestra() { Index = "B", Descricao = "Pair Programming vs Noise", Duracao = new TimeSpan(0, 45, 0) },
                new Palestra() { Index = "C", Descricao = "Mobilidade em desenvolvimento", Duracao = new TimeSpan(0, 60, 0) },
                new Palestra() { Index = "D", Descricao = "Ruby on Rails: Por que devemos migrar para ele?", Duracao = new TimeSpan(0, 60, 0) },
                new Palestra() { Index = "E", Descricao = "Otimizando aplicações .NET", Duracao = new TimeSpan(0, 45, 0) },
                new Palestra() { Index = "F", Descricao = "Java e os novos paradigmas de programação", Duracao = new TimeSpan(0, 30, 0) },
                new Palestra() { Index = "G", Descricao = "Rubi vs. Clojure para Back - End", Duracao = new TimeSpan(0, 30, 0) },
                new Palestra() { Index = "H", Descricao = "Scrum para leigos", Duracao = new TimeSpan(0, 60, 0) },
                new Palestra() { Index = "I", Descricao = "Um mundo sem stackoverflow", Duracao = new TimeSpan(0, 30, 0) },
                new Palestra() { Index = "J", Descricao = "UX", Duracao = new TimeSpan(0, 30, 0) },
            };

            List<string> Alfabeto = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            List<string> ListaCombinacao = new List<string>();

            int Tamanho = 3;
            while (Tamanho <= 8)
            {
                Recursividade(Alfabeto, Tamanho, string.Empty, ListaCombinacao);
                Tamanho++;
            }

            List<List<Palestra>> ListaPaletraCombinada = new List<List<Palestra>>();
            foreach (string stringCombinada in ListaCombinacao)
            {
                List<Palestra> Combinacao = ListaPaletra.Where(x => stringCombinada.Contains(x.Index)).ToList();
                double TotalMinutos = TimeSpan.FromMinutes(Combinacao.Sum(x => x.Duracao.TotalMinutes)).TotalMinutes;
                if (TotalMinutos == 180 || TotalMinutos == 240) ListaPaletraCombinada.Add(Combinacao);
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
