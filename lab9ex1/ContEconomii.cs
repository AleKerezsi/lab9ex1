using System;
using System.Collections.Generic;
using System.Text;

namespace lab9ex1
{
    public class ContEconomii: ContBancar
    {
        protected int RataDobanda { get; set; }

        public ContEconomii(int rataDobanda)
        {
            this.Id = Guid.NewGuid();
            this.RataDobanda = rataDobanda;
        }

        public override void DepuneBani(int bani)
        {
            Console.WriteLine($"Se depun {bani} lei.");

            SoldCurent = (SoldCurent * (1 + RataDobanda)) + bani;
        }

        public override int ExtrageBani(int bani)
        {
            Console.WriteLine($"Se doresc {bani} lei extrasi.");

            if (SoldCurent <= 0)
            {
                Console.WriteLine($"----- Soldul dvs. este 0. Nu mai puteti face extrageri -----");
                return 0;
            }

            SoldCurent = SoldCurent - bani;
            return bani;
        }

        public override string ToString()
        {
            if (SoldCurent > 0) return $"Contul curent cu ID-ul {Id}, numele '{Nume}' are soldul curent {SoldCurent} lei. Rata dobanzii este {RataDobanda}";
            else return $"Contul curent cu ID-ul {Id}, numele '{Nume}' are soldul curent 0 lei. Rata dobanzii este {RataDobanda}";
        }
    }
}
