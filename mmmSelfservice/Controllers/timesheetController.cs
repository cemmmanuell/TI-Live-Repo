using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mmmSelfservice.Models;
using Newtonsoft.Json;

namespace mmmSelfservice.Controllers
{
    public class timesheetController : Controller
    {
        // GET: timesheet
        public ActionResult Index()
        {

          //  try
          //  {
                IEnumerable<timesheet> m = JsonConvert.DeserializeObject<IEnumerable<timesheet>>(WSConfig.ObjNav.FnGetTimesheets(Session["username"].ToString()));
                return View(m.Where(r => r.status == "Open"));
          //  } catch (Exception e)
          //  {
                return null;
          //  }
        }
        public ActionResult Pending()
        {

            try
            {
                IEnumerable<timesheet> m = JsonConvert.DeserializeObject<IEnumerable<timesheet>>(WSConfig.ObjNav.FnGetTimesheets(Session["username"].ToString()));
                return View(m.Where(r=>r.status=="ApprovalPending"));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public ActionResult Approved()
        {

            try
            {
                IEnumerable<timesheet> m = JsonConvert.DeserializeObject<IEnumerable<timesheet>>(WSConfig.ObjNav.FnGetTimesheets(Session["username"].ToString()));
                return View(m.Where(r => r.status == "Approved"));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public PartialViewResult editTimesheet(string entryNo)
        {
            try
            {
                IEnumerable<timesheet> m = JsonConvert.DeserializeObject<IEnumerable<TimesheetLinesL>>(WSConfig.ObjNav.FnGetTimesheets(Session["username"].ToString()));
                return PartialView(m.Where(r=>r.code==entryNo).FirstOrDefault());
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public PartialViewResult FilterIndex(int year, string project)
        {
            IEnumerable<timesheet> m = JsonConvert.DeserializeObject<IEnumerable<timesheet>>(WSConfig.ObjNav.FnGetTimesheets(Session["username"].ToString()));


            return PartialView(m.Where(r=>r.year==year && r.projectCode==project).FirstOrDefault());
        }
        public class resultMt
        {
            public bool status { get; set; }

            public string message { get; set; }

            public string html { get; set; }
            public timesheet payload { get; set; }
        }


        public ActionResult imprestreq(string no)
        {
            WSConfig.ObjNav.FnApproval(no);
            return base.RedirectToAction("index", "timesheet");
        }
        // POST timesheet
        public JsonResult postTimesheet(timesheet m)
        {
            resultMt mt = new resultMt();
            try
            {
              
                if (m.Timesheetlines.Count() != 0)
                {
                    int count = 0;
                    foreach (var l in m.Timesheetlines)
                    {
                        if (l.hours > 0)
                        {

                            try
                            {
                                WSConfig.ObjNav.FnInsertTimeSheet(l.comments, l.projectCode, m.startdate, Session["userName"].ToString(), count, m.endDate, Convert.ToInt32(l.hours)); ;
                            }
                            catch (Exception e)
                            {
                                mt.message = e.ToString();
                                mt.status = false;
                                return new JsonResult { Data = mt };
                            }
                            count++;
                        }
                    }

                }
              //  m.code = code;
                mt.status = true;
                mt.payload = m;

                return new JsonResult { Data = mt };
            }
            catch (Exception e)
            {


                mt.message = e.ToString();
                mt.status = false;
                return new JsonResult { Data = mt };
            }
        }

        //PUT timesheet
        public JsonResult putTimesheet(timesheet m)
        {
            resultMt mt = new resultMt();
            try
            {
             // int code = 0;
              // code = WSConfig.ObjNav.FnModifyTimeSheet (m.name,m.projectCode,m.startdate,"", Session["userName"].ToString(),m.year,m.code, m.endDate );

               if (m.Timesheetlines.Count() != 0)
                {
                   foreach (var l in m.Timesheetlines)
                  {
                       try
                       {
                            WSConfig.ObjNav.FnModifyTimeSheet(m.code, l.projectCode, Convert.ToDateTime(l.date), "", Session["userName"].ToString(), Convert.ToInt32( l.hours), 0, m.endDate);

                       }
                        catch (Exception e)
                       {
                            mt.message = e.InnerException.Message;
                            mt.status = false;
                            return new JsonResult { Data = mt };
                       }
                  }

                }
               m.code = m.code;
              mt.status = true;
               mt.payload = m;

                return new JsonResult { Data = mt };
            }
            catch (Exception e)
            {


                mt.message = e.InnerException.Message;
                mt.status = false;
                return new JsonResult { Data = mt };
            }
        }

       
        public PartialViewResult years()
        {
            int[] years = new int[6];
            for(int i=0;i<6; i++)
            {
                years[i] = (DateTime.Now.Year - 1) + i;
            }

            return PartialView(years);
        }


        public PartialViewResult newTimesheet()
        {

            List<mmmSelfservice.Models.departmentvalue> model = JsonConvert.DeserializeObject<List<mmmSelfservice.Models.departmentvalue>>(WSConfig.ObjNav.FnDepartmentValueLeave(Session["username"].ToString()));
            return base.PartialView(model);
        }
        public ActionResult TimeSheetList()
        {
            IEnumerable<timesheet> m = JsonConvert.DeserializeObject<IEnumerable<timesheet>>(WSConfig.ObjNav.FnGetTimesheets(Session["username"].ToString()));
            return View(m);
        }
    }
}
