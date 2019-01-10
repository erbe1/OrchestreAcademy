using System;
using System.Collections.Generic;
using System.Text;


namespace OrchestreAcademy
{
    class SkrivMotor
    {
        internal void SkrivUtLista(List<string> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }

        internal void Skriv(string text = "")
        {
            Console.WriteLine(text);
        }
    }
}
