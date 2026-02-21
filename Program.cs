using System;
using System.Collections.Generic;

namespace ConsoleApp1;

abstract class Dispositivo
{
    public string Nome { get; set; }

    protected Dispositivo(string nome)
    {
        Nome = nome;
    }

    public abstract void Ativar();
    public abstract void Desativar();
}

class Luminaria : Dispositivo
{
    public int IntensidadeLuz { get; set; }

    public Luminaria(string nome, int intensidade) : base(nome)
    {
        IntensidadeLuz = intensidade;
    }

    public override void Ativar()
    {
        Console.WriteLine($"Luminária {Nome} ativada com intensidade {IntensidadeLuz}%.");
    }

    public override void Desativar()
    {
        Console.WriteLine($"Luminária {Nome} desligada.");
    }
}

class ArCondicionado : Dispositivo
{
    public int Temperatura { get; set; }

    public ArCondicionado(string nome, int temperatura) : base(nome)
    {
        Temperatura = temperatura;
    }

    public override void Ativar()
    {
        Console.WriteLine($"Ar-condicionado {Nome} ligado a {Temperatura}°C.");
    }

    public override void Desativar()
    {
        Console.WriteLine($"Ar-condicionado {Nome} desligado.");
    }
}

class Controlador
{
    public void Ativar(List<Dispositivo> dispositivos)
    {
        foreach (var d in dispositivos)
            d.Ativar();
    }

    public void Desativar(List<Dispositivo> dispositivos)
    {
        foreach (var d in dispositivos)
            d.Desativar();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var dispositivos = new List<Dispositivo>
        {
            new Luminaria("Lâmpada Sala", 80),
            new ArCondicionado("Ar Sala", 24),
            new Luminaria("Lâmpada Quarto", 60)
        };

        var controlador = new Controlador();

        controlador.Ativar(dispositivos);

        Console.WriteLine("\n=== Dispositivos Cadastrados ===");
        foreach (var d in dispositivos)
        {
            Console.Write($"{d.GetType().Name} - {d.Nome}");

            if (d is Luminaria l)
                Console.WriteLine($" | Intensidade: {l.IntensidadeLuz}%");
            else if (d is ArCondicionado a)
                Console.WriteLine($" | Temperatura: {a.Temperatura}°C");
        }

        Console.WriteLine("\nDesativando todos os dispositivos...");
        controlador.Desativar(dispositivos);
    }
}