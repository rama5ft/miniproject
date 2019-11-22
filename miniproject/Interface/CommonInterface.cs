using miniproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using miniproject.ViewModel;

namespace miniproject.Interface
{
    public  interface CommonInterface
    {
        // DoctorViewModel SearchByLocationId(int? locationId, int? doctorId);
        DoctorViewModel SearchByLocationId(int? locationId, string Specialization);


    }
    public interface PatientDetails
    {
        Patient CreatePatient(Patient patient);
     
    }

 

}
