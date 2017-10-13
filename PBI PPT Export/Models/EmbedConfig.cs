using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBI_PPT_Export.Models
{
    public class PPTExportConfig
    {
        public PPTExportConfig()
        {
            ErrorMessage = "";
        }
        public string Id { get; set; }

        public string EmbedUrl { get; set; }
        public string PBIReportName { get; set; }
        
        public string ErrorMessage { get; internal set; }
    }

}