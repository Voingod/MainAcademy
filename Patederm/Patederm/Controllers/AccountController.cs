using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Patederm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Patederm.Controllers
{
    public class AccountController : Controller
    {
        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = registerModel.Email,
                    Email = registerModel.Email,
                };
                IdentityResult result = await UserManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded)
                {
                    using (var context = new MartineDbContext())
                    {
                        context.Students.Add(new Student { Id = user.Id });
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(registerModel);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(loginModel.Email, loginModel.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
                else
                {
                    ClaimsIdentity claims = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claims);
                    return RedirectToAction("Index", "Home");
                }

            }

            return View(loginModel);
        }
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserAccount()
        {
            using (var context = new MartineDbContext())
            {
                var user = User.Identity.GetUserId();
                var model = context.Students
                    .Include(c => c.CardioParams)
                    .Include(c => c.ClusterStudents)
                    .Include(u => u.User)
                    .Where(u => u.Id == user).FirstOrDefault();

                ViewBag.Department = context.Departments
                    .Include(s => s.Students)
                    .Where(i => i.Id == model.DepartmentId)
                    .Select(d => d.DepartmentName).FirstOrDefault();

                ViewBag.Sport = context.TypeOfSports
                    .Include(s => s.Students)
                    .Where(i => i.Id == model.TypeOfSportId)
                    .Select(d => d.TypeOfSportName).FirstOrDefault();

                return View(model);
            }
        }
        public ActionResult Edit(Student student)
        {
            var context = new MartineDbContext();
            var viewStudent = context.Students.Where(u => u.Id == student.Id).FirstOrDefault();

            student.FirstName = viewStudent.FirstName;
            student.Birthday = viewStudent.Birthday;
            student.Course = viewStudent.Course;
            student.DepartmentId = viewStudent.DepartmentId;
            student.SecondName = viewStudent.SecondName;
            student.Sex = viewStudent.Sex;
            student.Surname = viewStudent.Surname;
            student.TypeOfSportId = viewStudent.TypeOfSportId;

            ViewBag.Department = new SelectList(context.Departments, "Id", "DepartmentName", student.DepartmentId);
            ViewBag.Sport = new SelectList(context.TypeOfSports, "Id", "TypeOfSportName", student.TypeOfSportId);

            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student, int Department, int Sport)
        {
            using (var context = new MartineDbContext())
            {
                var updatedtudent = context.Students.Where(u => u.Id == student.Id).FirstOrDefault();

                student.DepartmentId = Department;
                student.TypeOfSportId = Sport;

                updatedtudent.FirstName = student.FirstName;
                updatedtudent.Birthday = student.Birthday;
                updatedtudent.Course = student.Course;
                updatedtudent.DepartmentId = student.DepartmentId;
                updatedtudent.SecondName = student.SecondName;
                updatedtudent.Sex = student.Sex;
                updatedtudent.Surname = student.Surname;
                updatedtudent.TypeOfSportId = student.TypeOfSportId;
                
                context.SaveChanges();
                return RedirectToAction("UserAccount");
            }

        }
    }

}