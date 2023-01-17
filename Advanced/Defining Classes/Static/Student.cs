using System;
using System.Collections.Generic;
using System.Text;

namespace Static
{
    public class Student
    {
        public static DateTime StudentHoliday = DateTime.Now; //constanti koito sa ednakvi za vsichki 
        //referira v Student, ne v instancii

        public Student()
        {

        }

        public string Name { get; set; }
    }
}
