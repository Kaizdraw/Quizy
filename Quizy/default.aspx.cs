using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Quizy
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!string.IsNullOrEmpty(Request.QueryString["info"]))
            {
                int informacja = System.Convert.ToInt16(Request.QueryString["info"]);
                switch (informacja) { 
                    case 1:
                Info.Text = "Pytanie zostało dodane";
                break;
                    case 2:
                string wyn;
                try
                {
                  wyn = Request.Cookies["Wynik"].Value;
                }
                catch(NullReferenceException)
                {
                  wyn = string.Empty;
                }
                if (!string.IsNullOrEmpty(wyn))
                {
                    string max;
                    try
                    {
                        max = Request.Cookies["Max"].Value;
                    }
                    catch (NullReferenceException)
                    {
                        max = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(max))
                    {
                        Info.Text = "Twój wynik to "+wyn+"/"+max;
                        if (System.Convert.ToInt16(wyn) > System.Convert.ToInt16(max))
                            Info.Text += ", oszuście";
                    }
                }
                        Response.Cookies["Max"].Value = "0";
                        Response.Cookies["Max"].Expires = DateTime.Now.AddMinutes(10);
                        Response.Cookies["Wynik"].Value = "0";
                Response.Cookies["Wynik"].Expires = DateTime.Now.AddMinutes(10);
                break;
                    case 3:
                Info.Text = "Nie można znaleźć pliku Pytania.dat w folderze " + Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
                break;
                    case 4:
                Info.Text = "Nie istnieje taki Quiz";
                break;
                    case 5:
                Info.Text = "Błąd krytyczny";
                break;
                    case 6:
                Info.Text = "Zestaw został stworzony";
                break;
            }
            }
            if (File.Exists(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") + "//Zestawy.dat"))
            {
                StreamReader Zes = new StreamReader(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") + "//Zestawy.dat");
                string nazwa_zestawu;
                while ((nazwa_zestawu = Zes.ReadLine()) != null)
                {
                    Lista_quizow.Items.Add(nazwa_zestawu);
                    while (Zes.ReadLine() != "") ;
                }
                Zes.Close();
            }
            else
                Info.Text += "<br />Nie można znaleźć pliku Zestawy.dat w folderze " + Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");
        }

        protected void StworzPytanie_Click(object sender, EventArgs e)
        {            
            Response.Redirect("Tworzenie_pytania.aspx");
        }

        protected void Rozpocznij_quizy_Click(object sender, EventArgs e)
        {
            Response.Cookies["Max"].Value = "0";
            Response.Cookies["Max"].Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies["Wynik"].Value = "0";
            Response.Cookies["Wynik"].Expires = DateTime.Now.AddMinutes(10);
            if (Lista_quizow.SelectedItem.Text == "Wszystkie pytania")
                Response.Redirect("Quiz.aspx?num=1");
            else
                Response.Redirect("Quiz.aspx?zes=" + Lista_quizow.SelectedIndex + "&num=1");
        }

        protected void Stworz_zestaw_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tworzenie_zestawu.aspx");
        }
    }
}