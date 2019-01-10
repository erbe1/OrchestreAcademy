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
            skrivmotor.Skärmstorlek();
            skrivmotor.Meny();
            SeAllaEvent();
            ArrangörMeny();
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
            SeAllaEvent();
        }

        private void SeAllaMusiker()
        {
            //Här skrivs musikerlistan ut, på något sätt
            skrivmotor.Skriv("Tillgängliga musiker\n");
            List<Person> personLista = hämtadata.VisaMusiker();
            List<string> textsträng = new List<string>();
            foreach (var item in personLista)
            {
                textsträng.Add(item.Förnamn);
                textsträng.Add(item.Efternamn);
            }
            skrivmotor.SkrivLista(textsträng, 2);
            Console.WriteLine();

            //Här skulle man vilja ha ett val att välja enskilda musiker för att titta närmare på vad de spelar.
            //Gärna även ett val att gruppera musiker efter instrument. Allt ska givitvis skrivas
            MenyOchVal();
            

            //SeAllaMusiker();
            
        }

        private void MenyOchVal()
        {
            skrivmotor.Skriv("Gå vidare till:");
            skrivmotor.Skriv("a) Se instrument och nivå för enskilda musiker");
            skrivmotor.Skriv("b) Se tillgängliga instrument");
            skrivmotor.Skriv("c) Tillbaka till musikermenyn\n");

            var val = Console.ReadKey(true).Key;

            switch (val)
            {
                case ConsoleKey.A:
                    Console.Clear();
                    skrivmotor.SkrivLista(hämtadata.SeEnskildMusiker(), 1);
                    break;
                case ConsoleKey.B:
                    Console.Clear();
                    skrivmotor.SkrivLista(hämtadata.SeTillgängligaInstrument(), 1);
                    break;
                case ConsoleKey.C:
                    MusikerMeny();
                    break;
                default:
                    break;
            }
        }

        private void SeEnskildMusiker()
        {
            throw new NotImplementedException();
        }


    }
}
