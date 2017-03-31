using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQWeb
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void FindSelectedButton_Click(object sender, EventArgs e)
        {
            //Old way
            var oldResult = new List<string>();
            foreach (ListItem item in cblItems.Items)
            {
                if (item.Selected)
                    oldResult.Add(item.Value);
            }

            var newResult = (from ListItem item in cblItems.Items 
                             where item.Selected 
                             select item.Value).ToList();
            litResults.Text = string.Join(", ", newResult);
        }
    }
}