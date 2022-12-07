using Microsoft.EntityFrameworkCore;
using ToDo_App.Models;

namespace ToDo_App.Infertecture
{
    public class Todo_Context:DbContext
    {
        public Todo_Context(DbContextOptions<Todo_Context> options) : base(options)
        {

        }
        public DbSet<To_Do_Iteam> toDos { get; set; }
    }
}
