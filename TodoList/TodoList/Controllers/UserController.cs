using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
    public class UserController : Controller
    {
        //    private readonly IUserService userService;

        //    public UserController(IUserService userService)
        //    {
        //        this.userService = userService;
        //    }
        //    [Route("List")]
        //    public IActionResult ListU(string searchString)
        //    {
        //        var user = userService.GetUser();

        //        if (!String.IsNullOrEmpty(searchString))
        //        {
        //            user = userService.FindUser(searchString);

        //        }
        //        //await todo.ToListAsync();
        //        return View(new UserViewModel
        //        {
        //            User = user
        //        });
        //    }

        //    [HttpPost]
        //    public string ListU(string searchString, bool notUsed)
        //    {
        //        return "From [HttpPost]Index: filter on " + searchString;
        //    }
        //    //public IActionResult ListU()
        //    //{
        //    //    var users = userService.GetUser();
        //    //    return View(new UserViewModel
        //    //    {
        //    //        User = users
        //    //    });
        //    //}

        //    [HttpGet]
        //    public ActionResult Create()
        //    {

        //        return View();
        //    }
        //    [HttpPost]
        //    public ActionResult Create(User User)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            userService.CreateUser(User);
        //            return RedirectToAction("ListU", "User");
        //        }
        //        ViewBag.UserMessage = "Not valid data";
        //        return View();
        //    }
        //    public ActionResult Details(int id)
        //    {

        //        var user = userService.DetailUser(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(user);
        //    }

        //    [HttpGet]
        //    public ActionResult AddTask(int id)
        //    {

        //        return View();
        //    }
        //    [HttpPost]
        //    public ActionResult AddTask(Todo Todo)
        //    {


        //        if (ModelState.IsValid)
        //        {
        //            userService.AddNewTaskToUser(Todo);
        //            return RedirectToAction("ListU", "User");
        //        }
        //        ViewBag.UserMessage = "Not valid data";
        //        return View();
        //    }
    }
}