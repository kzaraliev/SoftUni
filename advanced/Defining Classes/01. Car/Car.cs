using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    internal class Car
    {
        private string make;

        public string Make
        {
            get
            {
                return make;
            }
            set
            {
                make = value;
            }
        }

        private string model;

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        private int year;

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

    }
}
