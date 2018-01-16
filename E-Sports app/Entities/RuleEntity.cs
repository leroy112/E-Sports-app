using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RuleEntity
    {
        public int ID { get; set; }
        public int TournamentID { get; set; }
        public string Rulestring { get; set; }
    }
}
