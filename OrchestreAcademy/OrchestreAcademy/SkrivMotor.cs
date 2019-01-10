using System;
using System.Collections.Generic;
using System.Text;


namespace OrchestreAcademy
{
    class SkrivMotor
    {
     internal void SkrivLista(List<string> list, int j)
        {
            int l = 0;
            for (int i = 0; i < list.Count/j ; i++)
            {

                    string s = "";
                for (int k = 0; k < j; k++)
                {

                    s = s + list[l].PadRight(40);

                        l++;
                }
                Console.WriteLine(s);
            }
        }

        

    }
}
