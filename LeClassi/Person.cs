using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeClassi
{
    internal class Person
    {
        static int counter = 0;
        string _name;
        string _surname;
        int _age;
        bool _isAdult;
        int _bonus;
        decimal _pilComune;
        int _maturita;
        int _universita;
        bool _fedinaPenale;
        int _figli;
        bool _militare;
        bool _debiti;
        int _punteggio;
        int _premio;
        const int indeceBonus = 35;

        public string Name { get { return _name; } }
        public string Surname { get { return _surname; } }
        public string FullName { get { return _name + " " + _surname; } }
        public bool IsAdult { get { return _isAdult; } }
        public int Premio { get { return _premio; } }

        public Person(

            string Name,
            string Surname,
            int Age,
            int Maturita,
            int Universita,
            bool FedinaPenale,
            int Figli,
            bool Militare,
            bool Debiti,
            decimal PilComune
            ) // firma del costruttore
        {
            _name = Name;
            _surname = Surname;


            // variabili per il BONUS 
            _age = Age;
            _maturita = Maturita;
            _universita = Universita;
            _fedinaPenale = FedinaPenale;
            _figli = Figli;
            _militare = Militare;
            _debiti = Debiti;
            _pilComune = PilComune;


            counter++;
            setIsAdult();
            if (IsAdult)
            {
                CalcolaBonus();
                _premio = _bonus;
            }

        }
        public void getValues()
        {
            //Console.WriteLine(
            //$"Nome:{_name}\n " +
            //$"Cognome:{_surname}\n" +
            //$"Age:{_age}" +
            //$"Maturita:{_maturita}" +
            //$"FedinaPenale:{_fedinaPenale}" +
            //$"Debiti: {_debiti}"
            //);

            Console.WriteLine($"Age:{_age}");
            Console.WriteLine($"Maturita:{_maturita}");
            Console.WriteLine($"Debiti:{_debiti}");
            Console.WriteLine("FedinaPenale:{0}", _fedinaPenale);
            Console.WriteLine($"Universita:{_universita}");
            Console.WriteLine($"FedinaPenale:{_fedinaPenale}");
            Console.WriteLine($"Figli:{_figli}");
            Console.WriteLine($"Militare:{_militare}");
            Console.WriteLine($"PilComune:{_pilComune}");
        }
        public int getCounter()
        {
            return counter;
        }

        private void setIsAdult()
        {
            if (_age > 18)
            {
                _isAdult = true;
            }
            else
            {
                _isAdult = false;
            }
        }

        private void CalcolaBonus()
        {


            /*
               Calcolo per il bonus cittadino
            */


            if (_maturita >= 90)
            {
                _punteggio += 7;
            }
            if (_age >= 18 && _age <= 28)
            {
                _punteggio += 6;
            }
            if (_universita >= 28)
            {
                _punteggio += 6;
            }
            if (!_fedinaPenale)
            {
                _punteggio += 4;
            }
            switch (_figli)
            {
                case 3:
                    _punteggio += 4;
                    break;
                case 4:
                    _punteggio += 6;
                    break;
                case 5:
                    _punteggio += 8;
                    break;
                default:
                    _punteggio += 2;
                    break;
            }
            if (_militare)
            {
                _punteggio += 4;
            }
            if (_debiti)
            {
                _punteggio += 8;
            }
            if (_pilComune < 1000000M)
            {
                _punteggio += 8;
            }

            if (_punteggio >= indeceBonus && _isAdult)
            {
                _bonus += 1000;
            }
            else
            {
                _bonus = 0;
            }
        }
    }
}
