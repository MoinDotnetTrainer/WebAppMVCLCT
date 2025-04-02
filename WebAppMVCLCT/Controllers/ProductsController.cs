using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAppMVCLCT.Models;

namespace WebAppMVCLCT.Controllers
{
    public class ProductsController : Controller
    {
        public readonly Databasecontext _context;
        public ProductsController(Databasecontext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult AddProducts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProducts(ProductsModel obj)
        {
            //insert,sp
            string sql = "exec sp_Insertproducts @PName,@Category,@Qty,@ExpiryDate";
            List<SqlParameter> para = new List<SqlParameter>() {
            new SqlParameter{ ParameterName="@PName",Value=obj.PName},
             new SqlParameter{ ParameterName="@Category",Value=obj.Category},
              new SqlParameter{ ParameterName="@Qty",Value=obj.Qty},
               new SqlParameter{ ParameterName="@ExpiryDate",Value=obj.ExpiryDate}

            };
            var res = _context.Database.ExecuteSqlRaw(sql, para.ToArray());
            if (res > 0)
            {
                return RedirectToAction("GetProducts");
            }
            return View();
        }

        public IActionResult GetProducts()
        {
            string sql = "exec Sp_GetAllProducts";
            List<ProductsModel> obj;
            obj = _context.ProductsModel.FromSqlRaw(sql).ToList();
            return View(obj);
        }


        [HttpGet]
        public IActionResult UpdateProducts(int ProductId)
        {
            ProductsModel obj_;
            string sql = "exec Sp_GetProductsByID @ProductId";
            List<SqlParameter> para = new List<SqlParameter>() {
            new SqlParameter{ ParameterName="@ProductId" ,Value=ProductId}

            };
            //get  existing products on load

            obj_ = _context.ProductsModel.FromSqlRaw(sql, para.ToArray()).AsEnumerable().FirstOrDefault();
            return View(obj_);
        }

        [HttpPost]
        public IActionResult UpdateProducts(ProductsModel obj)
        {
            string sql = "exec sp_Updateproducts @PName,@Category,@Qty,@ExpiryDate,@ProductId";
            List<SqlParameter> para = new List<SqlParameter>() {
            new SqlParameter{ ParameterName="@PName",Value=obj.PName},
            new SqlParameter{ ParameterName="@Category",Value=obj.Category},
            new SqlParameter{ ParameterName="@Qty",Value=obj.Qty},
            new SqlParameter{ ParameterName="@ExpiryDate",Value=obj.ExpiryDate},
            new SqlParameter{ ParameterName="@ProductId",Value=obj.ProductId}

            };
            var res = _context.Database.ExecuteSqlRaw(sql, para.ToArray());
            if (res > 0)
            {
                return RedirectToAction("GetProducts");
            }
            return View();
        }

        public IActionResult DeleteProducts(int ProductId)
        {
            string sql = "exec Sp_DeleteProducts @ProductId";
            List<SqlParameter> para = new List<SqlParameter>() {
            new SqlParameter{ ParameterName="ProductId" ,Value=ProductId}

            };
            var res = _context.Database.ExecuteSqlRaw(sql, para.ToArray());
            if (res > 0)
            {
                return RedirectToAction("GetProducts");
            }
            return View();
        }
    }
}
