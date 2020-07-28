using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using StudentTask.Models;

namespace StudentTask.Controllers
{
    public class StudentController : Controller
    {
        ArmyTechTaskContext context;
        public StudentController( ArmyTechTaskContext armyTechTaskContext)
        {
            context = armyTechTaskContext;
        }

        public IActionResult Index()
        {
            return View(context.Student.Include("Field").Include("Governorate").Include("Neighborhood").ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["NeighborhoodId"] = new SelectList(context.Neighborhood, "Id", "Name");
             ViewData["GovernorateId"] = new SelectList(context.Governorate, "Id", "Name");
            ViewData["FieldId"] = new SelectList(context.Field, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Student.Add(student);
                context.SaveChanges();
                return RedirectToAction("Edit", new RouteValueDictionary(
                 new { controller = "Student", action = "Edit", Id = student.Id }));
            }

            else
            {
                ViewData["NeighborhoodId"] = new SelectList(context.Neighborhood, "Id", "Name");
                ViewData["GovernorateId"] = new SelectList(context.Governorate, "Id", "Name");
                ViewData["FieldId"] = new SelectList(context.Field, "Id", "Name");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int  Id) 
        {
            ViewData["NeighborhoodId"] = new SelectList(context.Neighborhood, "Id", "Name");
            ViewData["GovernorateId"] = new SelectList(context.Governorate, "Id", "Name");
            ViewData["FieldId"] = new SelectList(context.Field, "Id", "Name");
            return View(context.Student.SingleOrDefault(i => i.Id == Id));
        }
        [HttpPost]
        public IActionResult Edit(Student student) 
        {
            if (ModelState.IsValid)
            {
                var newStudent= context.Student.SingleOrDefault(i=>i.Id==student.Id);
                newStudent.Name = student.Name;
                newStudent.BirthDate = student.BirthDate;
                newStudent.FieldId = student.FieldId;
                newStudent.GovernorateId = student.GovernorateId;
                newStudent.NeighborhoodId = student.NeighborhoodId;
                context.SaveChanges();
                return RedirectToAction("index");



            }
            else 
            {
                ViewData["NeighborhoodId"] = new SelectList(context.Neighborhood, "Id", "Name");
                ViewData["GovernorateId"] = new SelectList(context.Governorate, "Id", "Name");
                ViewData["FieldId"] = new SelectList(context.Field, "Id", "Name");
                return RedirectToAction ("Edit");
            }
        }



        public IActionResult Delete(int Id)
        {
            context.Student.Remove(context.Student.SingleOrDefault(i=>i.Id==Id));
            context.SaveChanges();
            return RedirectToAction("index");
        
        
        }
    }
}