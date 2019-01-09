using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchestreAcademy
{
    public class App
    {
        HämtaData hamtadata = new HämtaData();

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

            foreach (var item in instrument)
            {
                Console.WriteLine(item);
            }
        }

        private void MusikerMeny()
        {
            SeAllaEvent();
        }

    }
}
