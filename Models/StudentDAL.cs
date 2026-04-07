using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace MVCWithLinq1.Models
{
    public class StudentDAL
    {
        StudentDataContext dc;

        public StudentDAL()
        {
            string constr = ConfigurationManager.ConnectionStrings["DataSourceConnectionString"].ConnectionString;
            dc = new StudentDataContext(constr);
        }

        public List<Student> SelectStudent(int? Sid, bool? Status)
        {
            List<Student> students = new List<Student>();

            if (Sid != null && Status != null)
            {
                students = dc.Students
                    .Where(s => s.Sid == Sid && s.Status == Status)
                    .ToList();
            }
            else if (Sid != null)
            {
                students = dc.Students
                    .Where(s => s.Sid == Sid)
                    .ToList();
            }
            else if (Status != null)
            {
                students = dc.Students
                    .Where(s => s.Status == Status)
                    .ToList();
            }
            else
            {
                students = dc.Students.ToList();
            }

            return students;
        }

        public void AddStudent(Student Add)
        {
            try
            {
                dc.Students.InsertOnSubmit(Add);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateStudent(Student newvalues)
        {
            try
            {
                Student oldValue = dc.Students.Single(s => s.Sid == newvalues.Sid);

             

                oldValue.Name = newvalues.Name;
                oldValue.Age = newvalues.Age;
                oldValue.Class = newvalues.Class;
                oldValue.Fees = newvalues.Fees;

                oldValue.Photo = newvalues.Photo;

                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteStudent(int Sid)
        {
            Student oldValue=dc.Students.FirstOrDefault(s=>s.Sid == s.Sid);
            if (oldValue != null)
            {
                oldValue.Status = false;
                dc.SubmitChanges();
            }
        }

    }

}
