using System;
using System.Collections.Generic;
using System.Text;

namespace Internship_3_oop_intro
{
    public class Event
    {
        public Event (string name, string eventtype, DateTime starttime, DateTime endtime)
            {
            Name=name;
            EventType = eventtype;
            StartTime=starttime;
            EndTime=endtime;
            }
        public string Name { get; set; }
        public string EventType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public void EditEvent()
        {
            Console.WriteLine("Unesite novo ime eventa:");
            Name = Console.ReadLine();
            Console.WriteLine("Unesite novi tip eventa:");
            EventType = Console.ReadLine();
            Console.WriteLine("Unesite novo vrijeme početka eventa");
            StartTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesite novo vrijeme završetka eventa");
            EndTime = DateTime.Parse(Console.ReadLine());
        }
    }
}
