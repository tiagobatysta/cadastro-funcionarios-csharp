using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("== Sistema de Cadastro de Funcionários ==");
            Console.WriteLine("1 - Cadastrar funcionário");
            Console.WriteLine("2 - Listar funcionários");
            Console.WriteLine("3 - Buscar por nome");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CadastrarFuncionario();
                    break;
                case "2":
                    ListarFuncionarios();
                    break;
                case "3":
                    BuscarFuncionario();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void CadastrarFuncionario()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Cargo: ");
        string cargo = Console.ReadLine();
        Console.Write("Salário: ");
        decimal salario = decimal.Parse(Console.ReadLine());

        var funcionario = new Funcionario { Nome = nome, Cargo = cargo, Salario = salario };
        FuncionarioRepositorio.Salvar(funcionario);
        Console.WriteLine("Funcionário cadastrado com sucesso!");
    }

    static void ListarFuncionarios()
    {
        var funcionarios = FuncionarioRepositorio.Carregar();
        Console.WriteLine("\n--- Funcionários Cadastrados ---");
        foreach (var f in funcionarios)
            Console.WriteLine(f);
    }

    static void BuscarFuncionario()
    {
        Console.Write("Digite o nome para buscar: ");
        string busca = Console.ReadLine();
        var funcionarios = FuncionarioRepositorio.Carregar();
        var resultado = funcionarios.FindAll(f => f.Nome.ToLower().Contains(busca.ToLower()));

        Console.WriteLine("\n--- Resultado da busca ---");
        if (resultado.Count == 0)
            Console.WriteLine("Nenhum funcionário encontrado.");
        else
            resultado.ForEach(Console.WriteLine);
    }
}