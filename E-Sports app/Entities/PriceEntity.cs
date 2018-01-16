using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PriceEntity
    {
        #region Fields

        public int ID { get; set; }
        public int TournamentID { get; set; }
        public string Pricestring { get; set; }

        #endregion
    }
}
