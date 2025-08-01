public class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }

    public override string ToString()
    {
        return $"{Nome} - {Cargo} - R${Salario:F2}";
    }
}