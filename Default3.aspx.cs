using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;

public partial class Default3 :  System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GoogleConnect.ClientId = "605906953047-gl1ecetvsg7j7itf3tdmjjktsl1ed1e3.apps.googleusercontent.com";
        GoogleConnect.ClientSecret = "3GfcKUYKDuyHSwMhxalWpjfV";
        GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];

        if (!string.IsNullOrEmpty(Request.QueryString["code"]))
        {
            string code = Request.QueryString["code"];
            string json = GoogleConnect.Fetch("me", code);
            GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json);
            

         
        }
        if (Request.QueryString["error"] == "access_denied")
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Access denied.')", true);
        }

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        GoogleConnect.Authorize("profile", "email");

    }
    public class GoogleProfile
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public Image Image { get; set; }
        public List<Email> Emails { get; set; }

    }

    public class Email
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
    }

}