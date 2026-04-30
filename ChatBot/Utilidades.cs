using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot;

internal class Utilidades
{

    internal static void CargarVariableDeEntorno()
    {
        foreach (var linea in File.ReadAllLines(".env"))
        {
            // LLAVE=VALOR
            var partes = linea.Split('=', 2);
            if (partes.Length == 2) {
                var llave = partes[0].Trim();
                var valor = partes[1].Trim();
                Environment.SetEnvironmentVariable(llave, valor);
            }   

        }

    }


}
