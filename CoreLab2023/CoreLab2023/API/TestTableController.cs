using CoreLab2023.Models;
using CoreLab2023.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreLab2023.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestTableController : ControllerBase
    {
        // GET: api/<TestTableController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                TestTableRepository rep = new TestTableRepository();
                List<TestTableModel> allItems = new List<TestTableModel>();
                allItems = rep.GetAllItems();
           
                return Ok(allItems);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            
           
        }

        // GET api/<TestTableController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                TestTableRepository rep = new TestTableRepository();
                TestTableModel item = new TestTableModel();
                item = rep.GetItem(id);
                if (item != null)
                {
                    return Ok(item);
                }
                else
                {
                    return Ok("Empty Result");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST api/TestTable
        [HttpPost]
        public IActionResult Post(TestTableModel req)
        {
            int a = 1; ;
            try
            {
                TestTableRepository rep = new TestTableRepository();
                rep.InsertItem(req);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/TestTable
        [HttpPut]
        public IActionResult Put(TestTableModel req)
        {
            
            try
            {
                TestTableRepository rep = new TestTableRepository();
                rep.UpdateItem(req);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        

        // DELETE api/TestTable
        [HttpDelete]
        public IActionResult Delete(TestTableModel req)
        {
            int a = 1;
            try
            {
                TestTableRepository rep = new TestTableRepository();
                rep.DeleteItem(req.id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
