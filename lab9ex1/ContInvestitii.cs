using System;
using System.Collections.Generic;
using System.Text;

namespace lab9ex1
{
   public class ContInvestitii: ContEconomii
    {
        private int ZiTermenExtragere { get; set; }

        public ContInvestitii(int rataDobanda, int ziTermenExtragere) : base(rataDobanda)
        {
            if (ziTermenExtragere < 1 || ziTermenExtragere > 31) 
            {
                Console.WriteLine("Ziua specificata pentru termenul de extragere poate fi doar in intervalul 1-31.");
            }

            this.ZiTermenExtragere = ziTermenExtragere;
        }

        public override int ExtrageBani(int bani)
        {
            Console.WriteLine($"Se doresc {bani} lei extrasi.");

            if (DateTime.Now.Day >= ZiTermenExtragere)
            {
                if (SoldCurent <= 0)
                {
                    Console.WriteLine($"----- Soldul dvs. este 0. Nu mai puteti face extrageri -----");
                    return 0;
                }

                SoldCurent = SoldCurent - bani;
                return bani; 
            }

            Console.WriteLine("Extragerea nu se poate efectua inainte de termen.");
            return 0;
        }
    }
}
