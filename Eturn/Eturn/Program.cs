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
            List<Palestra> ListaPalestra = new List<Palestra>()
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

            List<Palestra> Trilha01 = Recursivo(ListaPalestra, 9, string.Empty, 420);
            List<Palestra> Trilha02 = ListaPalestra.Where(x => !Trilha01.Aggregate(string.Empty, (a, b) => string.Format("{0}'{1}',", a, b.Index)).Contains(x.Index)).ToList();

            List<Palestra> Trilha01Hora = new List<Palestra>();
            List<Palestra> Trilha02Hora = new List<Palestra>();

            int Tamanho = 3;
            while (Tamanho <= 8 && (Trilha01Hora.Count == 0 && Trilha02Hora.Count == 0))
            {
                if (Trilha01Hora.Count == 0) Trilha01Hora = Recursivo(Trilha01, Tamanho, string.Empty, 180);
                if (Trilha02Hora.Count == 0) Trilha02Hora = Recursivo(Trilha02, Tamanho, string.Empty, 180);

                Tamanho++;
            }

            if (Trilha01Hora.Count > 0 && Trilha02Hora.Count > 0)
            {
                List<Palestra> Trilha01Organizada = new List<Palestra>();
                Trilha01Organizada.AddRange(Trilha01Hora);
                Trilha01Organizada.Add(new Palestra() { Index = "K", Descricao = "Almoço", Duracao = new TimeSpan(0, 60, 0) });
                Trilha01Organizada.AddRange(Trilha01.Where(x => !Trilha01Organizada.Aggregate(string.Empty, (a, b) => string.Format("{0}'{1}',", a, b.Index)).Contains(x.Index)).ToList());
                Trilha01Organizada.Add(new Palestra() { Index = "L", Descricao = "Evento de Networking", Duracao = new TimeSpan(0, 0, 0) });

                DateTime Data = Convert.ToDateTime(string.Format("{0} 09:00:00", DateTime.Now.ToString("dd/MM/yyyy")));
                Console.WriteLine("Trilha 01");
                foreach (Palestra Palestra in Trilha01Organizada)
                {
                    Console.WriteLine(string.Format("{0}: {1} - {2} min", Data.ToString("HH:mm"), Palestra.Descricao, Palestra.Duracao.TotalMinutes.ToString()));
                    Data = Data.AddMinutes(Palestra.Duracao.TotalMinutes);
                }

                List<Palestra> Trilha02Organizada = new List<Palestra>();
                Trilha02Organizada.AddRange(Trilha02Hora);
                Trilha02Organizada.Add(new Palestra() { Index = "M", Descricao = "Almoço", Duracao = new TimeSpan(0, 60, 0) });
                Trilha02Organizada.AddRange(Trilha02.Where(x => !Trilha02Organizada.Aggregate(string.Empty, (a, b) => string.Format("{0}'{1}',", a, b.Index)).Contains(x.Index)).ToList());
                Trilha02Organizada.Add(new Palestra() { Index = "N", Descricao = "Evento de Networking", Duracao = new TimeSpan(0, 0, 0) });

                Console.WriteLine(Environment.NewLine + "---------------------" + Environment.NewLine);
                Data = Convert.ToDateTime(string.Format("{0} 09:00:00", DateTime.Now.ToString("dd/MM/yyyy")));

                Console.WriteLine("Trilha 02");
                foreach (Palestra Palestra in Trilha02Organizada)
                {
                    Console.WriteLine(string.Format("{0}: {1} - {2} min", Data.ToString("HH:mm"), Palestra.Descricao, Palestra.Duracao.TotalMinutes.ToString()));
                    Data = Data.AddMinutes(Palestra.Duracao.TotalMinutes);
                }
            }
        }

        public static List<Palestra> Recursivo(List<Palestra> ListaPalestra, int Tamanho, string Combinacao, double TotalMinute)
        {
            List<Palestra> ListaEncontrada = new List<Palestra>();

            foreach (string Letra in ListaPalestra.Where(x => !Combinacao.Contains(x.Index)).ToList().Select(x => x.Index))
            {
                string CombinacaoAuxiliar = Combinacao;
                int TamanhoAuxiliar = Tamanho;

                CombinacaoAuxiliar += Letra;

                if (TamanhoAuxiliar > 1)
                {
                    ListaEncontrada = Recursivo(ListaPalestra, TamanhoAuxiliar - 1, CombinacaoAuxiliar, TotalMinute);
                    if (ListaEncontrada.Count > 0) return ListaEncontrada;
                }

                else if (ListaPalestra.Where(x => CombinacaoAuxiliar.Contains(x.Index)).Sum(x => x.Duracao.TotalMinutes) == TotalMinute)
                    return ListaPalestra.Where(x => CombinacaoAuxiliar.Contains(x.Index)).ToList();
            }

            return ListaEncontrada;
        }
    }
}
