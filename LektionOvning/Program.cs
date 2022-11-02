using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace LektionOvning {

    internal class Program {

        static void Main(string[] args) {

            Läkaren test1 = new Läkaren("Emil", "Treptow", 123, 100, "Läkare");
            test1.PrintInfo();

            SjukSjöterska test2 = new SjukSjöterska("Lucas", "Persson", 999, 10000, "man", "Sjöterska");
            test2.PrintInfo();
            
            //Initialize the patient
            Patient patient1 = new Patient("Bob", "The Builder", 001, "Lite snuvig", true, "12/11/20", "02/11/22", false);
            Patient patient2 = new Patient("Kalle", "Anka", 002, "Totalt dör", true, "01/11/20", "troligt vis aldrig", true);
            Patient patient3 = new Patient("Sebbe", "Sebbe", 003, "Covid", false, "12/11/20", "02/10/22", false);

            Console.WriteLine("-----&&&&&-----");

            //Add all patients to the initial queue
            Queue<Patient> queue = new Queue<Patient>();
            queue.Enqueue(patient1);
            queue.Enqueue(patient2);
            queue.Enqueue(patient3);

            int size = queue.Count;
            for (int i = 0; i < size; i++) {

                if (queue.TryPeek(out Patient patient)) {

                    if (!patient.vaccinated) {

                        Console.WriteLine($"{queue.Dequeue()} är nu vaccinerad och har blivit borttagen från kön");
                        patient.vaccinated = true;

                    }

                    else {

                        Console.WriteLine($"{queue.Dequeue()} var redan vaccinerad och har därför blivit borttagen från kön");

                    }

                }

            }


        }

    }

    abstract class Person {

        protected string firstName = "FirstName";
        protected string lastName = "lastName";
        protected int id = 000;

        public Person(string _firstName, string _lastName, int _id) {

            firstName = _firstName;
            lastName = _lastName;
            id = _id;

        }

        public virtual void PrintInfo() { }

    }

    class Läkaren : Person {

        public int salary = 0;
        public string roll = "Läkare";

        //Empty contstructor (default variables)

        public Läkaren(string _firstName, string _lastName, int _id, int _salary, string _roll) :
            base(_firstName, _lastName, _id) {

            salary = _salary;
            roll = _roll;  

        }

        public override void PrintInfo() {

            Console.WriteLine($"Fullname: {firstName + " " + lastName} | ID: {id} | Roll: {roll} | Salary: {salary}kr");

        }

    }

    class SjukSjöterska : Person {

        public int salary = 0;
        public string gender = "female";
        public string roll = "SjukSjöterska";

        public SjukSjöterska(string _firstName, string _lastName, int _id, int _salary, string _gender, string _roll) 
            : base(_firstName, _lastName, _id) {

            salary = _salary;
            gender = _gender;
            roll = _roll;

        }

        public void TaBolTest() {

            Console.WriteLine($" {firstName} Tar ett bol test på en patient");

        }

        public override void PrintInfo() {

            Console.WriteLine($"Fullname: {firstName + " " + lastName} | Gender: {gender} | ID: {id} | Roll: {roll} | Salary: {salary}£");

        }

    }

    class Patient : Person {

        public string sjukdom = "snuvig";
        public bool recept = true;
        public bool vaccinated = true;
        public string registeredIn = "00/00/00";
        public string registeredOut = "00/00/00";

        public Patient(string _firstName, string _lastName, int _id, string _sjukdom, bool _recept, string _registeredIn, string _registeredOut, bool _vaccinated) 
            : base(_firstName, _lastName, _id) {

            sjukdom = _sjukdom;
            recept = _recept;
            vaccinated = _vaccinated;
            registeredIn = _registeredIn;
            registeredOut = _registeredOut;

        }

        public override void PrintInfo() {

            Console.WriteLine($"Fullname: {firstName + " " + lastName} | Recept: {recept} | Vaccinated {vaccinated} | RegIn {registeredIn} | RegOut {registeredOut}");

        }

        //Each object has a ToString built in to itself, so when the object is written we override the normal function and write
        //$"{id} | {name} - {gender} - {salary}" instead
        public override String ToString() {
            return $"{firstName}";

        }

    }

}
