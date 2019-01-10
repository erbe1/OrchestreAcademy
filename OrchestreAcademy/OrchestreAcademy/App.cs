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
             List<string> menyvalslista = new List<string> { "Se alla event", "Se val för arrangörer", "Se val för musiker" };
            skrivmotor.Skrivskärm(menyvalslista);

            var val = Console.ReadKey();
            int i = int.Parse(val.KeyChar.ToString());
            switch (i)
            {
                case 1:
                    SeAllaEvent();
                    break;
                case 2:
                    ArrangörMeny();
                    break;
                case 3:
                    MusikerMeny();
                    break;
                default:
                    break;
            }
        }

        private void SeAllaEvent()
        {
            //Visa alla event
        }
        private void ArrangörMeny()
        {
            List<string> menyvalslista = new List<string> { "Se mina event", "Skapa nytt event", "Se tillgängliga musiker", "Återgå till huvudmeny" };
            skrivmotor.Skrivskärm(menyvalslista, "Arrangörsmeny");

            var val = Console.ReadKey();
            int i = int.Parse(val.KeyChar.ToString());
            switch (i)
            {
                case 1:
                    SeMinaEvent();
                    break;
                case 2:
                    SkapaEvent();
                    break;
                case 3:
                    SeAllaMusiker();
                    break;
                case 4:
                    Huvudmeny();
                    break;
                default:
                    break;
            }


        }

        private void SkapaEvent()
        {
            throw new NotImplementedException();
        }

        private void SeMinaEvent()
        {
            throw new NotImplementedException();
        }

        private void MusikerMeny()
        {
            List<string> menyvalslista = new List<string> { "Se mina event", "Anmäl dig till event", "Återgå till huvudmeny" };
            skrivmotor.Skrivskärm(menyvalslista);

            List<string> musikermedid = MusikerMedId();

            skrivmotor.Skrivskärm(menyvalslista, "Musikermeny", musikermedid, 3);


            var val = Console.ReadKey();
            int i = int.Parse(val.KeyChar.ToString());
            switch (i)
            {
                case 1:
                    SeMinaEvent();
                    break;
                case 2:
                    SkapaEvent();
                    break;
                case 3:
                    Huvudmeny();
                    break;
                default:
                    break;
            }
        }

        private List<string> MusikerMedId()
        {
            List<Person> musikerlista = hämtadata.MusikerMedId();
            List<string> musikermedid = new List<string>();
            foreach (var musiker in musikerlista)
            {
                musikermedid.Add(musiker.Id.ToString());
                musikermedid.Add(musiker.Förnamn);
                musikermedid.Add(musiker.Efternamn);
            }
            return musikermedid;
        }

        private void SeAllaMusiker()
        {
            //Här skrivs musikerlistan ut, på något sätt
            //Det här skrivs in i fältet
            List<string> musikerlista = ListaAllaMusiker();
            List<string> menyvalslista = new List<string> { "Se instrument och nivå för enskild musiker", "Se tillgängliga instrument", "Tillbaka till huvudmeny" };
            skrivmotor.Skrivskärm(menyvalslista, "Alla musiker", musikerlista, 3);


            //Val i menyn
            var val = Console.ReadKey();
            int i = int.Parse(val.KeyChar.ToString());
            switch (i)
            {
                case 1:
                    Console.Clear();
                    List<string> musikerlista2 = ListaAllaMusiker();
                    List<string> menyvalslista2 = new List<string> { "Se instrument och nivå för enskild musiker", "Se tillgängliga instrument", "Tillbaka till huvudmeny" };
                    skrivmotor.Skrivskärm(menyvalslista2, "Musiker att välja på", musikerlista2, 2);
                    VisaInstrumentOchNivåFörEnskildMusiker();
                    break;
                case 2:
                    Console.Clear();
                    skrivmotor.SkrivLista(hämtadata.SeTillgängligaInstrument(), 3);
                    break;
                case 3:
                    Huvudmeny();
                    break;
                default:
                    break;
            }
        }

        private void VisaInstrumentOchNivåFörEnskildMusiker()
        {
            List<string> instrumentochnivålista =  ListaAllaMusiker();
            List<string> menyvalslista = new List<string> { "Tillbaka till arrangörmeny", "Tillbaka till huvudmeny" };
            skrivmotor.Skrivskärm(menyvalslista, "Instrument och nivå", instrumentochnivålista, 2);

            var val = Console.ReadKey();
            int i = int.Parse(val.KeyChar.ToString());
            switch (i)
            {
                case 1:
                    Console.Clear();
                    ArrangörMeny();
                    break;
                case 2:
                    Console.Clear();
                    Huvudmeny();
                    break;
                default:
                    break;
            }

            //int musikerval = int.Parse(Console.ReadLine());
            //VisaInstrumentOchNivåFörEnskildMusiker();
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
