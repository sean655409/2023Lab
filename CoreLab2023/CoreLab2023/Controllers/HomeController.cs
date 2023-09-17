using CoreLab2023.Models;
using CoreLab2023.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreLab2023.Controllers
{
    
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;



		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}



		public IActionResult Index()
		{
			
			TestTableRepository dataRep = new TestTableRepository();
			/*
			TestTableModel newItem = new TestTableModel();
			newItem.id = 999;
			newItem.testType = "xxx";
			newItem.testValue = 9999999;
			List<TestTableModel> insertList = new List<TestTableModel> { newItem };	
			dataRep.InsertItems(insertList);
			*/

			// 頁面呈現全部項目
            TestTableModels rep = new TestTableModels();
            rep.Models = dataRep.GetAllItems();
			return View(rep);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}