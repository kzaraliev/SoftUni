using System;
using System.Collections.Generic;
using System.Text;

namespace FieldsAndProps
{
    internal class Student
    {
        public double AverageGrade { get; set; }//prop


        private string username = "Dimitrichko";//pole (nedostupno ot vunshniq svqt)

        //imame kakvato poiskame validaciq pri izpulnenie
        private string name;

        public string Name
        {
            get // posle go getvame
            {
                return name;
            }
            set //purvo setvame
            {
                if (value.Length < 3)
                {
                    Console.WriteLine("Not enough characters");
                    return;
                }
                name = value;
            }
        }

    }
}
