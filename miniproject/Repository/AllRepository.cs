using miniproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using miniproject.Interface;
using miniproject.ViewModel;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace miniproject.Repository
{
    public class AllRepository : ILogin, CommonInterface, PatientDetails
    {
        private ApplicationDbContext dbContext = null;
        public AllRepository()
        {
            dbContext = new ApplicationDbContext();
        }


        public Login LoginValidation(Login login)
        {
            var log = new Login
            {
                UserName = login.UserName,
                Password = login.Password,

            };
            dbContext.Logins.Add(log);
            dbContext.SaveChanges();

            return log;

        }



        public DoctorViewModel SearchByLocationId(int? LocationId, string Specialization)
        {
            DoctorViewModel model = new DoctorViewModel();
            if (LocationId != 0 && Specialization != null)
            {
                var det = dbContext.doctors.Include(l => l.Location).Where(c=>c.Specialization==c.Specialization).ToList();
                model.DoctorsList = det;

            }
            return model;
        }


        public Patient CreatePatient(Patient patient)
        {
            var p = new Patient
            {
                FullName = patient.FullName,
                EmailId = patient.EmailId,
                SapId = patient.SapId,
                MobileNumber = patient.MobileNumber,
                Age = patient.Age,
                SlotId = patient.SlotId,
                Date = patient.Date

            };
            dbContext.patients.Add(p);
            dbContext.SaveChanges();
            return p;
        }


        //public Patient CreatePatient(int DoctorId)
        //{
        //    var p = new Patient
        //    {
        //        FullName = patient.FullName,
        //        EmailId = patient.EmailId,
        //        SapId = patient.SapId,
        //        MobileNumber = patient.MobileNumber,
        //        Age = patient.Age,
        //        DoctorId = patient.Doctor.DoctorId,
        //        SlotId = patient.Slot.SlotId,

        //    };
        //    dbContext.patients.Add(p);
        //    dbContext.SaveChanges();
        //    return p;
        //}


    }

    }
    



