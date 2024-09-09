using System;
using System.Collections.Generic;

public class Veiculo
{
    public string Placa { get; set; }
    public DateTime Entrada { get; set; }

    public Veiculo(string placa)
    {
        Placa = placa;
        Entrada = DateTime.Now;
    }
}

public class Estacionamento
{
    private Dictionary<string, Veiculo> veiculos = new Dictionary<string, Veiculo>();
    private const decimal ValorPorHora = 5.0m; // Valor cobrado por hora

    public void AdicionarVeiculo(string placa)
    {
        if (veiculos.ContainsKey(placa))
        {
            Console.WriteLine("Veículo já está estacionado.");
        }
        else
        {
            veiculos[placa] = new Veiculo(placa);
            Console.WriteLine($"Veículo com placa {placa} adicionado ao estacionamento.");
        }
    }

    public void RemoverVeiculo(string placa)
    {
        if (veiculos.ContainsKey(placa))
        {
            Veiculo veiculo = veiculos[placa];
            TimeSpan tempoEstacionado = DateTime.Now - veiculo.Entrada;
            decimal valorCobrado = (decimal)Math.Ceiling(tempoEstacionado.TotalHours) * ValorPorHora;

            veiculos.Remove(placa);
            Console.WriteLine($"Veículo com placa {placa} removido. Valor cobrado: {valorCobrado:C}");
        }
        else
        {
            Console.WriteLine("Veículo não encontrado.");
        }
    }

    public void ListarVeiculos()
    {
        if (veiculos.Count == 0)
        {
            Console.WriteLine("Nenhum veículo no estacionamento.");
        }
        else
        {
            Console.WriteLine("Veículos estacionados:");
            foreach (var veiculo in veiculos.Values)
            {
                Console.WriteLine($"Placa: {veiculo.Placa}, Entrada: {veiculo.Entrada}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Estacionamento estacionamento = new Estacionamento();
        
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Adicionar veículo");
            Console.WriteLine("2. Remover veículo");
            Console.WriteLine("3. Listar veículos");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();
            
            switch (opcao)
            {
                case "1":
                    Console.Write("Digite a placa do veículo: ");
                    string placaAdicionar = Console.ReadLine();
                    estacionamento.AdicionarVeiculo(placaAdicionar);
                    break;
                
                case "2":
                    Console.Write("Digite a placa do veículo: ");
                    string placaRemover = Console.ReadLine();
                    estacionamento.RemoverVeiculo(placaRemover);
                    break;
                
                case "3":
                    estacionamento.ListarVeiculos();
                    break;
                
                case "4":
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
