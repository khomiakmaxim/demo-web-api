using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    /// <summary>
    /// This is where i give you all the information about people
    /// </summary>
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();
        /// <summary>
        /// Controller, means you can not get here
        /// </summary>
        public PeopleController()
        {
            people.Add(new Person { FirstName = "Max", LastName = "Khomiak", Id = 1 });
            people.Add(new Person { FirstName = "Susan", LastName = "Cat", Id = 2 });
            people.Add(new Person { FirstName = "Bilbo", LastName = "Baggins", Id = 3 });
        }

        /// <summary>
        /// Retrieving all user names
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        [Route("api/People/GetFirstNames/{userId:int}/{age:int}")]  //the default route is overriten now
        [HttpGet]   //only allowed for http
        public List<string> GetFirstNames(int userId, int age)
        {
            List<string> output = new List<string>();

            foreach (var p in people)
            {
                output.Add(p.FirstName);
            }

            return output;
        }

        /// <summary>
        /// get all people
        /// </summary>
        /// <returns></returns>
        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        /// <summary>
        /// get specific person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(e => e.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// post specific person
        /// </summary>
        /// <param name="val"></param>
        // POST: api/People
        public void Post(Person val)
        {
            people.Add(val);
        }


        /// <summary>
        /// delete specific person
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/People/5
        public void Delete(int id)
        {
            people.Remove(people[id]);
        }
    }
}
