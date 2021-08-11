using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace Transwarranty_website.Controllers
{
    public class TranswarrantyController : Controller
    {
        // GET: Transwarranty
        public static string FINANCIAL_PATH = @"C:\TRANSWARRANTYREPORTS\Financial\Financial\";
        public static string FINANCIALAF_PATH = @"C:\TRANSWARRANTYREPORTS\Financial\AnnualFinancial\";
        public static string FINANCIALAGM_PATH = @"C:\TRANSWARRANTYREPORTS\Financial\AnnualGeneralMeeting\";
        public static string FINANCIALLRR_PATH = @"C:\TRANSWARRANTYREPORTS\Financial\LimitedReviewReport\";
        public static string FINANCIALQR_PATH = @"C:\TRANSWARRANTYREPORTS\Financial\QuarterlyResult\";
        public static string ANNUALTRAN_PATH = @"C:\TRANSWARRANTYREPORTS\Annual\Transwarranty\";
        public static string ANNUALSUB_PATH = @"C:\TRANSWARRANTYREPORTS\Annual\Subcompany\";
        public static string AGM_PATH = @"C:\TRANSWARRANTYREPORTS\AGM\";
        public static string SHARECG_PATH = @"C:\TRANSWARRANTYREPORTS\ShareHolder\CorporateGovernance\";
        public static string SHAREIC_PATH = @"C:\TRANSWARRANTYREPORTS\ShareHolder\Investorcomplaints\";
        public static string SHAREHOLDING_PATH = @"C:\TRANSWARRANTYREPORTS\ShareHolder\ShareHoldingPattern\";
        public static string BOARDMEETING_PATH = @"C:\TRANSWARRANTYREPORTS\ShareHolder\BoardMeeting\";
        public static string GRIEVANCE_PATH = @"C:\TRANSWARRANTYREPORTS\Grievances\";
        public static string POLICIES_PATH = @"C:\TRANSWARRANTYREPORTS\Policies\";
        public static string EXCHANGE_PATH = @"C:\TRANSWARRANTYREPORTS\StockExchange\";
        public static string MATERIAL_PATH = @"C:\TRANSWARRANTYREPORTS\MaterialEvents\";
        public static string ADVERTISMENT_PATH = @"C:\TRANSWARRANTYREPORTS\Advertisment\";
        public static string UNCLAIM_PATH = @"C:\TRANSWARRANTYREPORTS\UnclaimedDividend\";
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Aboutus()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult Services()
        {

            return View();
        }

        public ActionResult Disclaimer()
        {

            return View();
        }
        public ActionResult Privacy_Policy()
        {

            return View();
        }
        public ActionResult Terms_Condition()
        {

            return View();
        }
        //---------------- Investor Relations ,,
        //---------------- 28/06/2021 ,,
        public ActionResult InvestorRelations()
        {
            return View();
        }
        public JsonResult GetFile_InvRelation(string ReportType, string Pattern, string Year, string Period)
        {
            string status = "Success";
            string Type = ReportType;
            string SubOption = Pattern;
            string year = Year;
            string period = Period;

            List<ListItem> files = new List<ListItem>();
            try
            {
                if (ReportType == "financial")
                {
                    if (SubOption == "financial")
                    {
                        string[] filesPath = Directory.GetFiles(FINANCIAL_PATH);
                        foreach (string path in filesPath)
                        {
                            files.Add(new ListItem(Path.GetFileName(path)));
                        }

                    }
                    else if (SubOption == "annualfinancial")
                    {
                        string[] filesPath = Directory.GetFiles(FINANCIALAF_PATH);
                        foreach (string path in filesPath)
                        {
                            files.Add(new ListItem(Path.GetFileName(path)));
                        }
                    }
                    else if (SubOption == "quarterly")
                    {
                        string[] filesPath = Directory.GetFiles(FINANCIALQR_PATH);
                        foreach (string path in filesPath)
                        {
                            files.Add(new ListItem(Path.GetFileName(path)));
                        }
                    }
                    else if (SubOption == "limitedreviewrpt")
                    {
                        string[] filesPath = Directory.GetFiles(FINANCIALLRR_PATH);
                        foreach (string path in filesPath)
                        {
                            files.Add(new ListItem(Path.GetFileName(path)));
                        }
                    }
                    else if (SubOption == "subcompany")
                    {
                        string[] filesPath = Directory.GetFiles(FINANCIALAGM_PATH);
                        foreach (string path in filesPath)
                        {
                            files.Add(new ListItem(Path.GetFileName(path)));
                        }
                    }
                }
                else if (ReportType == "annual")
                {
                    if (Pattern == "annualtranswarranty")
                    {
                        string[] filesPath = Directory.GetFiles(ANNUALTRAN_PATH);
                        foreach (string path in filesPath)
                        {
                            files.Add(new ListItem(Path.GetFileName(path)));
                        }
                    }
                    else if (Pattern == "subcompany")
                    {
                        string[] filesPath = Directory.GetFiles(ANNUALSUB_PATH);
                        foreach (string path in filesPath)
                        {
                            files.Add(new ListItem(Path.GetFileName(path)));
                        }
                    }
                }
                else if (ReportType == "shareholder")
                {
                    if (SubOption == "corporategovernance")
                    {
                        string[] filesPath = Directory.GetFiles(SHARECG_PATH);
                        foreach (string path in filesPath)
                        {
                            files.Add(new ListItem(Path.GetFileName(path)));
                        }
                    }
                    else if (SubOption == "investorcomplaints")
                    {
                        string[] filesPath = Directory.GetFiles(SHAREIC_PATH);
                        foreach (string path in filesPath)
                        {
                            files.Add(new ListItem(Path.GetFileName(path)));
                        }
                    }
                    else if (SubOption == "shareholdingpattern")
                    {
                        string[] filesPath = Directory.GetFiles(SHAREHOLDING_PATH);
                        foreach (string path in filesPath)
                        {
                            files.Add(new ListItem(Path.GetFileName(path)));
                        }
                    }
                    else if (SubOption == "boardmeeting")
                    {
                        string[] filesPath = Directory.GetFiles(BOARDMEETING_PATH);
                        foreach (string path in filesPath)
                        {
                            files.Add(new ListItem(Path.GetFileName(path)));
                        }
                    }
                }
                else if (ReportType == "stockexchange")
                {
                    string[] filesPath = Directory.GetFiles(EXCHANGE_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (ReportType == "materialevents")
                {
                    string[] filesPath = Directory.GetFiles(MATERIAL_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (ReportType == "general")
                {
                    string[] filesPath = Directory.GetFiles(AGM_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (ReportType == "unclaimeddividend")
                {
                    string[] filesPath = Directory.GetFiles(UNCLAIM_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (ReportType == "policies")
                {
                    string[] filesPath = Directory.GetFiles(POLICIES_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (ReportType == "newspaperadvertisment")
                {
                    string[] filesPath = Directory.GetFiles(ADVERTISMENT_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (ReportType == "grievances")
                {
                    string[] filesPath = Directory.GetFiles(GRIEVANCE_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
            }
            catch (Exception Ex)
            {
                status = "Failed;";
            }
            var Result = new { Status = status, lmodel = files };
            return Json(Result, JsonRequestBehavior.AllowGet);

        }
        public FileResult DownloadPdf(string reportId, string type, string subOption)
        {
            string Urlpath = "";
            if (type == "financial")
            {
                if (subOption == "financial")
                {
                    Urlpath = FINANCIAL_PATH;

                }
                else if (subOption == "annualfinancial")
                {
                    Urlpath = FINANCIALAF_PATH;
                }
                else if (subOption == "quarterly")
                {
                    Urlpath = FINANCIALQR_PATH;
                }
                else if (subOption == "limitedreviewrpt")
                {
                    Urlpath = FINANCIALLRR_PATH;
                }
                else if (subOption == "subcompany")
                {
                    Urlpath = FINANCIALAGM_PATH;
                }
            }
            else if (type == "annual")
            {
                if (subOption == "annualtranswarranty")
                {
                    Urlpath = ANNUALTRAN_PATH;
                }
                else if (subOption == "subcompany")
                {
                    Urlpath = ANNUALSUB_PATH;
                }

            }
            else if (type == "shareholder")
            {
                if (subOption == "corporategovernance")
                {
                    Urlpath = SHARECG_PATH;
                }
                else if (subOption == "investorcomplaints")
                {
                    Urlpath = SHAREIC_PATH;
                }
                else if (subOption == "shareholdingpattern")
                {
                    Urlpath = SHAREHOLDING_PATH;
                }
                else if (subOption == "boardmeeting")
                {
                    Urlpath = BOARDMEETING_PATH;
                }
            }
            else if (type == "stockexchange")
            {
                Urlpath = EXCHANGE_PATH;
            }
            else if (type == "materialevents")
            {
                Urlpath = MATERIAL_PATH;
            }
            else if (type == "general")
            {
                Urlpath = AGM_PATH;
            }
            else if (type == "unclaimeddividend")
            {
                Urlpath = UNCLAIM_PATH;
            }
            else if (type == "newspaperadvertisment")
            {
                Urlpath = ADVERTISMENT_PATH;
            }
            else if (type == "policies")
            {
                Urlpath = POLICIES_PATH;
            }
            else if (type == "grievances")
            {
                Urlpath = GRIEVANCE_PATH;
            }

            string path = Urlpath + reportId;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", reportId);
        }
    }
}