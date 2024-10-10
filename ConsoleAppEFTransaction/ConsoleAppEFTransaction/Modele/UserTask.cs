using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFTransaction.Modele
{
    public class UserTask
    {
        public int UserTaskId { get; set; }
        public string Description { get; set; }
        public int EmployeId { get; set; }
        public Employe Employe { get; set; }
    }
}
