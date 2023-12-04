using Microsoft.EntityFrameworkCore;
using Model_View_Controller.Models;
using Model_View_Controller.Models.DbEntity;

namespace Model_View_Controller.Data
{
	public class EmployeeDbcontext : DbContext
	{
		public EmployeeDbcontext () { }	

		public EmployeeDbcontext (DbContextOptions<EmployeeDbcontext> options) : base (options) { }

		public  DbSet< Employee> Employee { get; set; }
	}
}
