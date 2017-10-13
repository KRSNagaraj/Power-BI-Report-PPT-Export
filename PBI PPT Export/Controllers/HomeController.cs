using PBI_PPT_Export.Helper;
using PBI_PPT_Export.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace PBI_PPT_Export.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new PPTExportConfig() { PBIReportName = "Report Usage Metrics Report" });
        }
        [HttpPost]
        public async Task<ActionResult> Index(PPTExportConfig config)
        {
            try
            {
                if (config.PBIReportName == null || config.PBIReportName.Trim() == "")
                {
                    return View(new PPTExportConfig()
                    {
                        ErrorMessage = "Report Name can not be blank"
                    });
                }
                else
                {
                    var _name = config.PBIReportName.Trim();

                    var _PBIObjects = PBIHelper.getPBIObjects();

                    var report = _PBIObjects.Where(x => x.displayName.Replace('"', ' ').Trim() == _name).FirstOrDefault();
                    string _fileName = PBIHelper.ExportToPPT(report);
                    string contentType = "application/txt";
                    return File(_fileName, contentType, config.PBIReportName + ".pptx");
                }
            }
            catch(Exception ex)
            {
                return View(new PPTExportConfig()
                {
                    ErrorMessage = ex.Message
                });
            }
            
        }

    }

}