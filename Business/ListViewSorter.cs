using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace GTI.Modules.SystemSettings.Business
{
    public class ListViewSorter : System.Collections.IComparer
    {
        int Column = 0;
        int LastColumn = 0;

        public int Compare(object o1, object o2)
        {
            if (!(o1 is ListViewItem))
                return (0);
            if (!(o2 is ListViewItem))
                return (0);

            ListViewItem lvi1 = (ListViewItem)o2;
            string str1 = lvi1.SubItems[ByColumn].Text;
            ListViewItem lvi2 = (ListViewItem)o1;
            string str2 = lvi2.SubItems[ByColumn].Text;

            int result;
            if (lvi1.ListView.Sorting == SortOrder.Ascending)
                result = String.Compare(str1, str2);
            else
                result = String.Compare(str2, str1);

            LastSort = ByColumn;

            return (result);
        }


        public int ByColumn
        {
            get { return Column; }
            set { Column = value; }
        }
        
        public int LastSort
        {
            get { return LastColumn; }
            set { LastColumn = value; }
        }
        
    }//class
}//namespace
