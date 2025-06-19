using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using VeritabaniIslemSaglayici.Access;

namespace VeritabaniIslemMerkeziBase
{
	public abstract class KonaklamaTablosuIslemlerBase
	{
		protected VTOperatorleri VTIslem;

		protected List<KonaklamaTablosuModel> VeriListe;

		protected SurecBilgiModel SModel;
		protected SurecVeriModel<KonaklamaTablosuModel> SDataModel;
		protected SurecVeriModel<IList<KonaklamaTablosuModel>> SDataListModel;

		public KonaklamaTablosuIslemlerBase()
		{
			VTIslem = new VTOperatorleri();
		}

		public KonaklamaTablosuIslemlerBase(OleDbTransaction Transcation)
		{
			VTIslem = new VTOperatorleri(Transcation);
		}

		public virtual SurecBilgiModel YeniKayitEkle(KonaklamaTablosuModel YeniKayit)
		{
			VTIslem.SetCommandText("INSERT INTO [KonaklamaTablosu] ([KatilimciID], [OdaTipiID], [GirisTarihi], [CikisTarihi], [Refakatci], [GuncellenmeTarihi], [EklenmeTarihi]) VALUES (@KatilimciID, @OdaTipiID, @GirisTarihi, @CikisTarihi, @Refakatci, @GuncellenmeTarihi, @EklenmeTarihi)");
			VTIslem.AddWithValue("KatilimciID", YeniKayit.KatilimciID);
			VTIslem.AddWithValue("OdaTipiID", YeniKayit.OdaTipiID);
			VTIslem.AddWithValue("GirisTarihi", YeniKayit.GirisTarihi);
			VTIslem.AddWithValue("CikisTarihi", YeniKayit.CikisTarihi);
			VTIslem.AddWithValue("Refakatci", YeniKayit.Refakatci);
			VTIslem.AddWithValue("GuncellenmeTarihi", YeniKayit.GuncellenmeTarihi);
			VTIslem.AddWithValue("EklenmeTarihi", YeniKayit.EklenmeTarihi);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecBilgiModel KayitGuncelle(KonaklamaTablosuModel GuncelKayit)
		{
			VTIslem.SetCommandText("UPDATE [KonaklamaTablosu] SET [KatilimciID] = @KatilimciID, [OdaTipiID] = @OdaTipiID, [GirisTarihi] = @GirisTarihi, [CikisTarihi] = @CikisTarihi, [Refakatci] = @Refakatci, [GuncellenmeTarihi] = @GuncellenmeTarihi, [EklenmeTarihi] = @EklenmeTarihi WHERE [KonaklamaID] = @KonaklamaID");
			VTIslem.AddWithValue("KatilimciID", GuncelKayit.KatilimciID);
			VTIslem.AddWithValue("OdaTipiID", GuncelKayit.OdaTipiID);
			VTIslem.AddWithValue("GirisTarihi", GuncelKayit.GirisTarihi);
			VTIslem.AddWithValue("CikisTarihi", GuncelKayit.CikisTarihi);
			VTIslem.AddWithValue("Refakatci", GuncelKayit.Refakatci);
			VTIslem.AddWithValue("GuncellenmeTarihi", GuncelKayit.GuncellenmeTarihi);
			VTIslem.AddWithValue("EklenmeTarihi", GuncelKayit.EklenmeTarihi);
			VTIslem.AddWithValue("KonaklamaID", GuncelKayit.KonaklamaID);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecBilgiModel KayitSil(int KonaklamaID)
		{
			VTIslem.SetCommandText("DELETE FROM [KonaklamaTablosu] WHERE [KonaklamaID] = @KonaklamaID");
			VTIslem.AddWithValue("KonaklamaID", KonaklamaID);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecVeriModel<KonaklamaTablosuModel> KayitBilgisi(int KonaklamaID)
		{
			VTIslem.SetCommandText($"SELECT {KonaklamaTablosuModel.SQLSutunSorgusu} FROM [KonaklamaTablosu] WHERE [KonaklamaID] = @KonaklamaID");
			VTIslem.AddWithValue("KonaklamaID", KonaklamaID);
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
					SDataModel = new SurecVeriModel<KonaklamaTablosuModel>
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
				SDataModel = new SurecVeriModel<KonaklamaTablosuModel>
				{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataModel;
		}

		public virtual SurecVeriModel<IList<KonaklamaTablosuModel>> KayitBilgileri()
		{
			VTIslem.SetCommandText($"SELECT {KonaklamaTablosuModel.SQLSutunSorgusu} FROM [KonaklamaTablosu]");
			VTIslem.OpenConnection();
			SModel = VTIslem.ExecuteReader(CommandBehavior.Default);
			if (SModel.Sonuc.Equals(Sonuclar.Basarili))
			{
				VeriListe = new List<KonaklamaTablosuModel>();
				while (SModel.Reader.Read())
				{
					if (KayitBilgisiAl(0, SModel.Reader).Sonuc.Equals(Sonuclar.Basarili))
					{
						VeriListe.Add(SDataModel.Veriler);
					}
					else
					{
						SDataListModel = new SurecVeriModel<IList<KonaklamaTablosuModel>>{
							Sonuc = SDataModel.Sonuc,
							KullaniciMesaji = SDataModel.KullaniciMesaji,
							HataBilgi = SDataModel.HataBilgi
						};
						VTIslem.CloseConnection();
						return SDataListModel;
					}
				}
				SDataListModel = new SurecVeriModel<IList<KonaklamaTablosuModel>>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri listesi başarıyla çekildi",
					Veriler = VeriListe
				};
			}
			else
			{
				SDataListModel = new SurecVeriModel<IList<KonaklamaTablosuModel>>{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataListModel;
		}

		public virtual SurecVeriModel<KonaklamaTablosuModel> KayitBilgisiAl(int Baslangic, DbDataReader Reader)
		{
			try
			{
				SDataModel = new SurecVeriModel<KonaklamaTablosuModel>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri bilgisi başarıyla çekilmiştir.",
					Veriler = new KonaklamaTablosuModel{
						KonaklamaID = Reader.GetInt32(Baslangic + 0),
						KatilimciID = Reader.GetString(Baslangic + 1),
						OdaTipiID = Reader.GetInt32(Baslangic + 2),
						GirisTarihi = Reader.GetDateTime(Baslangic + 3),
						CikisTarihi = Reader.GetDateTime(Baslangic + 4),
						Refakatci = Reader.GetString(Baslangic + 5),
						GuncellenmeTarihi = Reader.GetDateTime(Baslangic + 6),
						EklenmeTarihi = Reader.GetDateTime(Baslangic + 7),
					}
				};
			}
			catch (InvalidCastException ex)
			{
				SDataModel = new SurecVeriModel<KonaklamaTablosuModel>{
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
				SDataModel = new SurecVeriModel<KonaklamaTablosuModel>{
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

		public virtual SurecVeriModel<KonaklamaTablosuModel> KatilimciBilgisi(string KatilimciID)
		{
			VTIslem.SetCommandText($"SELECT {KonaklamaTablosuModel.SQLSutunSorgusu}FROM [KonaklamaTablosu] WHERE [KatilimciID] = @KatilimciID");
			VTIslem.AddWithValue("KatilimciID", KatilimciID);
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
					SDataModel = new SurecVeriModel<KonaklamaTablosuModel>
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
				SDataModel = new SurecVeriModel<KonaklamaTablosuModel>
				{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataModel;
		}

		public virtual SurecVeriModel<IList<KonaklamaTablosuModel>> OdaTipiBilgileri(int OdaTipiID)
		{
			VTIslem.SetCommandText($"SELECT {KonaklamaTablosuModel.SQLSutunSorgusu} FROM [KonaklamaTablosu] WHERE [OdaTipiID] = @OdaTipiID");
			VTIslem.AddWithValue("OdaTipiID", OdaTipiID);
			VTIslem.OpenConnection();
			SModel = VTIslem.ExecuteReader(CommandBehavior.Default);
			if (SModel.Sonuc.Equals(Sonuclar.Basarili))
			{
				VeriListe = new List<KonaklamaTablosuModel>();
				while (SModel.Reader.Read())
				{
					if (KayitBilgisiAl(0, SModel.Reader).Sonuc.Equals(Sonuclar.Basarili))
					{
						VeriListe.Add(SDataModel.Veriler);
					}
					else
					{
						SDataListModel = new SurecVeriModel<IList<KonaklamaTablosuModel>>{
							Sonuc = SDataModel.Sonuc,
							KullaniciMesaji = SDataModel.KullaniciMesaji,
							HataBilgi = SDataModel.HataBilgi
						};
						VTIslem.CloseConnection();
						return SDataListModel;
					}
				}
				SDataListModel = new SurecVeriModel<IList<KonaklamaTablosuModel>>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri listesi başarıyla çekildi",
					Veriler = VeriListe
				};
			}
			else
			{
				SDataListModel = new SurecVeriModel<IList<KonaklamaTablosuModel>>{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataListModel;
		}

	}
}