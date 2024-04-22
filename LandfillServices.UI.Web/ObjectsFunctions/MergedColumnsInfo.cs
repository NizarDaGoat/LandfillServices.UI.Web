using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandfillServices.UI.Web.ObjectsFunctions
{
    /// <summary>
    /// used in GridView with checkbox
    /// </summary>
    [Serializable]
    public class MergedColumnsInfo
    {
        // indexes of merged columns
        public List<int> MergedColumns = new List<int>();
        // key-value pairs: key = the first column index, value = number of the merged columns
        public Hashtable StartColumns = new Hashtable();
        // key-value pairs: key = the first column index, value = common title of the merged columns 
        public Hashtable Titles = new Hashtable();

        //parameters: the merged columns indexes, common title of the merged columns 
        public void AddMergedColumns(int[] columnsIndexes, string title)
        {
            MergedColumns.AddRange(columnsIndexes);
            StartColumns.Add(columnsIndexes[0], columnsIndexes.Length);
            Titles.Add(columnsIndexes[0], title);
        }
    }
}