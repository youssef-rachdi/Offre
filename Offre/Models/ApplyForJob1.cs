using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace Offre.Models
{
    public class ApplyForJob1
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string UploadFile { get; set; }
        public DateTime ApplyDate { get; set; }
        public int Jobid { get; set; }
        public string Userid { get; set; }
        public virtual Job Job { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

}