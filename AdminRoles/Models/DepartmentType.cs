using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminRoles.Models
{
    public class DepartmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DivisionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentTypeId { get; set; }
       public DepartmentType DepartmentType { get; set; }
    }
}