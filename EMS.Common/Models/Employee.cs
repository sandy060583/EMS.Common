using System.ComponentModel.DataAnnotations;

namespace EMS.Common.Models
{
    public class Employee
    {
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Employee name is required.")]
        public string EmployeeName { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }
       
       public string CityName { get; set; }

    }
}
