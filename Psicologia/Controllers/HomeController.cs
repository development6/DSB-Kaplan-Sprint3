using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Psicologia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




        [HttpPost]
        public ContentResult AjaxMethod(string paciente)
        {
            string query = "select Replace(Ficha_Psicologia.sf_funcion_ing, ',', '.'), Replace(Ficha_Psicologia.sf_rol_ing, ',', '.'),Replace(Ficha_Psicologia.sf_dolor_ing, ',', '.'),Replace(Ficha_Psicologia.sf_salud_ing, ',', '.'),Replace(Ficha_Psicologia.sf_funcion_egr, ',', '.'),Replace(Ficha_Psicologia.sf_rol_egr, ',', '.'),Replace(Ficha_Psicologia.sf_dolor_egr, ',', '.'), Replace(Ficha_Psicologia.sf_salud_egr, ',', '.'), COUNT(Ficha_Psicologia.id_ficha_psico)";
            query += "from Ficha INNER JOIN  Ficha_Psicologia ON Ficha_Psicologia.id_ficha=Ficha.id_ficha inner join Paciente on Paciente.id_paciente = Ficha.id_paciente where Paciente.id_paciente = @pacienteID GROUP BY Ficha_Psicologia.sf_funcion_ing, Ficha_Psicologia.sf_rol_ing, Ficha_Psicologia.sf_dolor_ing,Ficha_Psicologia.sf_salud_ing, Ficha_Psicologia.sf_funcion_egr,Ficha_Psicologia.sf_rol_egr,Ficha_Psicologia.sf_dolor_egr,Ficha_Psicologia.sf_salud_egr";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@pacienteID", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1},value2:{2},value3:{3},value4:{4},value5:{5},value6:{6},value7:{7}", sdr[0], sdr[1], sdr[2], sdr[3], sdr[4], sdr[5], sdr[6], sdr[7]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }



        [HttpPost]
        public ContentResult AjaxMethod2(string paciente)
        {
            string query = "select Replace(Ficha_Psicologia.sf_vital_ing, ',', '.'), Replace(Ficha_Psicologia.sf_funcionsoc_ing, ',', '.'),Replace(Ficha_Psicologia.sf_rolemo_ing, ',', '.'),Replace(Ficha_Psicologia.sf_saludmen_ing, ',', '.'),Replace(Ficha_Psicologia.sf_vital_egr, ',', '.'),Replace(Ficha_Psicologia.sf_funcionsoc_egr, ',', '.'),Replace(Ficha_Psicologia.sf_rolemo_egr, ',', '.'), Replace(Ficha_Psicologia.sf_saludmen_egr, ',', '.'), COUNT(Ficha_Psicologia.id_ficha_psico)";
            query += "from Ficha INNER JOIN  Ficha_Psicologia ON Ficha_Psicologia.id_ficha=Ficha.id_ficha inner join Paciente on Paciente.id_paciente = Ficha.id_paciente where Paciente.id_paciente = @pacienteID GROUP BY Ficha_Psicologia.sf_vital_ing, Ficha_Psicologia.sf_funcionsoc_ing, Ficha_Psicologia.sf_rolemo_ing,Ficha_Psicologia.sf_saludmen_ing, Ficha_Psicologia.sf_vital_egr,Ficha_Psicologia.sf_funcionsoc_egr,Ficha_Psicologia.sf_rolemo_egr,Ficha_Psicologia.sf_saludmen_egr";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@pacienteID", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1},value2:{2},value3:{3},value4:{4},value5:{5},value6:{6},value7:{7}", sdr[0], sdr[1], sdr[2], sdr[3], sdr[4], sdr[5], sdr[6], sdr[7]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }


        [HttpPost]
        public ContentResult AjaxMethod3(string paciente)
        {
            string query = "select Replace(Ficha_Psicologia.had_ansie_ing, ',', '.'), Replace(Ficha_Psicologia.had_depre_ing, ',', '.'), Replace(Ficha_Psicologia.had_suba_ing, ',', '.'),Replace(Ficha_Psicologia.had_subd_ing, ',', '.') , Replace(Ficha_Psicologia.had_ansie_egr, ',', '.'), Replace(Ficha_Psicologia.had_depre_egr, ',', '.'), Replace(Ficha_Psicologia.had_suba_egr, ',', '.'), Replace(Ficha_Psicologia.had_subd_egr, ',', '.'), COUNT(Ficha_Psicologia.id_ficha_psico)";
            query += "from Ficha INNER JOIN  Ficha_Psicologia ON Ficha_Psicologia.id_ficha=Ficha.id_ficha inner join Paciente on Paciente.id_paciente = Ficha.id_paciente where Paciente.id_paciente = @pacienteID GROUP BY Ficha_Psicologia.had_ansie_ing, Ficha_Psicologia.had_depre_ing, Ficha_Psicologia.had_suba_ing, Ficha_Psicologia.had_subd_ing,Ficha_Psicologia.had_ansie_egr,Ficha_Psicologia.had_depre_egr, Ficha_Psicologia.had_suba_egr, Ficha_Psicologia.had_subd_egr";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@pacienteID", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1},value2:{2},value3:{3},value4:{4},value5:{5},value6:{6},value7:{7}", sdr[0], sdr[1], sdr[2], sdr[3], sdr[4], sdr[5], sdr[6], sdr[7]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }


        [HttpPost]
        public ContentResult AjaxMethod4()
        {
            string query = "select Replace(AVG(Ficha_Psicologia.sf_funcion_ing), ',', '.'), Replace(AVG(Ficha_Psicologia.sf_rol_ing), ',', '.'), Replace(AVG(Ficha_Psicologia.sf_dolor_ing), ',', '.'), Replace(AVG(Ficha_Psicologia.sf_salud_ing), ',', '.'),Replace(AVG(Ficha_Psicologia.sf_vital_ing), ',', '.'),Replace(AVG(Ficha_Psicologia.sf_funcionsoc_ing), ',', '.'),Replace(AVG(Ficha_Psicologia.sf_rolemo_ing), ',', '.'),Replace(AVG(Ficha_Psicologia.sf_saludmen_ing), ',', '.'),Replace(AVG(Ficha_Psicologia.sf_funcion_egr), ',', '.'), Replace(AVG(Ficha_Psicologia.sf_rol_egr), ',', '.'), Replace(AVG(Ficha_Psicologia.sf_dolor_egr), ',', '.'), Replace(AVG(Ficha_Psicologia.sf_salud_egr), ',', '.'),Replace(AVG(Ficha_Psicologia.sf_vital_egr), ',', '.'),Replace(AVG(Ficha_Psicologia.sf_funcionsoc_egr), ',', '.'), Replace(AVG(Ficha_Psicologia.sf_rolemo_egr), ',', '.'), Replace(AVG(Ficha_Psicologia.sf_saludmen_egr), ',', '.'), COUNT(Ficha_Psicologia.id_ficha_psico)";
            query += "from Ficha_Psicologia";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    //cmd.Parameters.AddWithValue("@pacienteID", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1},value2:{2},value3:{3},value4:{4},value5:{5},value6:{6},value7:{7},value8:{8},value9:{9},value10:{10},value11:{11},value12:{12},value13:{13},value14:{14},value15:{15},value16:{16}", sdr[0], sdr[1], sdr[2], sdr[3], sdr[4], sdr[5], sdr[6], sdr[7], sdr[8], sdr[9], sdr[10], sdr[11], sdr[12], sdr[13], sdr[14], sdr[15], sdr[16]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }


    }
}