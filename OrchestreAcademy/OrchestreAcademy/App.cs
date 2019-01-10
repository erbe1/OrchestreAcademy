using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            skrivmotor.Ram();
            skrivmotor.Meny();
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
                textsträng.Add(item.TelefonNummer.ToString());

            }
            skrivmotor.SkrivLista(textsträng);

            //Här skulle man vilja ha ett val att välja enskilda musiker för att titta närmare på vad de spelar.
            MenyOchVal();
            

            //SeAllaMusiker();
            
        }

        private void MenyOchVal()
        {
            skrivmotor.Skriv();
            skrivmotor.Skriv("Gå vidare till:");
            skrivmotor.Skriv("a) Se instrument och nivå för enskilda musiker");
            skrivmotor.Skriv("b) Se tillgängliga instrument");
            skrivmotor.Skriv("c) Tillbaka till musikermenyn\n");

            var val = Console.ReadKey(true).Key;

            switch (val)
            {
                case ConsoleKey.A:
                    Console.Clear();
                    skrivmotor.SkrivLista(hämtadata.SeEnskildMusiker());
                    MenyOchVal();
                    break;
                case ConsoleKey.B:
                    Console.Clear();
                    skrivmotor.SkrivLista(hämtadata.SeTillgängligaInstrument());
                    MenyOchVal();
                    break;
                case ConsoleKey.C:
                    Console.Clear();
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
