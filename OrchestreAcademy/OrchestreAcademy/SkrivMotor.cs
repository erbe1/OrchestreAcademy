using System;
using System.Collections.Generic;
using System.Text;
using OrchestreAcademy.Domän;


namespace OrchestreAcademy
{
    class SkrivMotor
    {
        internal void Skriv(string text = "")
        {
            Console.WriteLine(text);
        }


        internal void SkrivLista(List<string> list, int j)
        {
            int l = 0;
            for (int i = 0; i < list.Count / j; i++)
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

        internal void Skrivskärm(List<string> menyvalslista)
        {
            Skärmstorlek();
            Ram();
            Rubrik("Huvudmeny");
            Meny(menyvalslista);
        }

        internal void Logga() //Finns risk att metoderna är lite röriga...
        {
            //Rubrik();


            //Console.WriteLine(@"        ,");
            //Console.WriteLine(@"        |\        __");
            //Console.WriteLine(@"        | |      |--|             __");
            //Console.WriteLine(@"        |/       |  |            |--|");
            //Console.WriteLine(@"       /|_      () ()            | ()");
            //Console.WriteLine(@"      //| \             |\      ()");
            //Console.WriteLine(@"     | \|_ |            | \");
            //Console.WriteLine(@"      \_|_/            ()  |");
            //Console.WriteLine(@"        |                  |");
            //Console.WriteLine(@"       @'                 ()");

        }

        internal void Ram()
        {
            Console.SetCursorPosition(30, 3);
            for (int i = 0; i < 90; i++)
            {
                Console.Write("▄");
            }

            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(30, 4 + i);
                Console.WriteLine("█");
            }

            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(119, 4 + i);
                Console.WriteLine("█");
            }

            Console.SetCursorPosition(30, 34);
            for (int i = 0; i < 90; i++)
            {
                Console.Write("▀");
            }
        }

        internal void Rubrik(string text)
        {
            Console.SetCursorPosition(70, 0);
            Console.WriteLine(text);
            //Ram();
        }

        internal void Meny(List<string> menyvalslista) 
        {
            Console.SetCursorPosition(30, 35);
            Console.WriteLine("Menyval");
            int i = 1;
            int k = 30;
            foreach (var item in menyvalslista)
            {
                Console.SetCursorPosition(k, 36);
                Console.Write($"{i}) {item}");
                k = item.Length + k + 5;
                i++;
            }
            Console.SetCursorPosition(30, 37);
            Console.Write("Ange ditt val: ");
        }

        internal void Skärmstorlek()
        {
            Console.SetWindowPosition(0, 0);
            Console.Clear();
            Console.Title = "OrchestreAcademy";
            Console.SetWindowSize(150, 50);
            Console.BufferWidth = 150;
            Console.BufferHeight = 50;

            Logga();
        }

    }
}
