using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void label_DataBound(object sender, EventArgs e)
    {
        ASPxLabel label = sender as ASPxLabel;
        label.Text = HighlightSearchText(label.Text, gridView.SearchPanelFilter);
    }


    public static string HighlightSearchText(string source, string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
            return source;
        var regex = new Regex(Regex.Escape(searchText), RegexOptions.IgnoreCase);
        if (regex.IsMatch(source))
            return string.Format("<span>{0}</span>", regex.Replace(source, "<span class='dxgvHL'>$0</span>"));
        return source;
    }
}