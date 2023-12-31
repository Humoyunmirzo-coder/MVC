﻿using System.ComponentModel;
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
		public string LastName { get; set; }

		[DisplayName("E-mail")]
		public string Email { get; set; }
		public double  Salary { get; set; }

		[DisplayName("Data Of Birth")]
		public DateTime DataOfBirth { get; set; }

		[DisplayName("Name")]
		public string FullName
		{ get { return FirstName + " " + LastName; } }

	}
}

