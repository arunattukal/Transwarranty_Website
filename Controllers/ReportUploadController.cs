using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Transwarranty_App.Controllers
{
    public class ReportUploadController : Controller
    {
        // GET: ReportUpload
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
        public ActionResult ReportUpload()
        {
            return View();
        }

        public string DocumentUpload(FormCollection formData)
        {
            string status = "success";

            try
            {
                string ReportID = "";
                string fileContent = formData["filecontent"].ToString();
                string reporttype = formData["ReportType"].ToString();
                string subType = formData["ShareHolding_Sub"].ToString();
                string FinType = formData["Financial_Sub"].ToString();
                string AnnType = formData["Annual_Sub"].ToString();
                string year = formData["Year"].ToString();
                string quarter = formData["Quarter"].ToString();
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                if (reporttype.Equals("stockexchange"))
                {
                    ReportID = formData["ReportType"] + "_" + unixTimestamp;
                    year = "NA";
                    quarter = "NA";

                    string EXCHANGE_PATHfilename = ReportID + ".pdf";
                    string EXCHANGE_PATHfilePath = EXCHANGE_PATH + EXCHANGE_PATHfilename;

                    byte[] bytes = Convert.FromBase64String(fileContent);

                    //check is file exists
                    if (System.IO.File.Exists(EXCHANGE_PATHfilePath))
                    {
                        System.IO.File.SetAttributes(EXCHANGE_PATHfilePath, FileAttributes.Normal);
                        System.IO.File.Delete(EXCHANGE_PATHfilePath);
                        status = "Error";
                    }
                    System.IO.FileStream stream = new FileStream(EXCHANGE_PATHfilePath, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                    new BinaryWriter(stream);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                }
                else if (formData["ReportType"].Equals("materialevents"))
                {
                    ReportID = formData["ReportType"] + "_" + unixTimestamp;
                    year = "NA";
                    quarter = "NA";

                    string materialeventsfilename = ReportID + ".pdf";
                    string materialeventsfilePath = MATERIAL_PATH + materialeventsfilename;

                    byte[] bytes = Convert.FromBase64String(fileContent);

                    //check is file exists
                    if (System.IO.File.Exists(materialeventsfilePath))
                    {
                        System.IO.File.SetAttributes(materialeventsfilePath, FileAttributes.Normal);
                        System.IO.File.Delete(materialeventsfilePath);
                        status = "Error";
                    }
                    System.IO.FileStream stream = new FileStream(materialeventsfilePath, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                    new BinaryWriter(stream);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                }
                else if (formData["ReportType"].Equals("unclaimeddividend"))
                {
                    ReportID = formData["ReportType"] + "_" + unixTimestamp;
                    year = "NA";
                    quarter = "NA";

                    string stockexchangesfilename = ReportID + ".pdf";
                    string stockexchangesfilePath = UNCLAIM_PATH + stockexchangesfilename;

                    byte[] bytes = Convert.FromBase64String(fileContent);

                    //check is file exists
                    if (System.IO.File.Exists(stockexchangesfilePath))
                    {
                        System.IO.File.SetAttributes(stockexchangesfilePath, FileAttributes.Normal);
                        System.IO.File.Delete(stockexchangesfilePath);
                        status = "Error";
                    }
                    System.IO.FileStream stream = new FileStream(stockexchangesfilePath, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                    new BinaryWriter(stream);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                }
                else if (formData["ReportType"].Equals("policies"))
                {
                    ReportID = formData["ReportType"] + "_" + unixTimestamp;
                    year = "NA";
                    quarter = "NA";

                    string stockexchangesfilename = ReportID + ".pdf";
                    string stockexchangesfilePath = POLICIES_PATH + stockexchangesfilename;

                    byte[] bytes = Convert.FromBase64String(fileContent);

                    //check is file exists
                    if (System.IO.File.Exists(stockexchangesfilePath))
                    {
                        System.IO.File.SetAttributes(stockexchangesfilePath, FileAttributes.Normal);
                        System.IO.File.Delete(stockexchangesfilePath);
                        status = "Error";
                    }
                    System.IO.FileStream stream = new FileStream(stockexchangesfilePath, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                    new BinaryWriter(stream);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                }
                else if (formData["ReportType"].Equals("grievances"))
                {
                    ReportID = formData["ReportType"] + "_" + unixTimestamp;
                    year = "NA";
                    quarter = "NA";

                    string stockexchangesfilename = ReportID + ".pdf";
                    string stockexchangesfilePath = GRIEVANCE_PATH + stockexchangesfilename;

                    byte[] bytes = Convert.FromBase64String(fileContent);

                    //check is file exists
                    if (System.IO.File.Exists(stockexchangesfilePath))
                    {
                        System.IO.File.SetAttributes(stockexchangesfilePath, FileAttributes.Normal);
                        System.IO.File.Delete(stockexchangesfilePath);
                        status = "Error";
                    }
                    System.IO.FileStream stream = new FileStream(stockexchangesfilePath, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                    new BinaryWriter(stream);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                }
                else if (formData["ReportType"].Equals("newspaperadvertisment"))
                {
                    ReportID = formData["ReportType"] + "_" + unixTimestamp;
                    year = "NA";
                    quarter = "NA";

                    string ADVERTISMENT_PATHfilename = ReportID + ".pdf";
                    string ADVERTISMENT_PATHfilePath = ADVERTISMENT_PATH + ADVERTISMENT_PATHfilename;

                    byte[] bytes = Convert.FromBase64String(fileContent);

                    //check is file exists
                    if (System.IO.File.Exists(ADVERTISMENT_PATHfilePath))
                    {
                        System.IO.File.SetAttributes(ADVERTISMENT_PATHfilePath, FileAttributes.Normal);
                        System.IO.File.Delete(ADVERTISMENT_PATHfilePath);
                        status = "Error";
                    }
                    System.IO.FileStream stream = new FileStream(ADVERTISMENT_PATHfilePath, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                    new BinaryWriter(stream);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                }
                else if (formData["ReportType"].Equals("general"))
                {
                    ReportID = formData["ReportType"] + "_" + unixTimestamp;
                    year = "NA";
                    quarter = "NA";

                    string materialeventsfilename = ReportID + ".pdf";
                    string materialeventsfilePath = AGM_PATH + materialeventsfilename;

                    byte[] bytes = Convert.FromBase64String(fileContent);

                    //check is file exists
                    if (System.IO.File.Exists(materialeventsfilePath))
                    {
                        System.IO.File.SetAttributes(materialeventsfilePath, FileAttributes.Normal);
                        System.IO.File.Delete(materialeventsfilePath);
                        status = "Error";
                    }
                    System.IO.FileStream stream = new FileStream(materialeventsfilePath, FileMode.CreateNew);
                    System.IO.BinaryWriter writer =
                    new BinaryWriter(stream);
                    writer.Write(bytes, 0, bytes.Length);
                    writer.Close();
                }
                else if (formData["ReportType"].Equals("annual"))
                {
                    string subcategory = "NA";
                    subcategory = formData["Annual_Sub"];

                    if (subcategory.Equals("annualtranswarranty"))
                    {
                        ReportID = formData["ReportType"] + "_" + subcategory + "_" + year;

                        string ANNUALTRAN_PATHfilename = ReportID + ".pdf";
                        string ANNUALTRAN_PATHfilePath = ANNUALTRAN_PATH + ANNUALTRAN_PATHfilename;

                        byte[] bytes = Convert.FromBase64String(fileContent);

                        //check is file exists
                        if (System.IO.File.Exists(ANNUALTRAN_PATHfilePath))
                        {
                            System.IO.File.SetAttributes(ANNUALTRAN_PATHfilePath, FileAttributes.Normal);
                            System.IO.File.Delete(ANNUALTRAN_PATHfilePath);
                            status = "Error";
                        }
                        System.IO.FileStream stream = new FileStream(ANNUALTRAN_PATHfilePath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                    }
                    else if (subcategory.Equals("subcompany"))
                    {
                        ReportID = formData["ReportType"] + "_" + subcategory + "_" + year;

                        string ANNUALSUB_PATHfilename = ReportID + ".pdf";
                        string ANNUALSUB_PATHfilePath = ANNUALSUB_PATH + ANNUALSUB_PATHfilename;

                        byte[] bytes = Convert.FromBase64String(fileContent);

                        //check is file exists
                        if (System.IO.File.Exists(ANNUALSUB_PATHfilePath))
                        {
                            System.IO.File.SetAttributes(ANNUALSUB_PATHfilePath, FileAttributes.Normal);
                            System.IO.File.Delete(ANNUALSUB_PATHfilePath);
                            status = "Error";
                        }
                        System.IO.FileStream stream = new FileStream(ANNUALSUB_PATHfilePath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                    }
                }
                else if (formData["ReportType"].Equals("financial"))
                {
                    string subcategory = "NA";
                    subcategory = formData["Financial_Sub"];

                    if (subcategory.Equals("financial"))
                    {
                        ReportID = formData["ReportType"] + "_" + subcategory + "_" + formData["Year"] + "_" + formData["Quarter"];
                        year = "NA";
                        quarter = "NA";

                        string FINANCIAL_PATHfilename = ReportID + ".pdf";
                        string FINANCIAL_PATHfilePath = FINANCIAL_PATH + FINANCIAL_PATHfilename;

                        byte[] bytes_1 = Convert.FromBase64String(fileContent);

                        //check is file exists
                        if (System.IO.File.Exists(FINANCIAL_PATHfilePath))
                        {
                            System.IO.File.SetAttributes(FINANCIAL_PATHfilePath, FileAttributes.Normal);
                            System.IO.File.Delete(FINANCIAL_PATHfilePath);
                            status = "Error";
                        }
                        System.IO.FileStream stream_1 = new FileStream(FINANCIAL_PATHfilePath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer_1 =
                        new BinaryWriter(stream_1);
                        writer_1.Write(bytes_1, 0, bytes_1.Length);
                        writer_1.Close();
                    }
                    else if (subcategory.Equals("annualfinancial"))
                    {
                        ReportID = formData["ReportType"] + "_" + subcategory + "_" + formData["Year"] + "_" + formData["Quarter"];

                        string FINANCIALAF_PATHfilename = ReportID + ".pdf";
                        string FINANCIALAF_PATHfilePath = FINANCIALAF_PATH + FINANCIALAF_PATHfilename;

                        byte[] bytes_2 = Convert.FromBase64String(fileContent);

                        //check is file exists
                        if (System.IO.File.Exists(FINANCIALAF_PATHfilePath))
                        {
                            System.IO.File.SetAttributes(FINANCIALAF_PATHfilePath, FileAttributes.Normal);
                            System.IO.File.Delete(FINANCIALAF_PATHfilePath);
                            status = "Error";
                        }
                        System.IO.FileStream stream_2 = new FileStream(FINANCIALAF_PATHfilePath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer_2 =
                        new BinaryWriter(stream_2);
                        writer_2.Write(bytes_2, 0, bytes_2.Length);
                        writer_2.Close();
                    }
                    else if (subcategory.Equals("quarterly"))
                    {
                        ReportID = formData["ReportType"] + "_" + subcategory + "_" + formData["Year"] + "_" + formData["Quarter"];

                        string FINANCIALQR_PATHfilename = ReportID + ".pdf";
                        string FINANCIALQR_PATHfilePath = FINANCIALQR_PATH + FINANCIALQR_PATHfilename;

                        byte[] bytes_2 = Convert.FromBase64String(fileContent);

                        //check is file exists
                        if (System.IO.File.Exists(FINANCIALQR_PATHfilePath))
                        {
                            System.IO.File.SetAttributes(FINANCIALQR_PATHfilePath, FileAttributes.Normal);
                            System.IO.File.Delete(FINANCIALQR_PATHfilePath);
                            status = "Error";
                        }
                        System.IO.FileStream stream_2 = new FileStream(FINANCIALQR_PATHfilePath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer_2 =
                        new BinaryWriter(stream_2);
                        writer_2.Write(bytes_2, 0, bytes_2.Length);
                        writer_2.Close();
                    }
                    else if (subcategory.Equals("limitedreviewrpt"))
                    {
                        ReportID = formData["ReportType"] + "_" + subcategory + "_" + formData["Year"] + "_" + formData["Quarter"];

                        string FINANCIALLRR_PATHfilename = ReportID + ".pdf";
                        string FINANCIALLRR_PATHfilePath = FINANCIALLRR_PATH + FINANCIALLRR_PATHfilename;

                        byte[] bytes_2 = Convert.FromBase64String(fileContent);

                        //check is file exists
                        if (System.IO.File.Exists(FINANCIALLRR_PATHfilePath))
                        {
                            System.IO.File.SetAttributes(FINANCIALLRR_PATHfilePath, FileAttributes.Normal);
                            System.IO.File.Delete(FINANCIALLRR_PATHfilePath);
                            status = "Error";
                        }
                        System.IO.FileStream stream_2 = new FileStream(FINANCIALLRR_PATHfilePath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer_2 =
                        new BinaryWriter(stream_2);
                        writer_2.Write(bytes_2, 0, bytes_2.Length);
                        writer_2.Close();
                    }
                    else if (subcategory.Equals("subcompany"))
                    {
                        ReportID = formData["ReportType"] + "_" + subcategory + "_" + formData["Year"] + "_" + formData["Quarter"];

                        string FINANCIALAGM_PATHfilename = ReportID + ".pdf";
                        string FINANCIALAGM_PATHfilePath = FINANCIALAGM_PATH + FINANCIALAGM_PATHfilename;

                        byte[] bytes_2 = Convert.FromBase64String(fileContent);

                        //check is file exists
                        if (System.IO.File.Exists(FINANCIALAGM_PATHfilePath))
                        {
                            System.IO.File.SetAttributes(FINANCIALAGM_PATHfilePath, FileAttributes.Normal);
                            System.IO.File.Delete(FINANCIALAGM_PATHfilePath);
                            status = "Error";
                        }
                        System.IO.FileStream stream_2 = new FileStream(FINANCIALAGM_PATHfilePath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer_2 =
                        new BinaryWriter(stream_2);
                        writer_2.Write(bytes_2, 0, bytes_2.Length);
                        writer_2.Close();
                    }
                }
                else if (formData["ReportType"].Equals("shareholder"))
                {
                    string subcategory = "NA";
                    subcategory = formData["ShareHolding_Sub"];

                    if (subcategory.Equals("investorcomplaints"))
                    {
                        ReportID = formData["ReportType"] + "_" + subcategory + "_" + formData["Year"] + "_" + formData["Quarter"];

                        string SHAREIC_PATHfilename = ReportID + ".pdf";
                        string SHAREIC_PATHfilePath = SHAREIC_PATH + SHAREIC_PATHfilename;

                        byte[] bytes_2 = Convert.FromBase64String(fileContent);

                        //check is file exists
                        if (System.IO.File.Exists(SHAREIC_PATHfilePath))
                        {
                            System.IO.File.SetAttributes(SHAREIC_PATHfilePath, FileAttributes.Normal);
                            System.IO.File.Delete(SHAREIC_PATHfilePath);
                            status = "Error";
                        }
                        System.IO.FileStream stream_2 = new FileStream(SHAREIC_PATHfilePath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer_2 =
                        new BinaryWriter(stream_2);
                        writer_2.Write(bytes_2, 0, bytes_2.Length);
                        writer_2.Close();
                    }
                    else if (subcategory.Equals("corporategovernance"))
                    {
                        ReportID = formData["ReportType"] + "_" + subcategory + "_" + formData["Year"] + "_" + formData["Quarter"];

                        string SHARE_PATHfilename = ReportID + ".pdf";
                        string SHARE_PATHfilePath = SHARECG_PATH + SHARE_PATHfilename;

                        byte[] bytes = Convert.FromBase64String(fileContent);

                        //check is file exists
                        if (System.IO.File.Exists(SHARE_PATHfilePath))
                        {
                            System.IO.File.SetAttributes(SHARE_PATHfilePath, FileAttributes.Normal);
                            System.IO.File.Delete(SHARE_PATHfilePath);
                            status = "Error";
                        }
                        System.IO.FileStream stream = new FileStream(SHARE_PATHfilePath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                    }
                    else if (subcategory.Equals("shareholdingpattern"))
                    {
                        ReportID = formData["ReportType"] + "_" + subcategory + "_" + formData["Year"] + "_" + formData["Quarter"];

                        string SHAREHOLDING_PATHfilename = ReportID + ".pdf";
                        string SHAREHOLDING_PATHfilePath = SHAREHOLDING_PATH + SHAREHOLDING_PATHfilename;

                        byte[] bytes = Convert.FromBase64String(fileContent);

                        //check is file exists
                        if (System.IO.File.Exists(SHAREHOLDING_PATHfilePath))
                        {
                            System.IO.File.SetAttributes(SHAREHOLDING_PATHfilePath, FileAttributes.Normal);
                            System.IO.File.Delete(SHAREHOLDING_PATHfilePath);
                            status = "Error";
                        }
                        System.IO.FileStream stream = new FileStream(SHAREHOLDING_PATHfilePath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                    }
                    else if (subcategory.Equals("boardmeeting"))
                    {
                        ReportID = formData["ReportType"] + "_" + subcategory + "_" + formData["Year"] + "_" + formData["Quarter"];

                        string BOARDMEETING_PATHfilename = ReportID + ".pdf";
                        string BOARDMEETING_PATHfilePath = BOARDMEETING_PATH + BOARDMEETING_PATHfilename;

                        byte[] bytes = Convert.FromBase64String(fileContent);

                        //check is file exists
                        if (System.IO.File.Exists(BOARDMEETING_PATHfilePath))
                        {
                            System.IO.File.SetAttributes(BOARDMEETING_PATHfilePath, FileAttributes.Normal);
                            System.IO.File.Delete(BOARDMEETING_PATHfilePath);
                            status = "Error";
                        }
                        System.IO.FileStream stream = new FileStream(BOARDMEETING_PATHfilePath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                status = ex.ToString();
            }
            return status;
        }
        public JsonResult uploadedReports(string type, string subOption, string Fincaty, string Annucaty)
        {

            string ReportType = type;
            string SubOption = subOption;
            string fincaty = Fincaty;
            string annucaty = Annucaty;

            List<ListItem> files = new List<ListItem>();
            if (ReportType == "financial")
            {
                if (fincaty == "financial")
                {
                    string[] filesPath = Directory.GetFiles(FINANCIAL_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (fincaty == "annualfinancial")
                {
                    string[] filesPath = Directory.GetFiles(FINANCIALAF_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (fincaty == "quarterly")
                {
                    string[] filesPath = Directory.GetFiles(FINANCIALQR_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (fincaty == "limitedreviewrpt")
                {
                    string[] filesPath = Directory.GetFiles(FINANCIALLRR_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (fincaty == "subcompany")
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
                if (annucaty == "annualtranswarranty")
                {
                    string[] filesPath = Directory.GetFiles(ANNUALTRAN_PATH);
                    foreach (string path in filesPath)
                    {
                        files.Add(new ListItem(Path.GetFileName(path)));
                    }
                }
                else if (annucaty == "subcompany")
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
            else if (ReportType == "general")
            {
                string[] filesPath = Directory.GetFiles(AGM_PATH);
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
            else if (ReportType == "newspaperadvertisment")
            {
                string[] filesPath = Directory.GetFiles(ADVERTISMENT_PATH);
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
            else if (ReportType == "grievances")
            {
                string[] filesPath = Directory.GetFiles(GRIEVANCE_PATH);
                foreach (string path in filesPath)
                {
                    files.Add(new ListItem(Path.GetFileName(path)));
                }
            }


            var result = new { data = files };
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult RemoveUploadedReports(string reportId, string type, string subOption, string Fincaty, string Annucaty)
        {
            try
            {
                string ReportType = type;
                string SubOption = subOption;
                string fincaty = Fincaty;
                string annucaty = Annucaty;
                string filePath = "";

                if (ReportType == "financial")
                {
                    if (fincaty == "financial")
                    {
                        filePath = FINANCIAL_PATH + reportId;
                    }
                    else if (fincaty == "annualfinancial")
                    {
                        filePath = FINANCIALAF_PATH + reportId;
                    }
                    else if (fincaty == "quarterly")
                    {
                        filePath = FINANCIALQR_PATH + reportId;
                    }
                    else if (fincaty == "limitedreviewrpt")
                    {
                        filePath = FINANCIALLRR_PATH + reportId;
                    }
                    else if (fincaty == "subcompany")
                    {
                        filePath = FINANCIALAGM_PATH + reportId;
                    }
                }
                else if (ReportType == "annual")
                {
                    if (annucaty == "annualtranswarranty")
                    {
                        filePath = ANNUALTRAN_PATH + reportId;
                    }
                    else if (annucaty == "subcompany")
                    {
                        filePath = ANNUALSUB_PATH + reportId;
                    }
                    
                }
                else if (ReportType == "shareholder")
                {
                    if (SubOption == "corporategovernance")
                    {
                        filePath = SHARECG_PATH + reportId;
                    }
                    else if (SubOption == "investorcomplaints")
                    {
                        filePath = SHAREIC_PATH + reportId;
                    }
                    else if (SubOption == "shareholdingpattern")
                    {
                        filePath = SHAREHOLDING_PATH + reportId;
                    }
                    else if (SubOption == "boardmeeting")
                    {
                        filePath = BOARDMEETING_PATH + reportId;
                    }
                }
                else if (ReportType == "stockexchange")
                {
                    filePath = EXCHANGE_PATH + reportId;
                }
                else if (ReportType == "materialevents")
                {
                    filePath = MATERIAL_PATH + reportId;
                }
                else if (ReportType == "general")
                {
                    filePath = AGM_PATH + reportId;
                }
                else if (ReportType == "newspaperadvertisment")
                {
                    filePath = ADVERTISMENT_PATH + reportId;
                }
                else if (ReportType == "unclaimeddividend")
                {
                    filePath = UNCLAIM_PATH + reportId;
                }
                else if (ReportType == "policies")
                {
                    filePath = POLICIES_PATH + reportId;
                }
                else if (ReportType == "grievances")
                {
                    filePath = GRIEVANCE_PATH + reportId;
                }
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                var result = new { Result = "success" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var result = new { Result = "Failed" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}