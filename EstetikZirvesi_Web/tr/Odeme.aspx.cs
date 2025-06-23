using Microsoft.AspNet.FriendlyUrls;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using VeritabaniIslemMerkezi;

namespace EstetikZirvesi_Web.tr
{
    public partial class Odeme : Page
    {
        IList<string> segments;

        StringBuilder Uyarilar = new StringBuilder();
        BilgiKontrolMerkezi Kontrol = new BilgiKontrolMerkezi();

        SurecVeriModel<OdemeTablosuModel> SDataModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                segments = Request.GetFriendlyUrlSegments();

                if (segments.Count.Equals(1))
                {
                    SDataModel = new OdemeTablosuIslemler().KayitBilgisi(segments.First(), "tr");

                    if (SDataModel.Sonuc.Equals(Sonuclar.Basarili) && SDataModel.Veriler.OdemeTipiID.Equals(2) && !SDataModel.Veriler.Durum && SDataModel.Veriler.OdemeTarihi is null)
                    {
                        lblAdSoyad.Text = $"{SDataModel.Veriler.KatilimciBilgisi.AdSoyad}";
                        hfePosta.Value = SDataModel.Veriler.KatilimciBilgisi.ePosta;

                        lblDovizUcret.Text = SDataModel.Veriler.DovizUcret;
                        hfDovizUcret.Value = lblDovizUcret.Text.Replace(Sabitler.KurSimgesi, string.Empty).Trim();

                        lblOdemeID.Text = SDataModel.Veriler.OdemeID;
                        hfOdemeID.Value = SDataModel.Veriler.OdemeID;
                    }
                    else
                    {
                        Response.Redirect("~/tr");
                    }
                }
                else
                {
                    Response.Redirect("~/tr");
                }
            }
        }


        protected void lnkbtnKayitOl_Click(object sender, EventArgs e)
        {
            Kontrol.BoolKontrol(ddlKrediKartiUlke.SelectedValue, "Kredi kart�n�z�n ait oldu�u �lkeyi se�iniz", "Ge�ersiz �lke se�ildi", ref Uyarilar);
            Kontrol.KelimeKontrol(txtKrediKartNo, "Kredi kart numaras� bo� b�rak�lamaz", ref Uyarilar);
            Kontrol.KelimeKontrol(txtAy, "Ay bo� b�rak�lamaz", ref Uyarilar);
            Kontrol.KelimeKontrol(txtYil, "Y�l bo� b�rak�lamaz", ref Uyarilar);
            Kontrol.KelimeKontrol(txtCVV2, "CVV2 bo� b�rak�lamaz", ref Uyarilar);

            if (string.IsNullOrEmpty(Uyarilar.ToString()))
            {
                // Bankaya g�re kod d�zene�i gelecek.
            }
            else
            {
                BilgiKontrolMerkezi.UyariEkrani(this, $"UyariBilgilendirme('', '{Uyarilar}', false);", true, true);
            }
        }
    }
}