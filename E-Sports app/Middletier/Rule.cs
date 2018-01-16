using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace Middletier
{
    public class Rule
    {
        #region Fields
        
        public RuleEntity Entity
        {
            get
            {
                RuleEntity entity = new RuleEntity();

                Entity.ID = this.ID;
                Entity.TournamentID = TournamentID;
                Entity.Rulestring = Rulestring;
                return entity;
            }
            set
            {
                this.ID = value.ID;
                this.TournamentID = value.TournamentID;
                this.Rulestring = value.Rulestring;
            }
        }

        public int ID;
        public int TournamentID;
        public string Rulestring;

        #endregion

        #region Constructor

        public Rule(int ID, int TournamentID, string rule)
        {
            this.ID = ID;
            this.TournamentID = TournamentID;
            this.Rulestring = rule;
        }

        public Rule(RuleEntity entity)
        {
            this.Entity = entity;
        }

        public Rule()
        {

        }

        #endregion

        #region Methods



        #endregion
    }
}
