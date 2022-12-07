using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo_App.Infertecture;
using ToDo_App.Models;

namespace ToDo_App.Controllers
{
    public class ToDoController : Controller
    {
       

        private readonly Todo_Context context;
        public ToDoController(Todo_Context context)
        {
            this.context = context;
        }
        //get and see all data
        public async Task<ActionResult> Index()
        {
            IQueryable<To_Do_Iteam> iteam = from i in context.toDos orderby i.Id select i;
            List<To_Do_Iteam> todoIteam = await iteam.ToListAsync();
            return View(todoIteam);
        }
        //create to do list
        public IActionResult Create() => View();
        [HttpPost]
        public async Task< IActionResult> Create(To_Do_Iteam Iteam)
        {
            if (ModelState.IsValid)
            {
                context.Add(Iteam);
                await context.SaveChangesAsync();
                TempData["Success"] = "Iteam has been Added!";
                return RedirectToAction("Index");
            }
            return View(Iteam);
        }
        //todo/edit
        public async Task<ActionResult> Edit(int id)
        {
            To_Do_Iteam iteam = await context.toDos.FindAsync(id);
            if (iteam == null)
            {
                return NotFound();
            }
            
            return View(iteam);
        }
        //todo/edit/save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(To_Do_Iteam Iteam)
        {
            if (ModelState.IsValid)
            {
                context.Update(Iteam);
                await context.SaveChangesAsync();
                TempData["Success"] = "Iteam has been Edited!";
                return RedirectToAction("Index");
            }
            return View(Iteam);
        }
        //todo iteam delete
       
        public async Task<ActionResult> Delete(int id)
        {
            To_Do_Iteam iteam = await context.toDos.FindAsync(id);
            if (iteam == null)
            {
                TempData["Error"] = "The Iteam will be Exist!";
            }
            else
            {
                context.toDos.Remove(iteam);
                await context.SaveChangesAsync();
                TempData["Error"] = "The Iteam will be Deleted!";

            }

            return RedirectToAction("Index");
        }
    }
}
