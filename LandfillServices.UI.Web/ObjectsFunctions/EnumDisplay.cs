using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
   

    /// <summary>
    /// Enum disply for formatted text value of type or status ....
    /// </summary>
    public class EnumDisplay
    {
        #region private attributes

        private LandfillServices.UI.Web.SQL.EnumDisplay m_DalEnumDisplay;

        #endregion //private attributes

        #region public properties

        public int ID
        {
            get
            {
                return m_DalEnumDisplay.ID;
            }
        }

        public string Type
        {
            get { return m_DalEnumDisplay.Type; }
            set { m_DalEnumDisplay.Type = value; }
        }

        public string Display
        {
            get { return m_DalEnumDisplay.Display; }
            set { m_DalEnumDisplay.Display = value; }
        }

        public int Key
        {
            get { return m_DalEnumDisplay.Key; }
            set { m_DalEnumDisplay.Key = value; }
        }

       
        public DateTime Created
        {
            get
            {
                return m_DalEnumDisplay.Created;
            }
        }

        public DateTime Updated
        {
            get
            {
                return m_DalEnumDisplay.Updated;
            }
        }

        #endregion //public properties

        #region internal property
        internal LandfillServices.UI.Web.SQL.EnumDisplay DalEnumDisplay
        {
            get
            {
                return m_DalEnumDisplay;
            }
        }

        #endregion

        #region Constructors

        public EnumDisplay()
        {

            m_DalEnumDisplay = new SQL.EnumDisplay();
            m_DalEnumDisplay.Created = DateTime.Now;
            m_DalEnumDisplay.Updated = DateTime.Now;
             
        }

        internal EnumDisplay(LandfillServices.UI.Web.SQL.EnumDisplay dalEnumDisplay)
        {
            m_DalEnumDisplay = dalEnumDisplay;
        }

        #endregion //Constructors

        #region public methods
       
        #endregion //Constructors
    }
}