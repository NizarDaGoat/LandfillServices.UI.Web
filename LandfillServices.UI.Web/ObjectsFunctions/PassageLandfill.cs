using LandfillServices.UI.Web.SQL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    /// <summary>
    /// PassageLandfill : to manage the transition of customers to landfill
    /// </summary>
    public class PassageLandfill  
    {
        private LandfillServices.UI.Web.SQL.PassageLandfill m_SqlPassageLandfill;
        private LandfillUser m_LandfillUser;
        public int ID
        {
            get
            {
                return m_SqlPassageLandfill.ID;
            }
        }
        public int UserID
        {
            get
            {
                return m_SqlPassageLandfill.UserID;
            }
            set
            {
                m_SqlPassageLandfill.UserID = value;
            }
        }

        public LandfillUser LandfillUser
        {
            get
            {
                if (m_LandfillUser == null)
                    m_LandfillUser = ControllerFunctions.LandfilluserController.SearchByID(this.UserID);

                return m_LandfillUser;
            }
        }
        public DateTime Created
        {
            get
            {
                return m_SqlPassageLandfill.Created;
            }
        }
        public DateTime Updated
        {
            get
            {
                return m_SqlPassageLandfill.Updated;
            }
        }

        /// <summary>
        /// the date of customers' transition to landfill
        /// </summary>
        public DateTime DateOfPassage 
        {
            get
            {
                return m_SqlPassageLandfill.DateOfPassage;
            }
            set
            {
                 m_SqlPassageLandfill.DateOfPassage=value;
            }
        }
        public string DateOfPassageFormatted
        {
            get
            {
                return m_SqlPassageLandfill.DateOfPassage.ToShortDateString();
            }
             
        }

        /// <summary>
        /// Pay : returns a value if it is a paid passage or not
        /// </summary>
        public int Pay
        {
            get
            {
                return m_SqlPassageLandfill.Pay;
            }
            set
            {
                 m_SqlPassageLandfill.Pay= value;
            }
        }

        public string PayDisplay
        {
            get
            {
                if (this.Pay == 1)
                    return "Yes";
                else return "No";
            }
            
        }
        public string CompanyCoperateName
        {
            get
            {
                return this.LandfillUser.CompanyCoperateName;
            }
            

        }
        public string FirstLastName
        {
            get
            {
                return this.LandfillUser.FirstLastName;
            }


        }
        internal LandfillServices.UI.Web.SQL.PassageLandfill d_PassageLandfill
        {
            get
            {
                return m_SqlPassageLandfill;
            }

        }
        internal PassageLandfill(LandfillServices.UI.Web.SQL.PassageLandfill sqlPassageLandfill)
        {
            m_SqlPassageLandfill = sqlPassageLandfill;
        }

        public PassageLandfill()
        {
            m_SqlPassageLandfill = new SQL.PassageLandfill();
            m_SqlPassageLandfill.Created = DateTime.Now;
            m_SqlPassageLandfill.Updated = DateTime.Now;
        }


    } 

} 