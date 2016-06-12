using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Quizy
{
    public partial class Tworzenie_zestawu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") + "//Pytania.dat"))
            {
                StreamReader Pyt = new StreamReader(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") + "//Pytania.dat");
                if (Pytania.Items.Count == 0)
                {
                    string pytanie;
                    while ((pytanie = Pyt.ReadLine()) != null)
                    {
                        Pytania.Items.Add(pytanie);
                        for (int i = 0; i < 5; i++)
                        {
                            Pyt.ReadLine();
                        }
                    }
                }
                Pyt.Close();
            }
            else
            {
                Response.Redirect("default.aspx?info=3");
            }
        }

        protected void Potwierdz_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Pytania.Items.Count; i++)
            {
                if (Pytania.Items[i].Selected)
                {
                    Pytblad.Text = "";
                    break;
                }
                if (i == Pytania.Items.Count - 1)
                {
                    Pytblad.Text = "Trzeba zaznaczyć przynajmniej jedno pytanie!";
                    return;
                }
            }
            if (Nick.Text == "" || Zestaw.Text == "")
            {
                if(Nick.Text == "")
                    Nickblad.Text = "Pole nie może być puste!";
                else
                    Nickblad.Text="";
                if (Zestaw.Text == "")
                    Zestawblad.Text = "Pole nie może być puste!";
                else
                    Zestawblad.Text = "";
                return;
            }            
            StreamWriter Zes = new StreamWriter(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") + "//Zestawy.dat", true);
            string nazwa = Zestaw.Text + " stworzony przez " + Nick.Text + "(" + this.Request.UserHostAddress + ")";
            Zes.WriteLine(nazwa);
             for (int i = 0; i < Pytania.Items.Count; i++)
            {
                if (Pytania.Items[i].Selected)
                    Zes.WriteLine(i);
            }
             Zes.WriteLine("");
             Zes.Close();
             Response.Redirect("default.aspx?info=6");
        }

        protected void Cofnij_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}