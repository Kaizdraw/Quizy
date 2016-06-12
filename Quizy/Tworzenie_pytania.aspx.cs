using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Quizy
{
    public partial class Tworzenie_pytania : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cofnij_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");            
        }

        protected void Zatwierz_Click(object sender, EventArgs e)
        {
            OdpPopblad.Text = "";
            OdpBl3blad.Text = "";
            OdpBl2blad.Text = "";
            OdpBl1blad.Text = "";
            Pytanieblad.Text = "";
            Nickblad.Text = "";
            if (Nick.Text == "" || Pytanie.Text == "" || OdpBl1.Text == "" || OdpBl2.Text == "" || OdpBl3.Text == "" || OdpPop.Text == "")
            {
                if (Nick.Text == "")
                    Nickblad.Text = "Pole nie może być puste!";               
                if (Pytanie.Text == "")
                    Pytanieblad.Text = "Pole nie może być puste!";               
                if (OdpBl1.Text == "")
                    OdpBl1blad.Text = "Pole nie może być puste!";               
                if (OdpBl2.Text == "")
                    OdpBl2blad.Text = "Pole nie może być puste!";                
                if (OdpBl3.Text == "")
                    OdpBl3blad.Text = "Pole nie może być puste!";               
                if (OdpPop.Text == "")
                    OdpPopblad.Text = "Pole nie może być puste!";               
                return;
            }
            if (OdpPop.Text == OdpBl1.Text || OdpPop.Text == OdpBl2.Text || OdpPop.Text == OdpBl3.Text)
            {
                OdpPopblad.Text = "Nie może być dwóch takich samych odpowiedzi!";
                return;
            }
            if (OdpBl1.Text == OdpBl2.Text || OdpBl1.Text == OdpBl3.Text)
            {
                OdpBl1blad.Text = "Nie może być dwóch takich samych odpowiedzi!";
                return;
            }
            if (OdpBl2.Text == OdpBl3.Text)
            {
                OdpBl2blad.Text = "Nie może być dwóch takich samych odpowiedzi!";
                return;
            }
            string pytanie = Pytanie.Text.Trim().Replace("\n", "<br />");
            string nick = "<i>" + Nick.Text + "</i>(" + this.Request.UserHostAddress + ")";
            try
            {
                StreamWriter Pyt = new StreamWriter(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") + "//Pytania.dat", true);
                Pyt.WriteLine(pytanie);
                Pyt.WriteLine(OdpPop.Text);
                Pyt.WriteLine(OdpBl1.Text);
                Pyt.WriteLine(OdpBl2.Text);
                Pyt.WriteLine(OdpBl3.Text);
                Pyt.WriteLine(nick);
                Pyt.Close();
            }
            catch
            {
                Response.Redirect("default.aspx?info=5");
            }
            Response.Redirect("default.aspx?info=1");
        }
    }
}