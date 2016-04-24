using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppdrag4_laskbacken
{
    class Soda //Klass med tre variabler men inga metoder 
    {
        private string name;
        private double price;
        private string type;

        //Konstruktor till klassen soda
        public Soda(string name, double price, string type)
        {
            this.name = name;
            this.price = price;
            this.type = type;
        }

        public double GetPrice() //Metod som returnerar price. Behövs eftersom price är satt till private
        {
            return price;
        }
        public string GetName() //Metod som returnerar name. Behövs eftersom name är satt till private
        {
            return name;
        }
        public override string ToString()//Ställer in vad som ska skrivas ut när vektorn skrivs ut
        {
            return "Namn: " + name + ", Pris: " + price + ", Sort: " + type;
        }
    }
}

