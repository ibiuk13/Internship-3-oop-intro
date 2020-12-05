using System;
using System.Collections.Generic;

namespace Internship_3_oop_intro
{
    class Program
    {
        public enum EventTypeE
        {
            Coffee = 1,
            Lecture = 2,
            Concert = 3,
            StudySession = 4
        }

        static void AddEvent( Dictionary<Event, List<Person>> dict )
        {
            Console.WriteLine("Unesite ime eventa");
            var name = Console.ReadLine();
            string nameCopy = name;
            foreach (var pair in dict)
            {
                if (pair.Key.Name == name)
                {
                    do
                    {
                        Console.WriteLine("Već postoji event s tim imenom");
                        Console.WriteLine("Unesite novo ime eventa");
                        name = Console.ReadLine();
                    } while (name == nameCopy);
                }
            } 
            Console.WriteLine("Izaberite tip eventa po odgovarajućem broju: \n"+
            "Coffee = 1 \n"+ "Lecture = 2 \n" + "Concert = 3 \n" + "StudySession = 4 \n");
            var typeNum = int.Parse(Console.ReadLine());
            var enumStatus = (EventTypeE) typeNum;
            string type = enumStatus.ToString();
            Console.WriteLine("Unesite vrijeme početka eventa");
            var start = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesite vrijeme završetka eventa");
            var end = DateTime.Parse(Console.ReadLine());
            var people = new List<Person>();
            if (start > end)
                do
                {
                    Console.WriteLine("Krivi unos vremena");
                    Console.WriteLine("Unesite vrijeme početka eventa");
                    start = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite vrijeme završetka eventa");
                    end = DateTime.Parse(Console.ReadLine());
                } while (start > end);
            var status = 0;
            foreach(var pair in dict)
            {
                if ((start >= pair.Key.StartTime) && (start <= pair.Key.EndTime)) status++;
                else if ((end >= pair.Key.StartTime) && (end <= pair.Key.EndTime)) status++;
                else if ((start <= pair.Key.StartTime) && (end >= pair.Key.EndTime)) status++;
            }
            if (status != 0) Console.WriteLine("U tom terminu već postoji zakazani event");
            else dict.Add(new Event(name, type, start, end), people);
        }   
        static void DeleteEvent(Dictionary<Event, List<Person>> dict, string name)
        {
            foreach(var pair in dict)
            {
                if (pair.Key.Name == name) dict.Remove(pair.Key);
            }

        }
        static void AddPerson(Dictionary<Event, List<Person>> dict)
        {
            var count = 0;
            do
            {
                Console.WriteLine("Unesite ime eventa na koji želite dodati osobu:");
                string name = Console.ReadLine();
                Console.WriteLine("Unesite podatke o osobi koje dolazi na event: \n");
                Console.WriteLine("Unesite ime osobe:");
                var personName = Console.ReadLine();
                Console.WriteLine("Unesite prezime osobe:");
                var personSurname = Console.ReadLine();
                Console.WriteLine("Unesite OIB osobe:");
                var oib = Console.ReadLine();
                Console.WriteLine("Unesite broj mobitela osobe:");
                var phone = Console.ReadLine();
                var newPerson = new Person(personName, personSurname, oib, phone); 
                foreach(var pair in dict)
                {
                    if (pair.Key.Name == name)
                    {
                        int counter = 0;
                        for(int i = 0; i < pair.Value.Count; i++)
                        {
                            if (pair.Value[i].Oib == oib)
                            {
                                Console.WriteLine("Osoba s tim oibom je već dodana na event");
                                counter++;
                            }
                        }
                        if(counter == 0) pair.Value.Add(newPerson);
                    }
                }
                count++;
            } while(count<1) ;
        
        }
        static void DeletePerson(Dictionary<Event, List<Person>> dict, string name, string br)
        {
            foreach(var pair in dict)
            {
                if(pair.Key.Name==name)
                {
                    for(int i = 0; i < pair.Value.Count; i++)
                    {
                        if (pair.Value[i].Oib == br) pair.Value.Remove(pair.Value[i]);
                    }
                }
            }
        }
        static void PrintEventDetails(Dictionary<Event, List<Person>> dict, string name)
        {
            var duration= new TimeSpan();
            foreach(var pair in dict)
            {
                if (pair.Key.Name == name)
                {
                    duration = pair.Key.EndTime - pair.Key.StartTime;
                    Console.WriteLine(pair.Key.Name + " - " + pair.Key.EventType + " - " +
                    pair.Key.StartTime + " - " + pair.Key.EndTime + " - " + duration + " - " + pair.Value.Count);
                }
            }
        }
        static void PrintPeople(Dictionary<Event, List<Person>> dict, string name)
        {
            foreach(var pair in dict)
            {
                if (pair.Key.Name == name)
                {
                    for(int i = 0; i < pair.Value.Count; i++)
                    {
                        Console.WriteLine(i+1 + "." + pair.Value[i].FirstName + " - " + pair.Value[i].LastName 
                            + " - " + pair.Value[i].PhoneNumber);
                    }
                }
            }
            
        }
        static void Main(string[] args)
        {
            var firstEvent = new Event("Kava", "Coffee", new DateTime(2020, 12, 1,10,00,00), new DateTime(2020, 12, 1, 11, 30, 00));
            var secondEvent = new Event("Predavanje", "Lecture", new DateTime(2020, 12, 1, 18, 00, 00), new DateTime(2020, 12, 1, 19, 00, 00));
            var firstList = new List<Person> { new Person("Mate", "Matic", "123", "091 122 3456") };
            var secondList = new List<Person> { new Person("Ante", "Antic", "001", "095 000 0000") };
            var events = new Dictionary<Event, List<Person>>();
            {   
            };
            events.Add(firstEvent, firstList);
            events.Add(secondEvent, secondList);

            Console.WriteLine
                ("1. Dodavanje eventa \n" +
                "2. Brisanje eventa \n" +
                "3. Edit eventa \n" +
                "4. Dodavanje osobe na event \n" +
                "5. Uklanjanje osobe sa eventa \n" +
                "6. Ispis detalja eventa \n" +
                "7. Prekid rada \n");
            int choice;
            do
            {
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: 
                        {
                            AddEvent(events);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Unesite ime eventa kojeg želite izbrisati:");
                            string deleteEvent = Console.ReadLine();
                            DeleteEvent(events, deleteEvent);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Unesite ime eventa kojeg želite urediti:");
                            string name = Console.ReadLine();
                            foreach (var pair in events)
                            {
                                if(pair.Key.Name==name) pair.Key.EditEvent();
                            }
                            break;
                        }
                    case 4:
                        {
                            AddPerson(events);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Unesite ime eventa s kojeg želite ukloniti osobu:");
                            string name= Console.ReadLine();
                            Console.WriteLine("Unesite oib osobe koju želite ukloniti: ");
                            string oib = Console.ReadLine();
                            DeletePerson(events, name, oib);
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("1.Ispis detalja eventa \n" +

                            "2.Ispis svih osoba na eventu \n"+

                            "3.Ispis svih detalja \n" +

                            "4.Izlazak iz podmenija \n");
                            var option = int.Parse(Console.ReadLine());
                            switch(option)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Unesite ime eventa čije detalje želite ispisati:");
                                        var name = Console.ReadLine();
                                        PrintEventDetails(events, name);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Unesite ime eventa čije sudionike želite ispisati:");
                                        var name = Console.ReadLine();
                                        PrintPeople(events, name);
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("Unesite ime eventa čije sudionike želite ispisati:");
                                        var name = Console.ReadLine();
                                        PrintEventDetails(events, name);
                                        PrintPeople(events, name);
                                        break;
                                    }
                                case 4: break;
                            }
                            break;
                        }

                }

            } while (choice != 7);

        }
    }
}
