using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace Transwarranty_website.Controllers
{
    public class TranswarrantyController : Controller
    {
        // GET: Transwarranty
        public static string FINANCIAL_PATH = @"C:\TRANSWARRANTYREPORTS\Financial\";
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
        //public static string BOARDMEETING_PATH = @"C:\TRANSWARRANTYREPORTS\ShareHolder\BoardMeeting\";
        public static string GRIEVANCE_PATH = @"C:\TRANSWARRANTYREPORTS\Grievances\";
        public static string POLICIES_PATH = @"C:\TRANSWARRANTYREPORTS\Policies\";
        //public static string EXCHANGE_PATH = @"C:\TRANSWARRANTYREPORTS\StockExchange\";
        //public static string MATERIAL_PATH = @"C:\TRANSWARRANTYREPORTS\MaterialEvents\";
        //public static string ADVERTISMENT_PATH = @"C:\TRANSWARRANTYREPORTS\Advertisment\";
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
        //--################### Send Mail ,,
        //--################### 03-September-2021 ,,
        public JsonResult SendMail(string Name, string Email, string Subject, string Message)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] bytes = memoryStream.ToArray();
                MailMessage mm = new MailMessage("help@transwarranty.com", "nikhilmu96@vertexbroking.com");
                mm.Subject = Subject;
                //StringBuilder sb = new StringBuilder();
                //sb.AppendLine("Name: " + Name);
                //sb.AppendLine("Email: " + Email);
                //sb.AppendLine("Subject: " + Subject);
                //sb.AppendLine("Message: " + Message);
                string sName = "Name:" + Name + "";
                string sEmail = "Email:" + Email + "";
                string sSubject = "Subject:" + Subject + "";
                string sMessage = "Message:" + Message + "";
                string Body = sName + "\n" + sEmail + "\n" + sSubject + "\n" + sMessage;
                mm.Body = Body;
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.rediffmailpro.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "help@transwarranty.com";
                NetworkCred.Password = "01012011";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
            var Result = new { Status = "Success"};
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        //--########################################
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
                    if (SubOption == "transwarranty")
                    {
                        string FINTranswarranty_PATH = @"C:\TRANSWARRANTYREPORTS\Financial\Transwarranty\" + ReportType + "_" + Pattern + "_" + Year + "_" + Period + ".pdf" + "";
                        if (System.IO.File.Exists(FINTranswarranty_PATH))
                        {
                            files.Add(new ListItem(Path.GetFileName(FINTranswarranty_PATH)));
                        }

                    }
                    else if (SubOption == "subcompany")
                    {
                        string FINSubCompany_PATH = @"C:\TRANSWARRANTYREPORTS\Financial\Subcompany\" + ReportType + "_" + Pattern + "_" + Year + "_" + Period + ".pdf" + "";
                        if (System.IO.File.Exists(FINSubCompany_PATH))
                        {
                            files.Add(new ListItem(Path.GetFileName(FINSubCompany_PATH)));
                        }

                    }
                }
                else if (ReportType == "annual")
                {
                    if (Pattern == "transwarranty")
                    {
                        string ANNTranswarranty_PATH = @"C:\TRANSWARRANTYREPORTS\Annual\Transwarranty\" + ReportType + "_" + Pattern + "_" + Year + ".pdf" + "";
                        if (System.IO.File.Exists(ANNTranswarranty_PATH))
                        {
                            files.Add(new ListItem(Path.GetFileName(ANNTranswarranty_PATH)));
                        }
                    }
                    else if (Pattern == "subcompany")
                    {
                        string ANNSubCompany_PATH = @"C:\TRANSWARRANTYREPORTS\Annual\Subcompany\" + ReportType + "_" + Pattern + "_" + Year + ".pdf" + "";
                        if (System.IO.File.Exists(ANNSubCompany_PATH))
                        {
                            files.Add(new ListItem(Path.GetFileName(ANNSubCompany_PATH)));
                        }

                    }
                }
                else if (ReportType == "shareholder")
                {
                    if (SubOption == "corporategovernance")
                    {
                        string SHAGovernance_PATH = @"C:\TRANSWARRANTYREPORTS\ShareHolder\CorporateGovernance\" + ReportType + "_" + Pattern + "_" + Year + "_" + Period + ".pdf" + "";
                        if (System.IO.File.Exists(SHAGovernance_PATH))
                        {
                            files.Add(new ListItem(Path.GetFileName(SHAGovernance_PATH)));
                        }
                    }
                    else if (SubOption == "investorcomplaints")
                    {
                        string SHAInvestor_PATH = @"C:\TRANSWARRANTYREPORTS\ShareHolder\InvestorComplaints\" + ReportType + "_" + Pattern + "_" + Year + "_" + Period + ".pdf" + "";
                        if (System.IO.File.Exists(SHAInvestor_PATH))
                        {
                            files.Add(new ListItem(Path.GetFileName(SHAInvestor_PATH)));
                        }
                    }
                    else if (SubOption == "shareholdingpattern")
                    {
                        string SHAShareHolding_PATH = @"C:\TRANSWARRANTYREPORTS\ShareHolder\ShareholdingPattern\" + ReportType + "_" + Pattern + "_" + Year + "_" + Period + ".pdf" + "";
                        if (System.IO.File.Exists(SHAShareHolding_PATH))
                        {
                            files.Add(new ListItem(Path.GetFileName(SHAShareHolding_PATH)));
                        }
                    }
                    else if (SubOption == "boardmeeting")
                    {
                        string SHABoardMeeting_PATH = @"C:\TRANSWARRANTYREPORTS\ShareHolder\BoardMeeting\" + Year + "\\";
                        string[] filesPath = Directory.GetFiles(SHABoardMeeting_PATH);
                        foreach (string path in filesPath)
                        {
                            files.Add(new ListItem(Path.GetFileName(path)));
                        }
                    }
                }
                else if (ReportType == "stockexchange")
                {
                    string EXCHANGE_PATH = @"C:\TRANSWARRANTYREPORTS\StockExchange\" + Year + "\\";
                    string[] filesPath = Directory.GetFiles(EXCHANGE_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (ReportType == "materialevents")
                {
                    string MATERIAL_PATH = @"C:\TRANSWARRANTYREPORTS\MaterialEvents\" + Year + "\\";
                    string[] filesPath = Directory.GetFiles(MATERIAL_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (ReportType == "AgmAndEgm")
                {
                    string AgmAndEgm_PATH = @"C:\TRANSWARRANTYREPORTS\AGM\" + Year + "\\";
                    string directoryName = Path.GetDirectoryName(AgmAndEgm_PATH);
                    foreach (String filename in Directory.GetFiles(directoryName))
                    {
                        if (System.IO.File.Exists(filename))
                        {
                            files.Add(new ListItem(Path.GetFileName(filename)));
                        }
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
                    string ADVERTISMENT_PATH = @"C:\TRANSWARRANTYREPORTS\Advertisment\" + Year + "\\";
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

        public FileResult DownloadSinglePdf(string ReportType, string ReportName)
        {
            string path = "";
            if (ReportType == "financial")
            {
                path = @"C:\TRANSWARRANTYREPORTS\Financial\Transwarranty\" + ReportName + "";
            }
            else if (ReportType == "subcompany")
            {
                path = @"C:\TRANSWARRANTYREPORTS\Financial\Subcompany\" + ReportName + "";
            }
            else if (ReportType == "corporategovernance")
            {
                path = @"C:\TRANSWARRANTYREPORTS\ShareHolder\CorporateGovernance\" + ReportName + "";
            }
            else if (ReportType == "investorcomplaints")
            {
                path = @"C:\TRANSWARRANTYREPORTS\ShareHolder\InvestorComplaints\" + ReportName + "";
            }
            else if (ReportType == "shareholdingpattern")
            {
                path = @"C:\TRANSWARRANTYREPORTS\ShareHolder\ShareholdingPattern\" + ReportName + "";
            }
            else if (ReportType == "annualtranswarranty")
            {
                path = @"C:\TRANSWARRANTYREPORTS\Annual\Transwarranty\" + ReportName + "";
            }
            else if (ReportType == "annualsubcompany")
            {
                path = @"C:\TRANSWARRANTYREPORTS\Annual\Subcompany\" + ReportName + "";
            }

            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", ReportName + ".pdf");
        }
        public FileResult DownloadPdf(string reportId, string type, string subOption, string year)
        {
            string Urlpath = "";
            if (type == "stockexchange")
            {
                string EXCHANGE_PATH = @"C:\TRANSWARRANTYREPORTS\StockExchange\" + year + "\\";
                Urlpath = EXCHANGE_PATH;
            }
            else if (type == "materialevents")
            {
                string MATERIAL_PATH = @"C:\TRANSWARRANTYREPORTS\MaterialEvents\" + year + "\\";
                Urlpath = MATERIAL_PATH;
            }
            else if (type == "AgmAndEgm")
            {
                string AgmAndEgm_PATH = @"C:\TRANSWARRANTYREPORTS\AGM\" + year + "\\";
                Urlpath = AgmAndEgm_PATH;
            }
            else if (type == "unclaimeddividend")
            {
                Urlpath = UNCLAIM_PATH;
            }
            else if (type == "newspaperadvertisment")
            {
                string ADVERTISMENT_PATH = @"C:\TRANSWARRANTYREPORTS\Advertisment\" + year + "\\";
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
            else if (type == "shareholder")
            {
                if (subOption == "boardmeeting")
                {
                    string SHABoardMeeting_PATH = @"C:\TRANSWARRANTYREPORTS\ShareHolder\BoardMeeting\" + year + "\\";
                    Urlpath = SHABoardMeeting_PATH;
                }
            }

            string path = Urlpath + reportId;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", reportId);
        }
    }
}