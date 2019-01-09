using System;
using System.Collections.Generic;

namespace OrchestreAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            HamtaData hamtaData = new HamtaData();
            SkrivMotor skrivMotor = new SkrivMotor();
            List<string> instrument = hamtaData.VisaInstrument();
            skrivMotor.SkrivLista(instrument);
        }
    }
}
