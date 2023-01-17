using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        private List<CPU> multiprocessor;

        public List<CPU> Multiprocessor
        {
            get { return multiprocessor; }
            set { multiprocessor = value; }
        }

        public int Count { get { return Multiprocessor.Count; } }
        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            CPU cpu = Multiprocessor.FirstOrDefault(c => c.Brand == brand);
            if (cpu == null)
            {
                return false;
            }
            else
            {
                Multiprocessor.Remove(cpu);
                return true;
            }
        }
        public CPU MostPowerful()
        {
            List<CPU> cpuListSort = Multiprocessor.OrderBy(c =>c.Frequency).ToList();
            return cpuListSort[cpuListSort.Count -1];
        }
        public CPU GetCPU(string brand)
        {
            CPU cpu = Multiprocessor.FirstOrDefault(c => c.Brand == brand);
            if (cpu == null)
            {
                return null;
            }
            
            return cpu;
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"CPUs in the Computer {Model}:");

            foreach (var cpu in Multiprocessor)
            {
                result.AppendLine(cpu.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
