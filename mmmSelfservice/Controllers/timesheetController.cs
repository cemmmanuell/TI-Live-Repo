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
            return View();
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

        // POST timesheet
        public JsonResult postTimesheet(timesheet m)
        {
            resultMt mt = new resultMt();
            try
            {
                IEnumerable<timesheet> z = JsonConvert.DeserializeObject<IEnumerable<timesheet>>(WSConfig.ObjNav.FnGetTimesheets(Session["username"].ToString()));
                string code = "";
                if (z.Where(r => r.year == m.year && r.projectCode == m.projectCode).Count() == 0)
                {


                    code = WSConfig.ObjNav.FnInsertTimeSheet("", m.projectCode, DateTime.Now, Session["username"].ToString(), m.year);
                }
                else
                {
                    code = m.projectCode + m.year.ToString();
                }

                if (m.Timesheetlines.Count() != 0)
                {
                    foreach (var l in m.Timesheetlines)
                    {
                        try
                        {
                            if (l.entryno == 0)
                            {
                                if (l.comments != null )
                                {
                                    WSConfig.ObjNav.FnInsertTimesheetLines(code, l.fromdate, l.todate, l.comments);
                                }
                            }
                            else
                            {
                               if
                                     (l.comments != null)
                                    {
                                        WSConfig.ObjNav.FnModifyTimesheetLines(code, l.fromdate, l.todate, l.entryno, l.comments);
                                    }
                            }

                        }
                        catch (Exception e)
                        {
                            mt.message = e.ToString();
                            mt.status = false;
                            return new JsonResult { Data = mt };
                        }
                    }

                }
                m.code = code;
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
                string code = "";
                code = WSConfig.ObjNav.FnModifyTimeSheet (m.name, m.projectCode, m.startdate, m.code, Session["username"].ToString(), m.year);

                if (m.Timesheetlines.Count() != 0)
                {
                    foreach (var l in m.Timesheetlines)
                    {
                        try
                        {
                            WSConfig.ObjNav.FnModifyTimesheetLines(code, l.fromdate, l.todate,l.entryno, l.comments);

                        }
                        catch (Exception e)
                        {
                            mt.message = e.InnerException.Message;
                            mt.status = false;
                            return new JsonResult { Data = mt };
                        }
                    }

                }
                m.code = code;
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
    }
}
