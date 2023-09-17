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
        /// <summary>
        /// 取得全部項目
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 取得特定項目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 新增項目
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 更新項目
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 刪除項目
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
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
