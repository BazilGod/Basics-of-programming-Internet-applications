using Lab_9.Models;
using PIS_MVC5_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;

namespace Lab_9.Controllers
{
    public class ValuesController : ApiController
    {
        PhoneContext _context = new PhoneContext();

        public IHttpActionResult Get(
                int limit = 2,
                int offset = 0,
                int minId = 0,
                int maxId = 100,
                string sort = "ID",
                string columns = null,
                string like = null,
                string globalLike = null
            )
        {
            IQueryable<User> users = null;

            if (sort.ToLower() == "name")
            {
                users = _context.Users.OrderBy(prop => prop.Name);
            }
            else if (sort.ToLower() == "id")
            {
                users = _context.Users.OrderBy(prop => prop.Id);
            }
            else
            {
                return BadRequest();
            }

            users = users.Skip(offset)
                .Take(limit)
                .Where(prop => prop.Id >= minId && prop.Id <= maxId);

            if (like != null)
            {
                users = users.Where(prop => prop.Name.ToLower().Contains(like.ToLower()));
            }

            if (globalLike != null)
            {
                users = users.Where(prop => (prop.Name + prop.Id.ToString() + prop.Phone).ToLower().Contains(globalLike.ToLower()));
            }

            IEnumerable<User> resultUsers = null;
            List<dynamic> res = new List<dynamic>();

           

            resultUsers = users.ToList();
            foreach (var item in resultUsers)
            {
                dynamic temp = new ExpandoObject();
                temp.Id = item.Id;
                temp.Name = item.Name;
                temp.Phone = item.Phone;
                temp.Links = new
                {
                    hrefP = $"api/values/{item.Id-1}",
                    href = $"api/values/{item.Id}",
                    hrefN = $"api/values/{item.Id+1}",
                    rel = "User",
                    type = Request.Method.Method
                };
                res.Add(temp);
            }

            return Ok(res);
        }

        public IHttpActionResult Get(int id)
        {
            User user = _context.Users.FirstOrDefault(a => a.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

       
        public IHttpActionResult Post([FromBody]User item)
        {
            if (ModelState.IsValid)
            {
                User user = _context.Users.Add(item);
                _context.SaveChanges();
                return Ok(user);
            }
            return BadRequest(ModelState);
        }

        
        public IHttpActionResult Put([FromBody]User item)
        {
            if (ModelState.IsValid)
            {
                User user = _context.Users.FirstOrDefault(p => p.Id == item.Id);
                if (user != null)
                {
                    user.Name = item.Name;
                    user.Phone = item.Phone;
                    _context.Entry(user).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Ok(user);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

    
        public IHttpActionResult Delete(int id)
        {
            User user = _context.Users.FirstOrDefault(p => p.Id == id);
            if (user != null)
            {
                user = _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok(user);
            }
            return NotFound();
        }

    }
}

//HATEOAS — один из принципов REST, предписывающий ресурсу нести в себе информацию об отношениях с другими ресурсами
