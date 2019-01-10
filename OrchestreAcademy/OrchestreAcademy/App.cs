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
            Event eventet = new Event();
            eventet.EventId = 1;
            List<Event> valtEvent = hämtadata.VisaAlltIEttEvent(eventet.EventId);
            List<string> textLista = new List<string>();
            
            foreach (var item in valtEvent)
            {
                textLista.Add(item.EventId.ToString());
                textLista.Add(item.Stycke);
                textLista.Add(item.Namn);
                textLista.Add(item.Instrumet);

            }
            skrivmotor.SkrivLista(textLista, 4);
            Huvudmeny();
        }

        private void Huvudmeny()
        {
            //Skriv ut menyn med snyggfont osv

            SeAllaEvent();
            ArrangörMeny();
            MusikerMeny();
        }

        private void SeAllaEvent()
        {
            //Visa alla event
        }
        private void ArrangörMeny()
        {
            SeAllaEvent();
            //SeAllaMusiker();
            //SeAllaStycken();
            //SkapaEvent();

            List<string> instrument = hämtadata.VisaInstrument(); //LIgger var?? + Inget innehåll i metoden
        }

        private void MusikerMeny()
        {
            SeAllaEvent();
        }

    }
}
