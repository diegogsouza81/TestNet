using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAppApi.Extensions
{
    public static class IntExtensions
    {
        public static void TestFatorial()
        {
            int numero = 10;
            while (numero!=1)
            {
                CalculaFatorial(numero);
            }
        }
        public static  double CalculaFatorial(int numero)
        {
            //fim de fatorial
            if (numero == 1)
                return 1;
            else
                return numero * CalculaFatorial(numero - 1);
        }
    }
}