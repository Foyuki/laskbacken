using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppdrag4_laskbacken
{
    class Program
    {
        static void Main(string[] args)
        {
            Sodacrate mySodacrate = new Sodacrate(); //Med hjälp av konstruktorn hämtar vi upp värden från class Sodacrate, i parentesen
            mySodacrate.Run(); //Anropar metoden run, dvs hela menyn och alla metoder

            Console.WriteLine("Press any key to continute...");
            Console.ReadKey(true);
        }
    }
}
