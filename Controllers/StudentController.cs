using MVCWithLinq1.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVCWithLinq1.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL obj = new StudentDAL();

        public string folderPath { get; private set; }

        public ViewResult DisplayStudents()
        {
            var students = obj.SelectStudent(null, true);
            return View(students);
        }


        public ViewResult DisplayStudent(int? Sid)
        {
            var students = obj.SelectStudent(Sid, true);
            Student student = students?.FirstOrDefault();
            return View(student);
        }
        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }


        [HttpPost]
    
        public ActionResult AddStudent(Student student, HttpPostedFileBase selectedFile)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Uploads/");

                if (string.IsNullOrEmpty(path))
                {
                    throw new Exception("Upload path is NULL");
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (selectedFile != null && selectedFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(selectedFile.FileName);

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        string extension = Path.GetExtension(fileName);
                        string newFileName = Guid.NewGuid() + extension;

                        string fullPath = Path.Combine(path, newFileName);

                        selectedFile.SaveAs(fullPath);

                        student.Photo = newFileName;
                    }
                }

                student.Status = true;

                obj.AddStudent(student);

                return RedirectToAction("DisplayStudents");
            }

            return View(student);
        }

        public ViewResult EditStudent(int Sid)
        {
            Student student = obj.SelectStudent(Sid, true).FirstOrDefault();
            TempData["Photo"] = student.Photo;
            return View(student);
        }

        [HttpPost]
        public ActionResult UpdateStudent(Student student, HttpPostedFileBase selectedFile)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Uploads/");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (selectedFile != null && selectedFile.ContentLength > 0)
                {
                    string extension = Path.GetExtension(selectedFile.FileName);
                    string newFileName = Guid.NewGuid() + extension;

                    string fullPath = Path.Combine(path, newFileName);

                    selectedFile.SaveAs(fullPath);

                    student.Photo = newFileName;
                }

                obj.UpdateStudent(student);

                return RedirectToAction("DisplayStudents");
            }

            return View("EditStudent", student);
        }


        public RedirectToRouteResult DeleteStudent(int Sid)
        {
            obj.DeleteStudent(Sid);
            return RedirectToAction("DisplayStudents");
        }

    }
}