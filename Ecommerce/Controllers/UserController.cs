using Ecommerce.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class UserController : Controller
    {

        dbmarketingEntities db = new dbmarketingEntities();
        // GET: User
        public ActionResult Index(int ? page)
        {
            

                int pagesize = 9, pageindex = 1;
                pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
                var list = db.tbl_category.Where(x => x.cat_status == 1).OrderByDescending(x => x.cat_id).ToList();
                IPagedList<tbl_category> stu = list.ToPagedList(pageindex, pagesize);

                return View(stu);

            
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }



        [HttpPost]
        public ActionResult Login(tbl_user us)
        {
            tbl_user ad = db.tbl_user.Where(x => x.u_email == us.u_email && x.u_password == us.u_password).SingleOrDefault();
            if (ad != null)
            {
                Session["u_id"] = us.u_id.ToString();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Invalid username or password";

            }
            return View();

        }




        [HttpGet]
        public ActionResult Singup()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Singup(tbl_user uvm, HttpPostedFileBase imgfile)
        {
            string path = uploadingimgfile(imgfile);

            if (path.Equals("-1"))
            {

                ViewBag.error = "Image could not be uploaded";
            }

            else
            {
                tbl_user us = new tbl_user();
                us.u_name = uvm.u_name;
                us.u_email = uvm.u_email;
                us.u_password = uvm.u_password;
                us.u_contact = uvm.u_contact;
                us.u_image = path;
                db.tbl_user.Add(us);
                db.SaveChanges();

                return RedirectToAction("Login");

            }


            return View();
        }


        //image uploader code
        public string uploadingimgfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {

                string extension = Path.GetExtension(file.FileName);

                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {

                    try
                    {

                        path = Path.Combine(Server.MapPath("~/Content/user"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);

                        path = "~/Content/user/" + random + Path.GetFileName(file.FileName);

                    }

                    catch (Exception ex)
                    {

                        path = "-1";

                    }

                }

                else
                {
                    Response.Write("<script> alert('Only jpg, jpeg or png formats are acceptable')</script>");
                }

            }

            else
            {

                Response.Write("<script>alert('Please select a file')</script>");
                path = "-1";

            }

            return path;

        }

    }
}