using System;
using System.Collections.Generic;
using System.Text;

namespace Respostas
{
    class Resposta4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Recalculo dos Boletos");
            Console.WriteLine("Informe a Data de Vencimento(ORIGINAL). 00/00/00 ");
            DateTime dataOriginal = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Informe a Data de Vencimento(NOVA). 00/00/00 ");
            DateTime dataNova = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Informe o valor do Boleto: ");
            double valorBoleto = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Boletos boletos = new Boletos();

            double valorNovo = (double)boletos.CalculaBoletos(valorBoleto, dataNova, dataOriginal);

            var valorJuros = valorNovo - valorBoleto;

            Console.WriteLine("Valor do Boleto Recalculado: " + valorNovo);
            Console.WriteLine("Valor do Juros sobre o Boleto: " + valorJuros);
        }
    }
}
