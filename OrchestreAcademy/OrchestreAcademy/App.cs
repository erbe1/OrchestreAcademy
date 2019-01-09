using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchestreAcademy
{
    public class App
    {
        HamtaData hamtadata = new HamtaData();

        internal void Kör()
        {
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

            List<string> instrument = hamtadata.VisaInstrument(); //LIgger var?? + Inget innehåll i metoden
        }

        private void MusikerMeny()
        {
            SeAllaEvent();
        }

    }
}
