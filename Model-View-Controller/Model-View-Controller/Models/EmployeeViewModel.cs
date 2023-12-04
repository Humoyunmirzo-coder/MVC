using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model_View_Controller.Models
{
	public class EmployeeViewModel
	{
		[Key]
		public int Id { get; set; }

		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		public int LastName { get; set; }

		[DisplayName("E-mail")]
		public string Email { get; set; }
		public string Salary { get; set; }

		[DisplayName("Data Of Birth")]
		public string DataOfBirth { get; set; }

		[DisplayName("Name")]
		public string FullName
		{ get { return FirstName + " " + LastName; } }

	}
}

