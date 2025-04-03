using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAppMVCLCT.Models;

namespace WebAppMVCLCT.Controllers
{
    public class SPCurdController : Controller
    {
        public readonly Databasecontext _context;
        public SPCurdController(Databasecontext context)
        {
            _context = context;
        }
        [SetSessionGlobally]

        [HttpGet]
       
        public IActionResult AddData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddData(UsersModel obj)
        {

            // insert ope using sp
            string sqlsp = "exec Sp_InsertUsers @name,@Email,@password,@dob,@salary,@address";

            List<SqlParameter> para = new List<SqlParameter>() {
            new SqlParameter{ ParameterName="@name",Value=obj.Name},
            new SqlParameter{ ParameterName="@Email",Value=obj.Email},
            new SqlParameter{ ParameterName="@Password",Value=obj.Password},
            new SqlParameter{ ParameterName="@Dob",Value=obj.Dob},
            new SqlParameter{ ParameterName="@Salary",Value=obj.Salary},
            new SqlParameter{ ParameterName="@Address",Value=obj.Address}
            };
            var res = _context.Database.ExecuteSqlRaw(sqlsp, para.ToArray());
            if (res > 0)
            {
                return RedirectToAction("GetData");
            }
            return View();
        }


        [SetSessionGlobally]
        public IActionResult GetData()
        {
            string sql = "exec Sp_GetData";
            List<UsersModel> obj;
            obj = _context.UsersModel.FromSqlRaw(sql).ToList();
            return View(obj);
        }


        [SetSessionGlobally]
        [HttpGet]

       
        public IActionResult UpdateData(int ID)
        {
            UsersModel obj;
            string sql = "exec sp_getdatabyid @id";
            List<SqlParameter> para = new List<SqlParameter>() {
            new SqlParameter{ ParameterName="@id",Value=ID}
            };
            obj = _context.UsersModel.FromSqlRaw(sql, para.ToArray()).AsEnumerable().FirstOrDefault();
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateData(UsersModel obj)
        { // insert ope using sp
            string sqlsp = "exec Sp_UpdateUsers @name,@Email,@password,@dob,@salary,@address,@ID";

            List<SqlParameter> para = new List<SqlParameter>() {
            new SqlParameter{ ParameterName="@name",Value=obj.Name},
            new SqlParameter{ ParameterName="@Email",Value=obj.Email},
            new SqlParameter{ ParameterName="@Password",Value=obj.Password},
            new SqlParameter{ ParameterName="@Dob",Value=obj.Dob},
            new SqlParameter{ ParameterName="@Salary",Value=obj.Salary},
            new SqlParameter{ ParameterName="@Address",Value=obj.Address},
             new SqlParameter{ ParameterName="@ID",Value=obj.ID},
            };
            var res = _context.Database.ExecuteSqlRaw(sqlsp, para.ToArray());
            if (res > 0)
            {
                return RedirectToAction("GetData");
            }
            return View();
        }

        public IActionResult DeleteData(int ID)
        {
            string sql = "exec Sp_DeleteData @ID";
            List<SqlParameter> para = new List<SqlParameter>() {
            new SqlParameter{ ParameterName="@ID",Value=ID}
            };
            var res = _context.Database.ExecuteSqlRaw(sql, para.ToArray());
            if (res > 0)
            {
                return RedirectToAction("GetData");
            }
            return View();
        }
    }
}
