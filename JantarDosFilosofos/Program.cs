using System;
using System.Threading;

class Filosofo
{
    private int id;
    private string nome;
    private SemaphoreSlim garfoEsquerdo;
    private SemaphoreSlim garfoDireito;

    public Filosofo(int id, string nome, SemaphoreSlim garfoEsquerdo, SemaphoreSlim garfoDireito)
    {
        this.id = id;
        this.nome = nome;
        this.garfoEsquerdo = garfoEsquerdo;
        this.garfoDireito = garfoDireito;
    }

    public void Viver()
    {
        while (true)
        {
            Pensar();
            Comer();
        }
    }

    private void Pensar()
    {
        Console.ForegroundColor = ConsoleColor.Green; // Cor verde para "pensando"
        Console.WriteLine($"Filósofo {nome} está pensando.");
        Console.ResetColor();
        Thread.Sleep(new Random().Next(1000, 3000)); // Simula o tempo de pensamento
    }

    private void Comer()
    {
        Console.ForegroundColor = ConsoleColor.Red; // Cor vermelha para "pegando garfos"
        if (id % 2 == 0)
        {
            garfoEsquerdo.Wait();
            Console.WriteLine($"Filósofo {nome} pegou o garfo esquerdo.");
            garfoDireito.Wait();
            Console.WriteLine($"Filósofo {nome} pegou o garfo direito.");
        }
        else
        {
            garfoDireito.Wait();
            Console.WriteLine($"Filósofo {nome} pegou o garfo direito.");
            garfoEsquerdo.Wait();
            Console.WriteLine($"Filósofo {nome} pegou o garfo esquerdo.");
        }

        Console.ForegroundColor = ConsoleColor.Blue; // Cor azul para "comendo"
        Console.WriteLine($"Filósofo {nome} está comendo.");
        Console.ResetColor();
        Thread.Sleep(new Random().Next(1000, 3000)); // Simula o tempo de refeição

        Console.ForegroundColor = ConsoleColor.Red; // Cor vermelha para "liberando garfos"
        garfoEsquerdo.Release();
        Console.WriteLine($"Filósofo {nome} liberou o garfo esquerdo.");
        garfoDireito.Release();
        Console.WriteLine($"Filósofo {nome} liberou o garfo direito.");
        Console.ResetColor();
    }
}

class Program
{
    static void Main(string[] args)
    {
        int numFilosofos = 5;
        string[] nomes = { "Sócrates", "Platão", "Aristóteles", "Descartes", "Tonhão" }; // Nomes dos filósofos
        SemaphoreSlim[] garfos = new SemaphoreSlim[numFilosofos];
        for (int i = 0; i < numFilosofos; i++)
        {
            garfos[i] = new SemaphoreSlim(1, 1); // Cada garfo é um semáforo com capacidade 1
        }

        Filosofo[] filosofos = new Filosofo[numFilosofos];
        for (int i = 0; i < numFilosofos; i++)
        {
            filosofos[i] = new Filosofo(i, nomes[i], garfos[i], garfos[(i + 1) % numFilosofos]);
        }

        Thread[] threads = new Thread[numFilosofos];
        for (int i = 0; i < numFilosofos; i++)
        {
            threads[i] = new Thread(new ThreadStart(filosofos[i].Viver));
            threads[i].Start();
        }

        Console.ReadLine(); // Mantém o programa rodando
    }
}