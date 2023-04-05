using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace myWebApp.Controllers
{
    public class TimekeepingController : ApiController
    {
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetTimekeepingbyEmployeeId(int employeeID)
        {
            IList<timekeeping> timekeepingList;
            using (var myappEntiObj = new myappEntities())
            {
                timekeepingList = myappEntiObj.timekeeping.Select(t => new timekeeping()
                {
                    date = t.date,
                    timeIn = t.timeIn,
                    timeOut = t.timeOut
                }).ToList<timekeeping>();
            }
            
            /*------------------------------------------------------------------
            IList<timekeeping> timekeepingList = new List<timekeeping>();
            using (var md = new myappEntities())
            {
                var timekeepingRes = from c in md.timekeeping
                                     where c.employeeID == employeeID
                                     orderby c.date descending
                                     select new { c.employeeID, c.date, c.timeIn, c.timeOut };
                foreach (var item in timekeepingRes)
                {
                    timekeepingList.Add(new timekeeping()
                    {
                        date = item.date,
                        timeIn = item.timeIn,
                        timeOut = item.timeOut
                    });
                }
            }-----------------------------------------------------------------*/

            if(timekeepingList.Count == 0)
            {
                return NotFound();
            }
            return Ok(timekeepingList);     
        }
        
        [System.Web.Http.HttpPost]
        public IHttpActionResult TakeTimekeeping(timekeeping checkTimeInfo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var myappEntiObj = new myappEntities())
            {
                myappEntiObj.timekeeping.Add(new timekeeping()
                {
                    employeeID = checkTimeInfo.employeeID,
                    timeIn = checkTimeInfo.timeIn,
                    timeOut = checkTimeInfo.timeOut,
                    date = checkTimeInfo.date,
                    createdBy = checkTimeInfo.createdBy,
                    modifiedBy = checkTimeInfo.modifiedBy
                });
                myappEntiObj.SaveChanges();
            }
            return Ok();
        }
        /*
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeeById(int employeeID)
        {
            List<employee> emloyeeInfo = new List<employee>();
            myappEntities md = new myappEntities();
            var employeeRes = from c in md.employee
                                 where c.id == employeeID
                                 select new { c.id, c.name };
            /*
            foreach (var item in timekeepingRes)
            {
                timekeepingList.Add(new timekeeping
                {
                    employeeID = item.employeeID,
                    date = item.date,
                    timeIn = item.timeIn,
                    timeOut = item.timeOut
                });
            }*/
            /*return Ok(employeeRes.FirstOrDefault());
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }*/
    }
}
