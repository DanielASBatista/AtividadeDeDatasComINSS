using System;
using System.Globalization;

namespace ExerciciosAula02
{
    public class Program
    {
        static void Main(string[] args)
        {
            CalcularDescontoINSS();
        }

        public static void DetalharData()
        {
            Console.WriteLine("Digite a data (ex: 26/08/2025):");
            string entrada = Console.ReadLine();

            if (!DateTime.TryParse(entrada, out DateTime data))
            {
                Console.WriteLine("Data inválida. Tente novamente.");
                return;
            }

            // Dia da semana e mês por extenso em PT-BR
            string diaSemana = data.ToString("dddd", new CultureInfo("pt-BR"));
            diaSemana = char.ToUpper(diaSemana[0]) + diaSemana.Substring(1);

            string mesExtenso = data.ToString("MMMM", new CultureInfo("pt-BR"));
            mesExtenso = char.ToUpper(mesExtenso[0]) + mesExtenso.Substring(1);

            Console.WriteLine($"Dia da semana: {diaSemana}");
            Console.WriteLine($"Mês: {mesExtenso}");

            // Se for domingo → mostrar hora atual
            if (data.DayOfWeek == DayOfWeek.Sunday)
            {
                string horaAtual = DateTime.Now.ToString("HH:mm");
                Console.WriteLine($"Hoje é domingo! Hora atual: {horaAtual}");
            }
        }

        public static void CalcularDescontoINSS()
        {
            decimal salario;

            // Entrada validada
            do
            {
                Console.Write("Digite o salário: ");
                string entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("O salário não pode ser vazio.");
                    continue;
                }
                if (!decimal.TryParse(entrada, out salario))
                {
                    Console.WriteLine("O valor digitado não é um número válido.");
                    continue;
                }
                if (salario <= 0)
                {
                    Console.WriteLine("O salário deve ser maior que 0.");
                    continue;
                }
                break;

            } while (true);

            decimal aliquota = 0m;

            // Definindo a alíquota conforme a tabela
            if (salario <= 1212.00m)
                aliquota = 0.075m;
            else if (salario <= 2427.35m)
                aliquota = 0.09m;
            else if (salario <= 3641.03m)
                aliquota = 0.12m;
            else if (salario <= 7087.22m)
                aliquota = 0.14m;
            else
                aliquota = 0.14m; // salário acima do teto, aplica limite (valor fixo sobre 7087,22 normalmente)

            // Cálculo do desconto
            decimal desconto = salario * aliquota;
            decimal salarioLiquido = salario - desconto;

            Console.WriteLine($"Salário bruto: {salario:C}");
            Console.WriteLine($"Alíquota aplicada: {aliquota:P}");
            Console.WriteLine($"Desconto de INSS: {desconto:C}");
            Console.WriteLine($"Salário líquido: {salarioLiquido:C}");
        }
    }
}