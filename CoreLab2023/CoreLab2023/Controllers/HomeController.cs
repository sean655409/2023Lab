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
			
			TestTableModel newItem = new TestTableModel();
			newItem.id = 999;
			newItem.testType = "xxx";
			newItem.testValue = 9999999;
			List<TestTableModel> insertList = new List<TestTableModel> { newItem };	
			dataRep.InsertItems(insertList);


            TestTableModels x = new TestTableModels();
			x.Models = dataRep.GetValue();
			return View(x);
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