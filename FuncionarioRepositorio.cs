using System.Collections.Generic;
using System.IO;

public static class FuncionarioRepositorio
{
    private static string caminho = "dados.txt";

    public static void Salvar(Funcionario f)
    {
        File.AppendAllLines(caminho, new[] { $"{f.Nome};{f.Cargo};{f.Salario}" });
    }

    public static List<Funcionario> Carregar()
    {
        var lista = new List<Funcionario>();
        if (!File.Exists(caminho)) return lista;

        foreach (var linha in File.ReadAllLines(caminho))
        {
            var dados = linha.Split(';');
            if (dados.Length == 3)
            {
                lista.Add(new Funcionario
                {
                    Nome = dados[0],
                    Cargo = dados[1],
                    Salario = decimal.Parse(dados[2])
                });
            }
        }
        return lista;
    }
}