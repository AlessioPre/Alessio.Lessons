using System;

namespace LeClassi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Salve benvenuto nel programma per il calcolo del bonus");
            Console.WriteLine("Inserisci i tuoi dati per sapere se ne hai diritto");
            Console.WriteLine("inserisci Nome:");
            string _name = null;
            try
            {
                _name = Console.ReadLine();
            }
            catch (Exception a)
            {
                Console.WriteLine("errore" + a);
            }

            Console.WriteLine("inserisci Cognome:");
            string _surname = Console.ReadLine();

            Console.WriteLine("Inserisci età:");
            int _age = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci voto maturità:");
            int _voto_maturità = int.Parse(Console.ReadLine());

            Console.WriteLine("Hai fatto l'università? ,rispondi true o false");
            bool _università = bool.Parse(Console.ReadLine());
            int _voto_università = 0;
            if (_università)
            {
                Console.WriteLine("Inserisci voto laurea:");
                _voto_università = int.Parse(Console.ReadLine());

            }

            Console.WriteLine("Hai mai avuto problemi con la legge? rispondi true o false");
            bool _fedina_penale = bool.Parse(Console.ReadLine());

            Console.WriteLine("Numero figli:");
            int _figli = int.Parse(Console.ReadLine());

            Console.WriteLine("Hai mai fatto il militare? rispondi true o false");
            bool _militare = bool.Parse(Console.ReadLine());

            Console.WriteLine("Hai debiti? rispondi true o false");
            bool _debiti = bool.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci Pil comunale:");
            decimal _pil = decimal.Parse(Console.ReadLine());

            Person person1 = new Person(
                _name,
                _surname,
                _age,
                _voto_maturità,
                _voto_università,
                _fedina_penale,
                _figli,
                _militare,
                _debiti,
                _pil
                );

            person1.getValues();

            Console.WriteLine("Stiamo controllando se hai diritto al Bonus....");
            if (person1.IsAdult)
            {
                Console.WriteLine("Essendo maggiorenne ti verrà dato un punteggio");

                if (person1.Premio >= 1000)
                {
                    Console.WriteLine("Essendo il tuo punteggio conforme a quanto richiesto riceverai un bonus di 1000€");
                }
                else
                {
                    Console.WriteLine("Eeeeenz VOOLEEVII non hai diritto al Bonus");
                    Console.ReadLine();
                    Console.WriteLine("Ma guarda che faccia!!Non se l'aspettava");
                    Console.ReadLine();
                    Console.WriteLine("Guardalo li con quelle manine che già aspettavano il bonus");

                }
            }
            else
            {
                Console.WriteLine(" Non essendo maggiorenne non ti verrà dato un punteggio");
            }
            //interpolazione

        }

    }
}

