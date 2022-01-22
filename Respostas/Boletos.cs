using System;
using System.Collections.Generic;
using System.Text;


namespace Respostas
{
    class Boletos
    {
        double Valor { get; set; }
        DateTime DataVencimento { get; set; }
        DateTime NovaData { get; set; }


        public Boletos()
        {
        }

        internal object CalculaBoletos(double valorBoleto, DateTime dataNova, DateTime dataOriginal)
        {
            DateTime dNova = dataNova;
            DateTime dvelha = dataOriginal;
            double valorT = 0.0;
            

            var utils = new Utils();
            var feriado = utils.GetHolidaysByCurrentYear(dvelha.Year);
            bool findi = false;

            foreach (var day in feriado)
            {
                if (dvelha == day && dvelha.DayOfWeek == DayOfWeek.Saturday)
                    dvelha = dvelha.AddDays(2);
                else if (dvelha == day && dvelha.DayOfWeek == DayOfWeek.Friday)
                    dvelha = dvelha.AddDays(3);
                else if(dvelha == day)
                    dvelha = dvelha.AddDays(1);
            }

            if (dvelha.DayOfWeek == DayOfWeek.Sunday)
            {
                dvelha = dvelha.AddDays(1);
                findi = true;
            }                
            if (dvelha.DayOfWeek == DayOfWeek.Saturday)
            {
                dvelha = dvelha.AddDays(2);
                findi = true;
            }

            TimeSpan dataCob = dNova.Subtract(dvelha);
            if (dvelha.DayOfWeek != DayOfWeek.Sunday || dvelha.DayOfWeek != DayOfWeek.Saturday)
                 valorT = (dataCob.Days * 0.03) + valorBoleto;

            if (findi != true && dataCob.Days >= 1)
                valorT += 2;

            return valorT;
        }
    }
}
