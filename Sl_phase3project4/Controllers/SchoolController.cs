using ClassLibrary1;
using ClassLibrary3;
using Sl_phase3project4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace Sl_phase3project4.Controllers
{
    public class SchoolController : ApiController
    {
        Helper helper = null;
        public SchoolController()
        {
            helper = new Helper();
        }

        [Route("GetAllMarks")]
        public List<School> GetBookList()
        {
            //return new string[] { "value1", "value2" };

            List<BAL> empbal = new List<BAL>(); empbal = helper.ShowMarkList();
            List<School> emps = new List<School>();
            foreach (var item in empbal)
            {
                //Employees emp = new Employees();
                emps.Add(new School { Marks  = item.Marks, Subjectid = item.Subjectid, Studentid = item.Studentid });
            }
            return emps;

        }
        [Route("FindMarks/{id}")]

        public School GetBookByID(int id)
        {
            BAL empbal = new BAL();
            empbal = helper.SearchMark(id);
            School emp = new School();

            emp.Marks = empbal.Marks;
            emp.Subjectid = empbal.Subjectid;
            emp.Studentid = empbal.Studentid;

            return emp;

        }


        [Route("AddMark")]
        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] School empdata)
        {
            BAL empbal = new BAL();
            empbal.Marks = empdata.Marks;
            empbal.Subjectid = empdata.Subjectid;
            empbal.Studentid = empdata.Studentid;
           
            bool ans = helper.addmarks(empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
        [Route("UpdateMark/{id}")]
        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] School empdata)
        {
            BAL empbal = new BAL();
            empbal.Marks = empdata.Marks;
            empbal.Subjectid = empdata.Subjectid;
            empbal.Studentid = empdata.Studentid;


            bool ans = helper.editmarks(empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // DELETE api/<controller>/5
        [Route("DeleteMark/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool ans = helper.RemoveMark(id);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

    }
}