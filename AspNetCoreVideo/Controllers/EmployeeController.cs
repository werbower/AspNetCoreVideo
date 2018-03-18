using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVideo.Controllers{
    [Route("company/[controller]/[action]")]
    public class EmployeeController:Controller    {
        //[Route("[action]")]
        public ContentResult Name() {
            return Content("Slava");
        }
        //[Route("[action]")]
        public string Country() {
            return "Ukraine";
        }
        //[Route("")]
        //[Route("[action]")]
        public string Index() {
            return "hello from employee controller";
        }
    }
}
