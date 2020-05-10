using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondTestAPI.Models  
{
    public class Employee  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int Id {get; set;}  
         public string  EmployeeName {get; set;}  
    }
}