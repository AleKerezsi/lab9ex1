using System;
using System.Collections.Generic;
using System.Text;

namespace lab9ex1
{
   public abstract class ContBancar
    {
        public string Nume { get; set; }
        protected int SoldCurent { get; set; } = 0;
        protected Guid Id { get; set; }

        public abstract void DepuneBani(int bani);

        public abstract int ExtrageBani(int bani);

        public abstract override string ToString();


    }
}
