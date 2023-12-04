﻿using Microsoft.AspNetCore.Mvc;
using Model_View_Controller.Data;
using Model_View_Controller.Models;
using Model_View_Controller.Models.DbEntity;

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
	}
}
