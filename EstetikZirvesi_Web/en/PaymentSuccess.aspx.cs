using Microsoft.AspNet.FriendlyUrls;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using VeritabaniIslemMerkezi;

namespace EstetikZirvesi_Web.en
{
    public partial class PaymentSuccess : Page
    {
        IList<string> segment;

        StringBuilder Parametreler = new StringBuilder();
        SurecVeriModel<OdemeTablosuModel> SDataModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                segment = Request.GetFriendlyUrlSegments();

                IEnumerator formValues = Request.Form.GetEnumerator();
                while (formValues.MoveNext())
                {
                    Parametreler.Append(formValues.Current.ToString()).Append(" : ").Append(Request.Form.Get(formValues.Current.ToString())).Append(" ///// ");
                }
                File.WriteAllText(Server.MapPath($"~/Dosyalar/PaymentLog/OK/{segment.First()}_{DateTime.Now:yyyy.MM.dd HH.mm.ss}.log"), Parametreler.ToString().Replace(" ///// ", "\r\n"));

                if (segment.Count.Equals(1))
                {
                    SDataModel = new OdemeTablosuIslemler().KayitBilgisi(segment.First(), "en");
                    if (SDataModel.Sonuc.Equals(Sonuclar.Basarili) /* && Banka Kontrol� */)
                    {
                        SDataModel.Veriler.Durum = true;
                        SDataModel.Veriler.OdemeParametreleri = Parametreler.ToString();
                        SDataModel.Veriler.OdemeTarihi = new BilgiKontrolMerkezi().Simdi();

                        new OdemeTablosuIslemler().OdemeDurumGuncelle(SDataModel.Veriler);
                        new MailGonderimIslemleri().KayitBilgilendirme(SDataModel.Veriler);
                        Response.Redirect($"~/en/RegistrationSuccess/{SDataModel.Veriler.OdemeID}");
                    }
                    else
                    {
                        Response.Redirect("~/en");
                    }
                }
                else
                {
                    Response.Redirect("~/en");
                }
            }
        }
    }
}