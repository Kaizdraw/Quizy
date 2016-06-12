using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Quizy
{
    public partial class Quiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!string.IsNullOrEmpty(Request.QueryString["num"]))
            {                
                string wyn;
                try
                {
                    wyn = Request.Cookies["Wynik"].Value;
                }
                catch (NullReferenceException)
                {
                    wyn = string.Empty;
                }
                if (!string.IsNullOrEmpty(wyn))
                {
                    Wynik.Text = wyn;
                }
                int numer = System.Convert.ToInt16(Request.QueryString["num"]);
                if (numer != System.Convert.ToInt16(NrPytania.Text))
                {
                    if (File.Exists(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") + "//Pytania.dat"))
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["zes"]))
                        {
                            int zestaw = System.Convert.ToInt16(Request.QueryString["zes"]);
                            int pomoc = 1;
                            StreamReader Zes = new StreamReader(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") + "//Zestawy.dat");                            
                            while (pomoc != zestaw)
                            {
                                Zes.ReadLine();
                                while (Zes.ReadLine() != "") ;
                                pomoc++;
                            }
                            Zes.ReadLine();
                            for (int i = 0; i < numer-1; i++)
                            {
                                Zes.ReadLine();
                            }
                            string pomoc2 = Zes.ReadLine();
                            if (pomoc2=="")
                            {
                                numer--;
                                Response.Cookies["Max"].Value = numer.ToString();
                                Response.Cookies["Max"].Expires = DateTime.Now.AddMinutes(10);
                                Response.Redirect("default.aspx?info=2");
                            }
                            numer = System.Convert.ToInt16(pomoc2)+1;
                            Zes.Close();
                        }
                        StreamReader Pyt = new StreamReader(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") + "//Pytania.dat");
                        for (int i = 0; i < 6 * (numer - 1); i++)
                        {
                            Pyt.ReadLine();
                        }
                        if ((Pytanie.Text = Pyt.ReadLine()) == null)
                        {
                            numer--;
                            Response.Cookies["Max"].Value = numer.ToString();
                            Response.Cookies["Max"].Expires = DateTime.Now.AddMinutes(10);
                            Response.Redirect("default.aspx?info=2");
                        }
                        string[] odp = new string[4];
                        for (int i = 0; i < 4; i++)
                        {
                            odp[i] = Pyt.ReadLine();
                        }
                        Nick.Text = Pyt.ReadLine();
                        Pyt.Close();
                        string prawidlowa_odp = odp[0];
                        Random ran = new Random();
                        string swap;
                        int n = ran.Next(0, 4);
                        int o = ran.Next(0, 4);
                        for (int i = 0; i < 4; i++)
                        {
                            swap = odp[n];
                            odp[n] = odp[o];
                            odp[o] = swap;
                            n = ran.Next(0, 4);
                            o = ran.Next(0, 4);
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            Odpowiedzi.Items[i].Text = odp[i];
                        }
                        NrPytania.Text = Request.QueryString["num"];                        
                    }
                    else
                    {
                        Response.Redirect("default.aspx?info=3");
                    }
                }
            }
            else
            {
                Response.Redirect("default.aspx?info=4");
            }
        }

        protected void Potwierdz_Click(object sender, EventArgs e)
        {
            int numer = System.Convert.ToInt16(NrPytania.Text);
            int dobre = 0;
            string prawidlowa_odp = "";
            if (!string.IsNullOrEmpty(Request.QueryString["zes"]))
            {
                int zestaw = System.Convert.ToInt16(Request.QueryString["zes"]);
                int pomoc = 1;
                StreamReader Zes = new StreamReader(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") + "//Zestawy.dat");
                while (pomoc != zestaw)
                {
                    Zes.ReadLine();
                    while (Zes.ReadLine() != "") ;
                    pomoc++;
                }
                Zes.ReadLine();
                for (int i = 0; i < numer - 1; i++)
                {
                    Zes.ReadLine();
                }                
                numer = System.Convert.ToInt16(Zes.ReadLine())+1;
                Zes.Close();
            }
            try
            {
                StreamReader Pyt = new StreamReader(Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data") + "//Pytania.dat");
                for (int i = 0; i < 6 * (numer-1); i++)
                {
                    Pyt.ReadLine();
                }
                Pyt.ReadLine();                
                dobre = System.Convert.ToInt16(Wynik.Text);
                prawidlowa_odp = Pyt.ReadLine();
                Pyt.Close();
            }
            catch
            {
                Response.Redirect("default.aspx?info=5");
            }
            try
            {
                if (Odpowiedzi.SelectedItem.Text == prawidlowa_odp)
                {
                    dobre++;
                }
            }
            catch
            {
                Zaznblad.Text = "Proszę zaznaczyć odpowiedź";
                return;
            }
                Response.Cookies["Wynik"].Value = dobre.ToString();
                Response.Cookies["Wynik"].Expires = DateTime.Now.AddMinutes(10);            
                for (int i = 0; i < 4; i++)
                {
                    Odpowiedzi.Items[i].Selected = false;
                }
                if (!string.IsNullOrEmpty(Request.QueryString["zes"]))
                    Response.Redirect("Quiz.aspx?zes=" + Request.QueryString["zes"] + "&num=" + (System.Convert.ToInt16(Request.QueryString["num"]) + 1).ToString());
                Response.Redirect("Quiz.aspx?num="+(numer+1).ToString());          
        }
    }
}