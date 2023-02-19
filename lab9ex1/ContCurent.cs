using System;
using System.Collections.Generic;
using System.Text;

namespace lab9ex1
{
    public class ContCurent: ContBancar
    {
        private const int Plafon = 5000;
        private int SoldContDescoperit { get; set; }

        public ContCurent() 
        {
            Id = Guid.NewGuid();
        }

        public override void DepuneBani(int bani)
        {
            Console.WriteLine($"Se depun {bani} lei.");

            if (SoldCurent < 0)
            {
                SoldCurent = bani;
                return;
            }

            SoldCurent = SoldCurent + bani;
        }

        public override int ExtrageBani(int bani)
        {
            Console.WriteLine($"Se doresc {bani} lei extrasi.");

            if(SoldCurent==0)
            {
               if(bani<Plafon && SoldContDescoperit< Plafon)
                {
                    SoldContDescoperit = SoldContDescoperit + bani;
                    return bani;
                }
                else Console.WriteLine($"----- Soldul dvs. este 0 si ati depasit plafonul alocat pentru descoperire, de {Plafon} lei. Nu mai puteti face extrageri -----");
            }

            if(SoldCurent<bani)
            {
                SoldCurent = SoldCurent - bani;

                int baniDescoperiti = Math.Abs(SoldCurent);

                if (baniDescoperiti == Plafon) 
                {
                    SoldContDescoperit = baniDescoperiti;
                    return bani;
                }

                if (baniDescoperiti < Plafon && SoldContDescoperit < Plafon)
                {
                    SoldContDescoperit = SoldContDescoperit + baniDescoperiti;
                    return bani;
                }
                else Console.WriteLine($"----- Soldul dvs. este 0 si ati depasit plafonul alocat pentru descoperire de {Plafon} lei. Nu mai puteti face extrageri -----");

            }

            SoldCurent = SoldCurent - bani;
            return bani;
        }

        public override string ToString()
        {
            if (SoldCurent > 0) return $"Contul curent cu ID-ul {Id}, numele '{Nume}' are soldul curent {SoldCurent} lei, plafonul fix de {Plafon} lei - din care {SoldContDescoperit} lei au fost utilizati.";
            else return $"Contul curent cu ID-ul {Id}, numele '{Nume}' are soldul curent 0 lei, plafonul fix de {Plafon} lei - din care {SoldContDescoperit} lei au fost utilizati.";
        }

    }
}
