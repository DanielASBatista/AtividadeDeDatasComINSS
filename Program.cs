//Daniel Alves dos Santos Batista - RM:251376
//Hernan Rodrigo - RM: 251169

using System;
using System.Globalization;

namespace ExerciciosDataEINSS
{
    public class Program
    {
//Método seletor de funções 
        static void Main(string[] args)
        {
            FuncaoSeletoraDeMetodos();
        }

        public static void FuncaoSeletoraDeMetodos()
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine("****** Exemplos - Aula 02 Descrição de Data e Calculo de INSS ******");
            Console.WriteLine("====================================================================");
            int opcaoEscolhida = 0;
            do
            {
                Console.WriteLine("\n================================================");
                Console.WriteLine("---Digite o número referente à opção desejada: ---");
                Console.WriteLine("1 - Descrição de data por extenso");
                Console.WriteLine("2 - Calculo de desconto do INSS");
                Console.WriteLine("==================================================");
                Console.WriteLine("-----Ou tecle qualquer outro número para sair-----");
                Console.WriteLine("==================================================");
                opcaoEscolhida = int.Parse(Console.ReadLine());
                string mensagem = string.Empty;
                switch (opcaoEscolhida)
                {
                    case 1:
                        DetalharData();
                        break;

                    case 2:
                        CalcularDescontoINSS();
                        break;
                    default:
                        Console.WriteLine("Saindo do sistema....");
                        break;
                }
        } while (opcaoEscolhida >= 1 || opcaoEscolhida >= 2);
        }
//Método que detalha a data por extenso
        public static void DetalharData()
        {
            DateTime data;

            while (true)
            {
                Console.WriteLine("Digite a data (ex: 26/08/2025):");
                string entrada = Console.ReadLine();

                if (DateTime.TryParse(entrada, out data))
                {
                    break;
                }

                Console.WriteLine("Data inválida. Tente novamente.");
            }


            string diaSemana = data.ToString("dddd", new CultureInfo("pt-BR"));
            diaSemana = char.ToUpper(diaSemana[0]) + diaSemana.Substring(1);

            string mesExtenso = data.ToString("MMMM", new CultureInfo("pt-BR"));
            mesExtenso = char.ToUpper(mesExtenso[0]) + mesExtenso.Substring(1);

            Console.WriteLine($"Dia da semana: {diaSemana}");
            Console.WriteLine($"Mês: {mesExtenso}");

// Se for domingo mostra a hora atual
            if (data.DayOfWeek == DayOfWeek.Sunday)
            {
                string horaAtual = DateTime.Now.ToString("HH:mm");
                Console.WriteLine($"Hoje é domingo! Hora atual: {horaAtual}");
            }
        }
//Método que calcula o desconto do INSS
        public static void CalcularDescontoINSS()
        {
            decimal salario;

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