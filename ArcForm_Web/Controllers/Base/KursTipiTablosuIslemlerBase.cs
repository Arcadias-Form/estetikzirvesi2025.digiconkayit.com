using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using VeritabaniIslemSaglayici.Access;

namespace VeritabaniIslemMerkeziBase
{
	public abstract class KursTipiTablosuIslemlerBase
	{
		protected VTOperatorleri VTIslem;

		protected List<KursTipiTablosuModel> VeriListe;

		protected SurecBilgiModel SModel;
		protected SurecVeriModel<KursTipiTablosuModel> SDataModel;
		protected SurecVeriModel<IList<KursTipiTablosuModel>> SDataListModel;

		public KursTipiTablosuIslemlerBase()
		{
			VTIslem = new VTOperatorleri();
		}

		public KursTipiTablosuIslemlerBase(OleDbTransaction Transcation)
		{
			VTIslem = new VTOperatorleri(Transcation);
		}

		public virtual SurecBilgiModel YeniKayitEkle(KursTipiTablosuModel YeniKayit)
		{
			VTIslem.SetCommandText("INSERT INTO [KursTipiTablosu] ([CokErkenUcret], [ErkenUcret], [NormalUcret], [Sira], [GuncellenmeTarihi], [EklenmeTarihi]) VALUES (@CokErkenUcret, @ErkenUcret, @NormalUcret, @Sira, @GuncellenmeTarihi, @EklenmeTarihi)");
			#if DEBUG
				VTIslem.AddWithValue("CokErkenUcret", YeniKayit.CokErkenUcret.ToString());
			#else
				VTIslem.AddWithValue("CokErkenUcret", YeniKayit.CokErkenUcret.ToString().Replace(",", "."));
			#endif
			#if DEBUG
				VTIslem.AddWithValue("ErkenUcret", YeniKayit.ErkenUcret.ToString());
			#else
				VTIslem.AddWithValue("ErkenUcret", YeniKayit.ErkenUcret.ToString().Replace(",", "."));
			#endif
			#if DEBUG
				VTIslem.AddWithValue("NormalUcret", YeniKayit.NormalUcret.ToString());
			#else
				VTIslem.AddWithValue("NormalUcret", YeniKayit.NormalUcret.ToString().Replace(",", "."));
			#endif
			VTIslem.AddWithValue("Sira", YeniKayit.Sira);
			VTIslem.AddWithValue("GuncellenmeTarihi", YeniKayit.GuncellenmeTarihi);
			VTIslem.AddWithValue("EklenmeTarihi", YeniKayit.EklenmeTarihi);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecBilgiModel KayitGuncelle(KursTipiTablosuModel GuncelKayit)
		{
			VTIslem.SetCommandText("UPDATE [KursTipiTablosu] SET [CokErkenUcret] = @CokErkenUcret, [ErkenUcret] = @ErkenUcret, [NormalUcret] = @NormalUcret, [Sira] = @Sira, [GuncellenmeTarihi] = @GuncellenmeTarihi, [EklenmeTarihi] = @EklenmeTarihi WHERE [KursTipiID] = @KursTipiID");
			#if DEBUG
				VTIslem.AddWithValue("CokErkenUcret", GuncelKayit.CokErkenUcret.ToString());
			#else
				VTIslem.AddWithValue("CokErkenUcret", GuncelKayit.CokErkenUcret.ToString().Replace(",", "."));
			#endif
			#if DEBUG
				VTIslem.AddWithValue("ErkenUcret", GuncelKayit.ErkenUcret.ToString());
			#else
				VTIslem.AddWithValue("ErkenUcret", GuncelKayit.ErkenUcret.ToString().Replace(",", "."));
			#endif
			#if DEBUG
				VTIslem.AddWithValue("NormalUcret", GuncelKayit.NormalUcret.ToString());
			#else
				VTIslem.AddWithValue("NormalUcret", GuncelKayit.NormalUcret.ToString().Replace(",", "."));
			#endif
			VTIslem.AddWithValue("Sira", GuncelKayit.Sira);
			VTIslem.AddWithValue("GuncellenmeTarihi", GuncelKayit.GuncellenmeTarihi);
			VTIslem.AddWithValue("EklenmeTarihi", GuncelKayit.EklenmeTarihi);
			VTIslem.AddWithValue("KursTipiID", GuncelKayit.KursTipiID);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecBilgiModel KayitSil(int KursTipiID)
		{
			VTIslem.SetCommandText("DELETE FROM [KursTipiTablosu] WHERE [KursTipiID] = @KursTipiID");
			VTIslem.AddWithValue("KursTipiID", KursTipiID);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecVeriModel<KursTipiTablosuModel> KayitBilgisi(int KursTipiID)
		{
			VTIslem.SetCommandText($"SELECT {KursTipiTablosuModel.SQLSutunSorgusu} FROM [KursTipiTablosu] WHERE [KursTipiID] = @KursTipiID");
			VTIslem.AddWithValue("KursTipiID", KursTipiID);
			VTIslem.OpenConnection();
			SModel = VTIslem.ExecuteReader(CommandBehavior.SingleResult);
			if (SModel.Sonuc.Equals(Sonuclar.Basarili))
			{
				while (SModel.Reader.Read())
				{
					KayitBilgisiAl(0, SModel.Reader);
				}
				if (SDataModel is null)
				{
					SDataModel = new SurecVeriModel<KursTipiTablosuModel>
					{
						Sonuc = Sonuclar.VeriBulunamadi,
						KullaniciMesaji = "Belirtilen kayıt bulunamamıştır",
						HataBilgi = new HataBilgileri
						{
							HataAlinanKayitID = 0,
							HataKodu = 0,
							HataMesaji = "Belirtilen kayıt bulunamamıştır"
						}
					};
				}
			}
			else
			{
				SDataModel = new SurecVeriModel<KursTipiTablosuModel>
				{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataModel;
		}

		public virtual SurecVeriModel<IList<KursTipiTablosuModel>> KayitBilgileri()
		{
			VTIslem.SetCommandText($"SELECT {KursTipiTablosuModel.SQLSutunSorgusu} FROM [KursTipiTablosu]");
			VTIslem.OpenConnection();
			SModel = VTIslem.ExecuteReader(CommandBehavior.Default);
			if (SModel.Sonuc.Equals(Sonuclar.Basarili))
			{
				VeriListe = new List<KursTipiTablosuModel>();
				while (SModel.Reader.Read())
				{
					if (KayitBilgisiAl(0, SModel.Reader).Sonuc.Equals(Sonuclar.Basarili))
					{
						VeriListe.Add(SDataModel.Veriler);
					}
					else
					{
						SDataListModel = new SurecVeriModel<IList<KursTipiTablosuModel>>{
							Sonuc = SDataModel.Sonuc,
							KullaniciMesaji = SDataModel.KullaniciMesaji,
							HataBilgi = SDataModel.HataBilgi
						};
						VTIslem.CloseConnection();
						return SDataListModel;
					}
				}
				SDataListModel = new SurecVeriModel<IList<KursTipiTablosuModel>>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri listesi başarıyla çekildi",
					Veriler = VeriListe
				};
			}
			else
			{
				SDataListModel = new SurecVeriModel<IList<KursTipiTablosuModel>>{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataListModel;
		}

		public virtual SurecVeriModel<KursTipiTablosuModel> KayitBilgisiAl(int Baslangic, DbDataReader Reader)
		{
			try
			{
				SDataModel = new SurecVeriModel<KursTipiTablosuModel>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri bilgisi başarıyla çekilmiştir.",
					Veriler = new KursTipiTablosuModel{
						KursTipiID = Reader.GetInt32(Baslangic + 0),
						CokErkenUcret = Reader.GetDecimal(Baslangic + 1),
						ErkenUcret = Reader.GetDecimal(Baslangic + 2),
						NormalUcret = Reader.GetDecimal(Baslangic + 3),
						Sira = Reader.GetInt32(Baslangic + 4),
						GuncellenmeTarihi = Reader.GetDateTime(Baslangic + 5),
						EklenmeTarihi = Reader.GetDateTime(Baslangic + 6),
					}
				};
			}
			catch (InvalidCastException ex)
			{
				SDataModel = new SurecVeriModel<KursTipiTablosuModel>{
					Sonuc = Sonuclar.Basarisiz,
					KullaniciMesaji = "Veri bilgisi çekilirken hatalı atama yapılmaya çalışıldı",
					HataBilgi = new HataBilgileri{
						HataMesaji = string.Format(@"{0}", ex.Message.Replace("'", "ʼ")),
						HataKodu = ex.HResult,
						HataAlinanKayitID = Reader.GetValue(0)
					}
				};
			}
			catch (Exception ex)
			{
				SDataModel = new SurecVeriModel<KursTipiTablosuModel>{
					Sonuc = Sonuclar.Basarisiz,
					KullaniciMesaji = "Veri bilgisi çekilirken hatalı atama yapılmaya çalışıldı",
						HataBilgi = new HataBilgileri{
						HataMesaji = string.Format(@"{0}", ex.Message.Replace("'", "ʼ")),
						HataKodu = ex.HResult,
						HataAlinanKayitID = Reader.GetValue(0)
					}
				};
			}
			return SDataModel;
		}

	}
}