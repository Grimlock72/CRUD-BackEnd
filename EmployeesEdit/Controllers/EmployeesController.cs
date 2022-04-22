using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesEdit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.EmployeesContext db = new Models.EmployeesContext())
            {
                var list = (from d in db.TblUsers
                            select d).ToList();
                return Ok(list);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.EmployeeRequest model)
        {
            using (Models.EmployeesContext db = new Models.EmployeesContext())
            {
                Models.TblUser oTblUser = new Models.TblUser();
                oTblUser.UserName = model.UserName;
                oTblUser.Password = model.Password;
                oTblUser.IdEmployee = model.IdEmployee;
                oTblUser.IdProfile = model.IdProfile;
                oTblUser.Status = model.Status;
                oTblUser.Login = model.Login;
                db.TblUsers.Add(oTblUser);
                db.SaveChanges();
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.EmployeeEditRequest model)
        {
            using (Models.EmployeesContext db = new Models.EmployeesContext())
            {
                Models.TblUser oTblUser = db.TblUsers.Find(model.IdUser);
                oTblUser.IdUser = model.IdUser;
                oTblUser.UserName = model.UserName;
                oTblUser.IdProfile = model.IdProfile;
                db.Entry(oTblUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.EmployeeEditRequest model)
        {
            using (Models.EmployeesContext db = new Models.EmployeesContext())
            {
                Models.TblUser oTblUser = db.TblUsers.Find(model.IdUser);
                db.TblUsers.Remove(oTblUser);
                db.SaveChanges();
            }

            return Ok();
        }
    }
}
