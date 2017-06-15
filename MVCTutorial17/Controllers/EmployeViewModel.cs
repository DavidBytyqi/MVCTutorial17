using MVCTutorial17.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTutorial17.Controllers
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string Address { get; set; }
        public bool isDeleted { get; set; }
        public string DepartmentName { get; set; }
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Site> Sites { get; set; }
    }
}