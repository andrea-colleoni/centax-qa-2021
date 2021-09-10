using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityCL
{
    public class WebService
    {
        public virtual string TestProp  { get; set; }
        public virtual Classe TestObj { get; set; }


        public virtual int FattoreA(int k)
        {
            return 20 * k;
        }

        public virtual int FattoreB()
        {
            return 20;
        }

        public virtual int FattoreC(int k)
        {
            return k;
        }
        public virtual string FattoreS(string arg)
        {
            return arg.ToLower();
        }
        public virtual async Task<string> FattoreAsync()
        {
            return "pippo";
        }
        public virtual Classe Classe()
        {
            var c = new Classe();
            c.Prop1 = "Ciao";
            c.Prop2 = 20;
            return c;
        }
    }
}
