using System.Linq;

namespace VaccOps
{
    using Models;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public class VaccDb : IVaccOps
    {
        private Dictionary<string, Doctor> doctors = new Dictionary<string, Doctor>();
        private Dictionary<string, Patient> patients = new Dictionary<string, Patient>();

        public void AddDoctor(Doctor doctor)
        {
            if (doctors.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }

            doctors.Add(doctor.Name, doctor);
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            if (!doctors.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }

            patient.Doctor = doctor;
            patients.Add(patient.Name, patient);
            doctors[doctor.Name].Patients.Add(patient);
        }

        public void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient)
        {
            if (!doctors.ContainsKey(oldDoctor.Name) || !doctors.ContainsKey(newDoctor.Name) || !patients.ContainsKey(patient.Name))
            {
                throw new ArgumentException();
            }

            patient.Doctor = newDoctor;
            doctors[oldDoctor.Name].Patients.Remove(patient);
            doctors[newDoctor.Name].Patients.Add(patient);
        }

        public bool Exist(Doctor doctor)
        {
            return doctors.ContainsKey(doctor.Name);
        }

        public bool Exist(Patient patient)
        {
            return patients.ContainsKey(patient.Name);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return doctors.Values;
        }

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
        {
            return doctors
                .Select(d => d.Value)
                .Where(d => d.Popularity == populariry);
        }

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
        {
            return doctors
                .Select(d => d.Value)
                .OrderByDescending(d => d.Patients.Count)
                .ThenBy(d => d.Name);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return patients.Values;
        }

        public IEnumerable<Patient> GetPatientsByTown(string town)
        {
            return patients
                .Select(p => p.Value)
                .Where(p => p.Town == town);
        }

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
        {
            return patients
                .Select(p => p.Value)
                .Where(p => p.Age >= lo && p.Age <= hi);
        }

        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
        {
            return patients
                .Select(p => p.Value)
                .OrderBy(p => p.Doctor.Popularity)
                .ThenByDescending(p => p.Height)
                .ThenBy(p => p.Age);
        }

        public Doctor RemoveDoctor(string name)
        {
            if (!doctors.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            List<Patient> patientsOfCurrentDoctor = doctors[name].Patients;

            foreach (var patient in patientsOfCurrentDoctor)
            {
                patients.Remove(patient.Name);
            }

            Doctor doctor = doctors[name];
            doctors.Remove(name);

            return doctor;
        }
    }
}
