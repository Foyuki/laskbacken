using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppdrag4_laskbacken
{
    class Sodacrate
    {
        //Bereder plats för en vektor som innehåller objekt av klassen soda
        private Soda[] sodas;

        public Sodacrate()//Den här konstruktorn skickar inte med några värden eftersom socacrate bara innehåller vektorn
        {
            sodas = new Soda[25];//Skapa vektorn och bestämma att den ska ha 25 st positioner
        }


        //Metod run() med meny switch case loop
        public void Run()
        {
            int temp = 0; //Variabel för att styra loopen
            do
            {
                Console.WriteLine("Välj alternativ");
                Console.WriteLine("1 Lägg till läsk");
                Console.WriteLine("2 Visa innehållet i backen ");
                Console.WriteLine("3 Räkna ut totalpriset av flaskorna i backen");
                Console.WriteLine("4 Sök efter läskflaska");
                Console.WriteLine("5 Sortera flaskor utifrån namn");
                Console.WriteLine("6 Sortera flaskor utifrån pris");
                Console.WriteLine("0 avsluta");
                temp = int.Parse(Console.ReadLine());
                switch (temp)
                {
                    case 1:
                        AddSodas(); //Anropar metoden Add_sodas
                        break;
                    case 2:
                        Console.WriteLine("Just nu innehåller backen de här flaskorna: ");
                        PrintCrate();
                        break;
                    case 3:
                        Console.WriteLine("Det totala priset av flaskorna i backen är nu {0} kr", CalcTotalPrice());
                        break;
                    case 4:
                        FindSoda();
                        break;
                    case 5:
                        Console.WriteLine("Sorterar flaska utifrån namnets längd");
                        SortSodasName();
                        break;
                    case 6:
                        Console.WriteLine("Sorterar flaska utifrån pris");
                        SortSodasPrice();
                        break;
                    case 0:
                        Console.WriteLine("Avsluta programmet");
                        break;
                    default:
                        Console.WriteLine("Felaktig inmatning");
                        break;
                }
            }
            while (temp != 0);
        }
        //Metod som skapar flaskorna som ska lagras i läskbacken
        public void AddSodas()
        {
            int i = 0; //Initerar variabel för att få rätt mängd korrekta inmatningar
            while (i < sodas.Length)
            {
                Console.WriteLine("Skriv vilken sorts läsk du vill lägga till.");
                Console.WriteLine("[R]amlösa");
                Console.WriteLine("[P]ripps");
                Console.WriteLine("[F]anta");
                Console.WriteLine("[E]get val");
                Console.WriteLine("Välj[A]vsluta när du har valt så många flaskor som du vill ha.");

                string menuChoice = Console.ReadLine();


                //Lagrar egna inmatningar av flaskor
                if (menuChoice.ToUpper() == "E")
                {
                    Console.Write("Skriv in namnet på drycken: ");
                    string mySodaName = Console.ReadLine();

                    Console.Write("Skriv in priset på drycken: ");
                    string str = Console.ReadLine();
                    double mySodaPrice = Convert.ToDouble(str);

                    Console.Write("Skriv in vilken sorts dryck det är: ");
                    string mySodaType = Console.ReadLine();

                    sodas[i] = new Soda(mySodaName, mySodaPrice, mySodaType);
                    Console.WriteLine("På plats {0} har du lagt till en {1}.", (i + 1), mySodaName);
                    i++;
                }

                else if (menuChoice.ToUpper() == "R")
                {
                    sodas[i] = new Soda("Ramlösa", 8.90, "vatten");
                    Console.WriteLine("På plats {0} har du lagt till en Ramlösa.", (i + 1));
                    i++;
                }
                else if (menuChoice.ToUpper() == "P")
                {
                    sodas[i] = new Soda("Pripps", 5.50, "lättöl");
                    Console.WriteLine("På plats {0} har du lagt till en Pripps.", (i + 1));
                    i++;
                }
                else if (menuChoice.ToUpper() == "F")
                {
                    sodas[i] = new Soda("Fanta", 9.90, "läsk");
                    Console.WriteLine("På plats {0} har du lagt till en Fanta.", (i + 1));
                    i++;
                }
                else if (menuChoice.ToUpper() == "A")//Avbryter loopen med påfyllning i backen
                {
                    i = sodas.Length;
                    Console.WriteLine("Du har valt att du inte vill lägga till några fler flaskor.");
                }
                else
                    Console.WriteLine("Felaktig inmatning");
            }
            Console.WriteLine("Nu är backen färdigpackad!");
        }

        //Metod som skriver ut innehållet i läskbacken
        public void PrintCrate()
        {
            //for (int i = sodas.GetLowerBound(0); i <= sodas.GetUpperBound(0); i++)
            for (int i = 0; i < sodas.Length; i++)
            {
                if (sodas[i] != null)
                    Console.WriteLine("[{0,2}]: {1}", (i + 1), sodas[i]);
                else
                    Console.WriteLine("[{0,2}]: Tom plats", (i + 1), sodas[i]);
            }
        }

        //Metod som räknar ihop totalpriset av flaskorna i läskbacken
        public double CalcTotalPrice()
        {
            double price = 0;
            foreach (var temp in sodas)
            {
                if (temp != null)
                    price += temp.GetPrice(); //Hämtar variabeln price från metoden GetPrice i klassen soda 
            }
            return price;
        }

        //Metod som söker efter läsk i läskbacken
        public void FindSoda()
        {
            Console.WriteLine("Skriv in namnet på flaskan du söker: ");
            string searchString = Console.ReadLine();

            for (int i = 0; i < sodas.Length; i++)
            {
                if (sodas[i].GetName() == searchString) //Om namnet på flaskan är samma som det inmatade namnet
                {
                    Console.WriteLine("En {0}-flaska finns på plats {1}.", searchString, (i+1));
                    break;
                }
            }
        }


        //Metod som sorterar flaskorna i backen baserat på namnets längd
        public void SortSodasName()
        {
            for (int a = 0; a < sodas.Length; a++)
            {
                    int max = sodas.Length - 1;

                    //Den yttre loopen går igenom hela listan
                    for (int i = 0; i < max; i++)
                    {
                        int nrLeft = max - i; //För att se hur många som redan gåtts igenom

                        for (int j = 0; j < nrLeft; j++) //Den inre loopen går igenom element för element
                        {
                            if (sodas[j].GetName().Length > sodas[j + 1].GetName().Length) //Jämför elementens variabel name
                            {
                                //Byt plats
                                var temp = sodas[j];
                                sodas[j] = sodas[j + 1];
                                sodas[j + 1] = temp;
                            }
                        }
                    }
            }
            
            //Skriv ut listan
                for (int i = 0; i < sodas.Length; i++)
                {
                        Console.WriteLine("[{0,2}]: {1} innehåller {2} bokstäver.", (i + 1), sodas[i].GetName(), sodas[i].GetName().Length);
                }
        }

        //Metod som sorterar flaskorna i backen baserat på pris
        public void SortSodasPrice()
        {
            int max = sodas.Length - 1;

            //Den yttre loopen går igenom hela listan
            for (int i = 0; i < max; i++)
            {
                    //Den inre går igenom element för element
                    int nrLeft = max - i; //För att se hur många som redan gåtts igenom

                    for (int j = 0; j < nrLeft; j++)
                    {
                            if (sodas[j].GetPrice() > sodas[j + 1].GetPrice()) //Jämför elementens variabel price
                            {
                                //Byt plats
                                var temp = sodas[j];
                                sodas[j] = sodas[j + 1];
                                sodas[j + 1] = temp;
                            }
                    }
            }
                    //Skriv ut listan
                    for (int i = 0; i<sodas.Length; i++)
                Console.WriteLine("{0}-flaskan kostar {1} kr.", sodas[i].GetName(), sodas[i].GetPrice());
         }
      }
    } 
