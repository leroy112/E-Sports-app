using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace Middletier
{
    public class Price
    {
        #region Fields

        public PriceEntity Entity
        {
            get
            {
                PriceEntity entity = new PriceEntity();

                Entity.ID = this.ID;
                Entity.TournamentID = TournamentID;
                Entity.Pricestring = Pricestring;
                return entity;
            }
            set
            {
                this.ID = value.ID;
                this.TournamentID = value.TournamentID;
                this.Pricestring = value.Pricestring;
            }
        }

        public int ID;
        public int TournamentID;
        public string Pricestring;

        #endregion

        #region Constructor

        public Price(int ID, int TournamentID, string price)
        {
            this.ID = ID;
            this.TournamentID = TournamentID;
            this.Pricestring = price;
        }

        public Price(PriceEntity entity)
        {
            this.Entity = entity;
        }

        public Price()
        {

        }

        #endregion  
    }
}
