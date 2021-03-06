﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjSmartDia
{
    public partial class wfDiagnosis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sScript = "";
            //int iTalepID = 3;
            //clsKernel.Process(iTalepID);

            //string sURL = "~/wfDiagnosisResult.aspx?TalepKodu=" + iTalepID.ToString();
            //Response.Redirect(sURL);
            if (!IsPostBack)
            {
                if (Request["NoResults"] != null)
                {
                    sScript = "<script type=\"text/javascript\">";
                    sScript = sScript + " alert('Girilen bilgilere göre bir teşhis yapılamamıştır." +
                            " Lütfen bilgileri detaylı şekilde girdiginizden emin olunuz.');";
                    sScript = sScript + "</script>";
                    Page.RegisterClientScriptBlock("alertnoresult", sScript);
                }
            }
        }

        protected void btnTespit_Click(object sender, EventArgs e)
        {
            clsDB DB = new clsDB();
            int iTalepID = 0;
            string sURL = "";
            string sAdi, sSoyadi, sEmail, sAciklama;

            sAdi = txtAdi.Text;
            sSoyadi = txtSoyadi.Text;
            sEmail = txtEmail.Text;
            sAciklama = txtAciklama.Text;

            iTalepID = DB.SaveTalep(sAdi, sSoyadi, sEmail, sAciklama);

            clsKernel.Process(iTalepID);

            sURL = "~/wfDiagnosisResult.aspx?TalepKodu=" + iTalepID.ToString();
            Response.Redirect(sURL);
        }
    }
}