using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PagedList;

namespace Ecommerce.Controllers
{
    public class AdminController : Controller
    {
        dbmarketingEntities db = new dbmarketingEntities();
        // GET: Admin
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(tbl_admin avm )
        {
            tbl_admin ad = db.tbl_admin.Where(x => x.ad_username == avm.ad_username && x.ad_password == avm.ad_password).SingleOrDefault();
            if(ad!=null)
            {
                Session["ad_id"] = ad.ad_id.ToString();
                return RedirectToAction("Create");
            }
            else
            {
                ViewBag.error = "Invalid username or password";

            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["ad_id"]==null)
            {
                return RedirectToAction("login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_category cvm,HttpPostedFileBase imgfile)
        {
            string path = uploadingimgfile(imgfile);

           if(path.Equals("-1"))
            {

                ViewBag.error = "Image could not be uploaded";
            }

            else
            {
                tbl_category cat = new tbl_category();
                cat.cat_name = cvm.cat_name;
                cat.cat_image = path;
                cat.cat_status = 1;
                cat.cat_fk_ad = Convert.ToInt32(Session["ad_id"].ToString());
                db.tbl_category.Add(cat);
                db.SaveChanges();

                return RedirectToAction("ViewCategory");

            }

            return View();
        }

        [HttpGet]
        public ActionResult ViewCategory(int ?page)
        {

            if (Session["ad_id"] == null)
            {
                return RedirectToAction("login");
            }

            else
            {

                int pagesize = 9, pageindex = 1;
                pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
                var list = db.tbl_category.Where(x => x.cat_status == 1).OrderByDescending(x=>x.cat_id).ToList();
                IPagedList<tbl_category> stu = list.ToPagedList(pageindex, pagesize);

                return View(stu);

            }
        }




        //image uploader code
        public string uploadingimgfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if(file != null && file.ContentLength>0)
            {

                string extension = Path.GetExtension(file.FileName);

                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {

                    try
                    {

                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);

                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);

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