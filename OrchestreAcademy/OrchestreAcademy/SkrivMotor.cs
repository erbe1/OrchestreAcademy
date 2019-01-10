using System;
using System.Collections.Generic;
using System.Text;
using OrchestreAcademy.Domän;


namespace OrchestreAcademy
{
    class SkrivMotor
    {
        const int vänstermarginal = 30;
        const int rambredd = 90;
        const int topmarginal = 3;
        const int ramhöjd = 30;


        List<string> logga = new List<string>
            { @"        .",
              @"        |\        __",
              @"        | |      |--|             __",
              @"        |/       |  |            |--|",
              @"       /|_      () ()            | ()",
              @"      //| \             |\      ()",
              @"     | \|_ |            | \",
              @"      \_|_/            ()  |",
              @"        |                  |",
              @"       @'                 ()",
              @"",
              @"",
              @"",
              @"",
              @"                  _  __ _  _     /\            _     ",
              @"                 | |/ /| || |_  |/\|     /\   | |    ",
              @"                 | ' /_  __  _|         /  \  | |__  ",
              @"                 |  < _| || |_         / /\ \ | '_ \ ",
              @"                 | . \_  __  _|       / ____ \| |_) |",
              @"                 |_|\_\|_||_|        /_/    \_\_.__/ "
            };

        internal void Skriv(string text = "")
        {
            Console.WriteLine(text);
        }

        internal void SkrivLista(List<string> list, int kolumner)
        {
            int listobjekt = 0;
            
            for (int rad = 0; rad < list.Count / kolumner; rad++)
            {
                Console.SetCursorPosition(vänstermarginal + 3, topmarginal + rad + 3);
                string text = "";
                for (int k = 0; k < kolumner; k++)
                {
                    text = text + list[listobjekt].PadRight(20);
                    listobjekt++;
                }
                Console.Write(text);
            }
        }

        internal void Skrivskärm(List<string> menyvalslista, string rubrik = "Huvudmeny", List<string> raminnehåll = null, int kolumner = 1)
        {
            if (raminnehåll == null)
            {
                raminnehåll = logga;
            }
            Skärmstorlek();
            Ram();
            SkrivLista(raminnehåll, kolumner);
            Rubrik(rubrik);
            Meny(menyvalslista);

        }

        //internal List<string> Logga()
        //{

        //    return logga;
        //}

        internal void Ram()
        {
            Console.SetCursorPosition(vänstermarginal, topmarginal);
            for (int i = 0; i < rambredd; i++)
            {
                Console.Write("▄");
            }

            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(vänstermarginal, topmarginal + 1 + i);
                Console.WriteLine("█");
            }

            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(vänstermarginal + rambredd - 1, topmarginal + 1 + i);
                Console.WriteLine("█");
            }

            Console.SetCursorPosition(vänstermarginal, topmarginal + ramhöjd + 1);
            for (int i = 0; i < rambredd; i++)
            {
                Console.Write("▀");
            }
        }

        internal void Rubrik(string text)
        {
            Console.SetCursorPosition(70, 0);
            Console.WriteLine(text);
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

            //Logga();
        }

    }
}
