using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFTransaction.Modele
{
    public class Employe
    {
        public int EmployeId { get; set; }
        public string Name { get; set; }
        public ICollection<UserTask> UserTasks { get; set; }
    }
}
