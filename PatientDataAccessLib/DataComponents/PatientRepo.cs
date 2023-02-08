using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientDataAccessLib;
namespace PatientDataAccessLib.DataComponents
{
    public interface IPatientClass
    {
        void AddPatient(tblPatient pat);
        void UpdatePatient(tblPatient pat);
        void UpdateDoctor(tblDoctor doc);
        List<tblPatient> GetAllPatients();
        List<tblDoctor> GetAllDoctors();
        tblPatient FindPatient(int patid);
        void RemovePatient(int patid);
        void AddDoctor(tblDoctor doc);
        void RemoveDoc(int docId);
    }
    public class PatientRepo : IPatientClass
    {
        private readonly PatientDataEntities _context = new PatientDataEntities();

        public void AddDoctor(tblDoctor doc)
        {
            _context.tblDoctors.Add(doc);
            _context.SaveChanges();
        }


        public void AddPatient(tblPatient pat)
        {
            _context.tblPatients.Add(pat);
            _context.SaveChanges();
        }

        public tblPatient FindPatient(int patid) => _context.tblPatients.FirstOrDefault((p) => p.PatientId == patid);


        public List<tblPatient> GetAllPatients() => _context.tblPatients.ToList();
        public List<tblDoctor> GetAllDoctors() => _context.tblDoctors.ToList();


        public void RemoveDoc(int docId)
        {
            var selected = _context.tblDoctors.FirstOrDefault((p) => p.DoctorId == docId);
            _context.tblDoctors.Remove(selected);
            _context.SaveChanges();

        }

        public void RemovePatient(int patid)
        {
            var selected = FindPatient(patid);
            _context.tblPatients.Remove(selected);
            _context.SaveChanges();
        }

        public void UpdatePatient(tblPatient pat)
        {
            var selected = FindPatient(pat.PatientId);
            if (selected != null)
            {
                selected.PatientName = pat.PatientName;
                selected.PatientAddress = pat.PatientAddress;
                selected.BillAmount = pat.BillAmount;
                selected.DoctorID = pat.DoctorID;
                _context.SaveChanges();

            }
            else
            {
                throw new Exception("Patient Not Found ");
            }

        }
        public tblDoctor FindDoc(int id)
        {
            var selected = _context.tblDoctors.FirstOrDefault((p) => p.DoctorId == id);
            return selected;
        }
        public void UpdateDoctor(tblDoctor doc)
        {
            var selected = FindDoc(doc.DoctorId);
            if (selected != null)
            {
                selected.DoctorName = doc.DoctorName;
                selected.Specialization = doc.Specialization;
                _context.SaveChanges();
            }
            else
                throw new Exception("Doctor Not Found");

        }
    }
}
