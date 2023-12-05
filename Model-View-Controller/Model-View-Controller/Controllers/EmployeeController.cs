using Microsoft.AspNetCore.Mvc;
using Model_View_Controller.Data;
using Model_View_Controller.Models;
using Model_View_Controller.Models.DbEntity;
using System.Web.WebPages;

namespace Model_View_Controller.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly EmployeeDbcontext _dbcontext;

		public EmployeeController(EmployeeDbcontext dbcontext)
		{
			_dbcontext = dbcontext;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var employees = _dbcontext.Employee.ToList();
			List<EmployeeViewModel> employeList = new List<EmployeeViewModel>();
			if (employees != null)
			{
				foreach (var employee in employees)
				{
					var EmployeeViewModel = new EmployeeViewModel()
					{
						Id = employee.Id,
						FirstName = employee.FirstName,
						LastName = employee.LastName,
						DataOfBirth = employee.DataOfBirth,
						Salary = employee.Salary,
						Email = employee.Email,
					};
					employeList.Add(EmployeeViewModel);

				}
				return View(employeList);

			}
			return View(employeList);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(EmployeeViewModel employeeViewModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var employee = new Employee()
					{
						Id = employeeViewModel.Id,
						FirstName = employeeViewModel.FirstName,
						LastName = employeeViewModel.LastName,
						Email = employeeViewModel.Email,
						DataOfBirth = employeeViewModel.DataOfBirth,
						Salary = employeeViewModel.Salary,

					};
					_dbcontext.Employee.Add(employee);
					_dbcontext.SaveChanges();
					TempData["successMessage"] = "Employee created successfully !";
					return RedirectToAction("Index");
				}
				else
				{
					TempData["errorMessage"] = "Model date is not valid!";
					return View();
				}

			}

			catch (Exception ex)
			{
				TempData["errorMessage"] = ex.Message;
				return View();
			}
		}
		[HttpGet]
		public IActionResult Edit ( int Id)
		{
			var employee = _dbcontext.Employee.SingleOrDefault(x => x.Id == Id);
			try
			{
				if (employee != null)
				{
					var employeeView = new EmployeeViewModel()
					{
						Id = employee.Id,
						FirstName = employee.FirstName,
						LastName = employee.LastName,
						Email = employee.Email,
						DataOfBirth = employee.DataOfBirth,
						Salary = employee.Salary,
					};
					return View(employeeView);

				}
				else
				{
					TempData["errorMessage"] = $"Employee detals not {Id}";
					return RedirectToAction("index");
				}

			}
			catch (Exception ex)
			{
				TempData["errorMessage"] = ex.Message;
				return RedirectToAction("index");
			}

		}
		[HttpPost] 
		public IActionResult Edit(EmployeeViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var employee = new Employee()
					{
						Id = model.Id,
						FirstName = model.FirstName,
						LastName = model.LastName,
						Email = model.Email,
						DataOfBirth = model.DataOfBirth,
						Salary = model.Salary,

					};
					_dbcontext.Employee.Update(employee);
					_dbcontext.SaveChanges();
					TempData["successMessage"] = "Employee update successfully !";
					return RedirectToAction("Index");
				}
				else
				{
					TempData["errorMessage"] = "Model Data is invalid ";
					return View();
				}
			}
			catch (Exception ex)
			{
				TempData["errorMessage"] = ex.Message;
				return View();
			}
		}
		[HttpGet]
		public IActionResult Delete(int Id)
		{
			var employee = _dbcontext.Employee.SingleOrDefault(x => x.Id == Id);
			try
			{
				if (employee != null)
				{
					var employeeView = new EmployeeViewModel()
					{
						Id = employee.Id,
						FirstName = employee.FirstName,
						LastName = employee.LastName,
						Email = employee.Email,
						DataOfBirth = employee.DataOfBirth,
						Salary = employee.Salary,
					};
					return View(employeeView);

				}
				else
				{
					TempData["errorMessage"] = $"Employee detals not {Id}";
					return RedirectToAction("index");
				}

			}
			catch (Exception ex)
			{
				TempData["errorMessage"] = ex.Message;
				return RedirectToAction("index");
			}

		}
		[HttpPost]
		public IActionResult Delete (EmployeeViewModel model)
		{
			try
			{
				var employee = _dbcontext.Employee.SingleOrDefault(x => x.Id == model.Id);
				if (employee != null)
				{
					_dbcontext.Employee.Remove(employee);
					//_dbcontext.Remove(employee);
					_dbcontext.SaveChanges();
					TempData["errorMessage"] = "Employee Deleted Successfully";
					return RedirectToAction("index");
				}
				else
				{
					TempData["errorMessage"] = $"Employee detals not  {model.Id}";
					return RedirectToAction("index");
				}
			}
			catch (Exception ex)
			{
				TempData["errorMessage"] = ex.Message;
				return View();
			}
		}
	}

}
