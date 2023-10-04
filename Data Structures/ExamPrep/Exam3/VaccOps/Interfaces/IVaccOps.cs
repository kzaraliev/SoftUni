namespace VaccOps.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IVaccOps
    {
        void AddDoctor(Doctor doctor);
        
        void AddPatient(Doctor doctor, Patient patient);

        IEnumerable<Doctor> GetDoctors();

        IEnumerable<Patient> GetPatients();

        bool Exist(Doctor doctor);

        bool Exist(Patient patient);

        Doctor RemoveDoctor(string name);

        void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient);

        IEnumerable<Doctor> GetDoctorsByPopularity(int populariry);

        IEnumerable<Patient> GetPatientsByTown(string town);

        IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi);

        IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc();

        IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge();
    }
}
