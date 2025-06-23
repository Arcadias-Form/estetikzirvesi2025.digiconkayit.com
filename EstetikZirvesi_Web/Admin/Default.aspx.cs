using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeritabaniIslemMerkezi;

namespace EstetikZirvesi_Web.Admin
{
    public partial class Default : Page
    {
        BilgiKontrolMerkezi Kontrol = new BilgiKontrolMerkezi();

        SurecBilgiModel SModel;
        SurecVeriModel<KullaniciTablosuModel> SDataModel;

        KullaniciTablosuModel KModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Response.Redirect($"~/Admin", true);
                }
            }

        }

        protected void LGGiris_LoginError(object sender, EventArgs e)
        {
            BilgiKontrolMerkezi.UyariEkrani(this, "UyariBilgilendirme('Dikkat', '<p>Kullanýcý adýnýzý ve/veya þifrenizi kontrol ediniz.</p>', false);", false);
        }
    }
}