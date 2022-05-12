using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Transcoding0804.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class CiphertController : ControllerBase
    {
        public string InvoiceNumber = "PL49821416";
        public string RandomNumber = "5871";
        public string AESKey = "F1A618ED8685B1A3B81E6CB6884617F4";
        QREncrypter QREncrypter = new QREncrypter();
        public string Ciphert = "";
        // GET: api/<CiphertController>
        [HttpGet]
        //public IEnumerable<string> Get()
        //return new string[] { InvoiceNumber, RandomNumber, AESKey };
        public string Get()
        {
            return "https://ciper804.azurewebsites.net/Ciphert/PL49821416/5871/F1A618ED8685B1A3B81E6CB6884617F4";
        }

        // GET api/<CiphertController>/5
        //[HttpGet("{IN}/{RN}/{Key}.{format?}")]
        [HttpGet("{IN}/{RN}/{Key}")]
        public string Get(string IN, string RN, string Key)
        {
            QREncrypter.InvoiceNumber = IN;
            QREncrypter.RandomNumber = RN;
            QREncrypter.AESKey = Key;
            return QREncrypter.CiphertGet();
        }
        /*
        private JsonResult JsonResult(string v)
        {
            throw new NotImplementedException();
        }
        */
        // POST api/<CiphertController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CiphertController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CiphertController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
