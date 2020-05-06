using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.ViewModel;

namespace TodoList.Controllers
{
    public class AssigneeController : Controller
    {
        private readonly UserManager<Assignee> userManager;


        public AssigneeController(UserManager<Assignee> userManager)
        {
            this.userManager = userManager;

        }

        [HttpGet]
        public IActionResult Index()
        {
            List<AssigneeListViewModel> model = new List<AssigneeListViewModel>();
            model = userManager.Users.Select(u => new AssigneeListViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddAssignee()
        {
            AssigneeViewModel model = new AssigneeViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAssignee(AssigneeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Assignee user = new Assignee
                {
                    Name = model.Name,
                    UserName = model.UserName,
                    Email = model.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditAssignee(string id)
        {
            var model = new EditAssigneeViewModel();


            if (!String.IsNullOrEmpty(id))
            {
                var user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    model.Name = user.Name;
                    model.Email = user.Email;

                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, EditAssigneeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    user.Name = model.Name;
                    user.Email = model.Email;

                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index");

                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAssignee(string id)
        {
            string name = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                var assignee = await userManager.FindByIdAsync(id);
                if (assignee != null)
                {
                    name = assignee.Name;
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAssignee(string id, FormCollection form)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var assignee = await userManager.FindByIdAsync(id);
                if (assignee != null)
                {
                    IdentityResult result = await userManager.DeleteAsync(assignee);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
    }
}