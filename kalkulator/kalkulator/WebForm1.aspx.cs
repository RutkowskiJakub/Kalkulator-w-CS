using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kalkulator
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        HttpCookie DzialanieInfo = new HttpCookie("DzialanieInfo");
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["x"] != null && Session["y"] != null && Session["dzialanie"] != null)
            {
                TextBoxWartosc1.Text = (Session["x"]).ToString();
                TextBoxWartosc2.Text = (Session["y"]).ToString();
                string operacja = (Session["dzialanie"]).ToString();
                switch (operacja)
                {
                    case "+":
                        DropDownListDzialanie.DataValueField = "+";
                        DropDownListDzialanie.DataTextField = "+";
                        DropDownListDzialanie.DataBind();
                        DropDownListDzialanie.SelectedValue = "+";
                        break;
                    case "-":
                        DropDownListDzialanie.DataValueField = "-";
                        DropDownListDzialanie.DataTextField = "-";
                        DropDownListDzialanie.DataBind();
                        DropDownListDzialanie.SelectedValue = "-";
                        break;
                    case "*":
                        DropDownListDzialanie.DataValueField = "*";
                        DropDownListDzialanie.DataTextField = "*";
                        DropDownListDzialanie.DataBind();
                        DropDownListDzialanie.SelectedValue = "*";
                        break;
                    case "/":
                        DropDownListDzialanie.DataValueField = "/";
                        DropDownListDzialanie.DataTextField = "/";
                        DropDownListDzialanie.DataBind();
                        DropDownListDzialanie.SelectedValue = "/";
                        break;
                }
            }
            else if (Request.Cookies["DzialanieInfo"] != null)
            {
                //    TextBoxWynik.Text = "TEST COOKIES";
                HttpCookie cookie = Request.Cookies["DzialanieInfo"];
                TextBoxWartosc1.Text = cookie["a"];
                TextBoxWartosc2.Text = cookie["b"];
                //DropDownListDzialanie.SelectedValue = cookie["operacja"];
                DropDownListDzialanie.DataValueField = cookie["Dzialanie"];
                DropDownListDzialanie.DataTextField = cookie["Dzialanie"];
                DropDownListDzialanie.DataBind();
                DropDownListDzialanie.SelectedValue = cookie["Dzialanie"];
                TextBoxWynik.Text = cookie["c"];
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(TextBoxWartosc1.Text);
                double b = double.Parse(TextBoxWartosc2.Text);
                double c = 0;
                String operacja = DropDownListDzialanie.SelectedItem.ToString();
                String dzieleniePrzezZero = "Nie można dzielić przez 0";


                switch (operacja)
                {
                    case "+":
                        c = a + b;
                        break;
                    case "-":
                        c = a - b;
                        break;
                    case "*":
                        c = a * b;
                        break;
                    case "/":
                        if (b != 0)
                        {
                            c = a / b;
                        }

                        break;
                }

                if (operacja == "/" && b == 0)
                {
                    TextBoxWynik.Text = dzieleniePrzezZero;
                }
                else
                {
                    TextBoxWynik.Text = c.ToString();
                }

                HttpCookie cookie = new HttpCookie("DzialanieInfo");
                cookie["a"] = a.ToString();
                cookie["b"] = b.ToString();
                cookie["Dzialanie"] = operacja;
                cookie["c"] = c.ToString();
                DateTime Teraz = DateTime.Now;
                cookie.Expires = Teraz + new TimeSpan(0, 0, 30, 0);
                Response.Cookies.Add(cookie);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //throw;
            }
        }

        protected void TextBoxWartosc1_TextChanged(object sender, EventArgs e)
        {
            Session["x"] = TextBoxWartosc1.Text;
        }

        protected void TextBoxWartosc2_TextChanged(object sender, EventArgs e)
        {
            Session["y"] = TextBoxWartosc2.Text;
        }

        protected void DropDownListDzialanie_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Dzialanie"] = DropDownListDzialanie.SelectedItem.ToString();
        }
        protected void TextBoxWynik_TextChanged(object sender, EventArgs e)
        {
            Session["wynik"] = TextBoxWynik.Text;
 
        }


    }
}