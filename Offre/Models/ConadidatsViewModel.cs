using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Offre.Models
{
    public class ConadidatsViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string UploadFile { get; set; }
        public DateTime ApplyDate { get; set; }
    }
}