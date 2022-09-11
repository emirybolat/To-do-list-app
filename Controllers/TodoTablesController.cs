using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class TodoTablesController : Controller
    {
        TodolistContext db = new TodolistContext();
        [HttpGet]
        public IActionResult Index()
        {
            var Result = db.TodoTables.ToList();
            return View(Result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(TodoTable t)
        {
            db.TodoTables.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var FindData = db.TodoTables.SingleOrDefault(m => m.Id == id);
            return View("Edit", FindData);
        }
        [HttpPost]
        public IActionResult Edit(TodoTable t)
        {
            var FindData = db.TodoTables.SingleOrDefault(m => m.Id == t.Id);
            FindData.Name = t.Name;
            FindData.Done = t.Done;
            FindData.Urgent = t.Urgent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var FindTask = db.TodoTables.SingleOrDefault(i => i.Id == id);
            db.TodoTables.Remove(FindTask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Urgent(TodoTable t)
        {
            var Task = db.TodoTables.SingleOrDefault(i => i.Id == t.Id);
            Task.Urgent = !Task.Urgent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Done(TodoTable t)
        {
            var Task = db.TodoTables.SingleOrDefault(i => i.Id == t.Id);
            Task.Done = !Task.Done;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
