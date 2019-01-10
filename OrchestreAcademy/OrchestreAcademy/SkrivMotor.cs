using System;
using System.Collections.Generic;
using System.Text;


namespace OrchestreAcademy
{
    class SkrivMotor
    {
     internal void SkrivLista(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        internal void Logga() //Finns risk att metoderna är lite röriga...
        {
            Rubrik();


            Console.WriteLine(@"        ,");
            Console.WriteLine(@"        |\        __");
            Console.WriteLine(@"        | |      |--|             __");
            Console.WriteLine(@"        |/       |  |            |--|");
            Console.WriteLine(@"       /|_      () ()            | ()");
            Console.WriteLine(@"      //| \             |\      ()");
            Console.WriteLine(@"     | \|_ |            | \");
            Console.WriteLine(@"      \_|_/            ()  |");
            Console.WriteLine(@"        |                  |");
            Console.WriteLine(@"       @'                 ()");

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

        internal void Rubrik()
        {
            Console.SetCursorPosition(70, 0);
            Console.WriteLine("Huvudmeny");
            Ram();
        }

        internal void Meny()
        {
            Console.SetCursorPosition(70, 35);
            Console.WriteLine("Menyval");
            Console.SetCursorPosition(60, 36);
            Console.Write("1. XXXXXX");
            Console.SetCursorPosition(70, 36);
            Console.Write("2. YYYYYY");
            Console.SetCursorPosition(80, 36);
            Console.Write("3. ZZZZZZ");
            Console.SetCursorPosition(60, 37);
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
