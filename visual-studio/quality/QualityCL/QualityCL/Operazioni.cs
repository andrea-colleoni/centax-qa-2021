using System;

namespace QualityCL
{
    public class Operazioni
    {
        /// <summary>
        /// accetta valori tra -100 e 100
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Somma(int a, int b)
        {
            if (a > 100 || b > 100 || a < -100 || b < -100)
                throw new Exception("valori fuori limite");
            return a + b;
        }

        /// <summary>
        /// qu
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Prodotto(int a)
        {
            return ( a * new WebService().FattoreB() );
        }
    }
}
