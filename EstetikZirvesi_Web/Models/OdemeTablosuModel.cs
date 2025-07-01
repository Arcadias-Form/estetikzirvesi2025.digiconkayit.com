using Newtonsoft.Json;
using System;
using ModelRelation;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Model
{
	public partial class OdemeTablosuModel : OdemeTablosuModelRelation
	{
        public DataRow DRow(DataRow MainRow)
        {
            MainRow[0] = OdemeID;
            MainRow[1] = KatilimciBilgisi.AdSoyad;
            MainRow[2] = KatilimciBilgisi.KimlikNo;
            MainRow[3] = KatilimciBilgisi.ePosta;
            MainRow[4] = KatilimciBilgisi.CepTelefonu;
            MainRow[5] = KatilimciBilgisi.Kurum;
            MainRow[6] = KatilimciBilgisi.KatilimciTipiBilgisi.KatilimciTipiDilBilgisi.First().KatilimciTipi;
            MainRow[7] = string.Join(", ", KatilimciBilgisi.KatilimciKursBilgisi is null ? new List<string>() : KatilimciBilgisi.KatilimciKursBilgisi.Select(x => x.KursTipiBilgisi.KursTipiDilBilgisi.First().KursTipi).ToList());
            MainRow[8] = string.Join(", ", KatilimciBilgisi.KatilimciEtkinlikBilgisi is null ? new List<string>() : KatilimciBilgisi.KatilimciEtkinlikBilgisi.Select(x => x.EtkinlikBilgisi.EtkinlikDilBilgisi.First().Etkinlik).ToList());
            MainRow[9] = KatilimciBilgisi.FaturaUnvan;
            MainRow[10] = KatilimciBilgisi.FaturaAdres;
            MainRow[11] = KatilimciBilgisi.VergiDairesi;
            MainRow[12] = KatilimciBilgisi.VergiNo;
            MainRow[13] = OdemeTipiBilgisi.OdemeTipiDilBilgisi.First().OdemeTipi;
            MainRow[14] = $"{DovizUcret}";
            MainRow[15] = $"{OdemeTarihi:dd.MM.yyyy HH:mm}";

            return MainRow;
        }


        public virtual string FullJsonModel()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}