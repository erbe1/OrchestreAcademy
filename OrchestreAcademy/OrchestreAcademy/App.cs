using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchestreAcademy.Domän;

namespace OrchestreAcademy
{
    public class App
    {
        HämtaData hämtadata = new HämtaData();
        SkrivMotor skrivmotor = new SkrivMotor();

        internal void Kör()
        {
            Huvudmeny();
        }

        private void Huvudmeny()
        {
            //Skriv ut menyn med snyggfont osv
            List<string> menyvalslista = new List<string> { "Se alla event", "Se val för arrangörer", "Se val för musiker" };
            skrivmotor.Skrivskärm(menyvalslista);
            
            //SeAllaEvent();
            //ArrangörMeny();
            //MusikerMeny();
        }

        private void SeAllaEvent()
        {
            //Visa alla event
        }
        private void ArrangörMeny()
        {
            //SeAllaEvent();
            SeAllaMusiker();
            //SeAllaStycken();
            //SeSättningar();
            //SkapaEvent();

        }
        private void MusikerMeny()
        {
            List<string> menyvalslista = new List<string> { "x", "y", "z" };
            skrivmotor.Skrivskärm(menyvalslista);

        }

        private void SeAllaMusiker()
        {
            //Här skrivs musikerlistan ut, på något sätt
            //Det här skrivs in i fältet
            List<string> musikerlista = ListaAllaMusiker();
            List<string> menyvalslista = new List<string> { "Se instrument och nivå för enskild musiker", "Se tillgängliga instrument", "Tillbaka till huvudmeny" };
            skrivmotor.Skrivskärm(menyvalslista, musikerlista, 4);


            //Val i menyn
            var val = Console.ReadKey(true).Key;
            switch (val)
            {
                case ConsoleKey.A:
                    Console.Clear();
                    List<string> musikerlista2 = ListaAllaMusiker();
                    List<string> menyvalslista2 = new List<string> { "Se instrument och nivå för enskild musiker", "Se tillgängliga instrument", "Tillbaka till huvudmeny" };
                    skrivmotor.Skrivskärm(menyvalslista2, musikerlista2, 2);
                    VisaInstrumentOchNivåFörEnskildMusiker();
                    break;
                case ConsoleKey.B:
                    Console.Clear();
                    skrivmotor.SkrivLista(hämtadata.SeTillgängligaInstrument(), 3);
                    break;
                case ConsoleKey.C:
                    MusikerMeny();
                    break;
                default:
                    break;
            }
        }

        private void VisaInstrumentOchNivåFörEnskildMusiker()
        {
            List<string> instrumentochnivålista =  ListaAllaMusiker();
            List<string> menyvalslista = new List<string> { "Tillbaka till arrangörmeny", "Tillbaka till huvudmeny" };
            skrivmotor.Skrivskärm(menyvalslista, instrumentochnivålista, 2);

            var val = Console.ReadKey(true).Key;
            switch (val)
            {
                case ConsoleKey.A:
                    Console.Clear();
                    ArrangörMeny();
                    break;
                case ConsoleKey.B:
                    Console.Clear();
                    Huvudmeny();
                    break;
                default:
                    break;
            }

            string musikerval =
            VisaInstrumentOchNivåFörEnskildMusiker();
        }

        private List<string> ListaInstrumentOchNivåFörEnskildMusiker()
        {
            List<Person> instrumentlista = hämtadata.InstrumentOchNivåFörEnskildaMusiker();
            List<string> instrumentlistasträng = new List<string>();
            foreach (var item in instrumentlista)
            {
                instrumentlistasträng.Add(item.InstrumentNamn);
                instrumentlistasträng.Add(item.Nivå.ToString());

            }
            return instrumentlistasträng;
        }

        private List<string> ListaAllaMusiker()
        {
            List<Person> personLista = hämtadata.VisaMusiker();
            List<string> textsträng = new List<string>();
            foreach (var item in personLista)
            {
                textsträng.Add(item.Förnamn);
                textsträng.Add(item.Efternamn);
                textsträng.Add(item.Telefonnummer.ToString());
            }
            return textsträng;
        }
    }
}
