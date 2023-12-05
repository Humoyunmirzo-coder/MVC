using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model_View_Controller.Models.DbEntity
{
	public class Employee
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Column (TypeName = "varchar(50)")]
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public double  Salary { get; set; }
		public DateTime DataOfBirth { get; set; }
	
	}
}
