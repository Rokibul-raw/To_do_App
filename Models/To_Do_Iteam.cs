using System.ComponentModel.DataAnnotations;

namespace ToDo_App.Models
{
    public class To_Do_Iteam
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
        public DateTime AdditionDate { get; set; } = DateTime.Now;
        public string ExpectedTime { get; set; }
    }
}
