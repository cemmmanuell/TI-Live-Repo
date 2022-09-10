namespace mmmSelfservice.Controllers
{
    using mmmSelfservice;
    using Newtonsoft.Json;
    using System;
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;
    using System.Xml.Serialization;

    public class LoginController : Controller
    {
        [HttpPost]
        public JsonResult authenticate(string username, string password)
        {
            userMetaData data = new userMetaData();
            if (WSConfig.ObjNav.Fnlogin(username, password))
            {
                base.Session["UserName"] = username;
                data.AuthSuccess = true;
                data.username = base.Session["Username"].ToString();
                string str = JsonConvert.SerializeObject(data);
                return new JsonResult { Data = data };
            }
            data.AuthSuccess = false;
            data.Message = "Login failed";
            return new JsonResult { Data = data };
        }

        public JsonResult changepassword(string username, string otp, string password1, string password2)
        {
            userMetaData data = new userMetaData();
            if (password1 == password2)
            {
                if (password1.Length < 6)
                {
                    data.AuthSuccess = false;
                    data.Message = "Please ensure that your password is more than 6 characters";
                }
                else
                {
                    try
                    {
                        if (WSConfig.ObjNav.FnRegister(username, otp, password1))
                        {
                            data.AuthSuccess = true;
                            data.Message = "Registration successful please proceed to login";
                        }
                        else
                        {
                            data.AuthSuccess = false;
                            data.Message = "Registration failed please confirm your details and try again";
                        }
                    }
                    catch (Exception)
                    {
                        data.AuthSuccess = false;
                        data.Message = "System error occured";
                    }
                }
            }
            else
            {
                data.AuthSuccess = false;
                data.Message = "Passwords do not match";
            }
            return new JsonResult { Data = data };
        }

        public ActionResult Index()
        {
            return base.View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            base.Session["id1"] = null;
            base.Session["id2"] = null;
            base.Session["id3"] = null;
            base.Session["id4"] = null;
            base.Session["Region"] = null;
            base.Session.Clear();
            base.Session.RemoveAll();
            base.Session.Abandon();
            base.Response.AddHeader("Cache-control", "no-store, must-revalidate, private, no-cache");
            base.Response.AddHeader("Pragma", "no-cache");
            base.Response.AddHeader("Expires", "0");
            base.Response.AppendToLog("window.location.reload();");
            return base.RedirectToAction("Index", "Login");
        }

        public JsonResult register(string username, string email, string idnumber)
        {
            userMetaData data = new userMetaData();
            try
            {
                if (WSConfig.ObjNav.Fninserreccode(username, idnumber, email))
                {
                    data.AuthSuccess = true;
                    data.Message = "A one time password has been sent to your email please check and use in the next steps";
                }
                else
                {
                    data.AuthSuccess = false;
                    data.Message = "Registration failed please confirm your details and try again";
                }
            }
            catch (Exception)
            {
                data.AuthSuccess = false;
                data.Message = "System error occured";
            }
            return new JsonResult { Data = data };
        }

        public class userMetaData
        {
            public string username { get; set; }

            public string role { get; set; }

            public string status { get; set; }

            public bool AuthSuccess { get; set; }

            public string Message { get; set; }
        }
    }
}

