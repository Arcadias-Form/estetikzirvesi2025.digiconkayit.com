using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using VeritabaniIslemSaglayici.Access;

namespace VeritabaniIslemMerkeziBase
{
	public abstract class OdemeTablosuIslemlerBase
	{
		protected VTOperatorleri VTIslem;

		protected List<OdemeTablosuModel> VeriListe;

		protected SurecBilgiModel SModel;
		protected SurecVeriModel<OdemeTablosuModel> SDataModel;
		protected SurecVeriModel<IList<OdemeTablosuModel>> SDataListModel;

		public OdemeTablosuIslemlerBase()
		{
			VTIslem = new VTOperatorleri();
		}

		public OdemeTablosuIslemlerBase(OleDbTransaction Transcation)
		{
			VTIslem = new VTOperatorleri(Transcation);
		}

		public virtual SurecBilgiModel YeniKayitEkle(OdemeTablosuModel YeniKayit)
		{
			VTIslem.SetCommandText("INSERT INTO [OdemeTablosu] ([OdemeID], [OdemeTipiID], [KatilimciID], [Durum], [OdemeTarihi], [OdemeParametreleri], [DovizUcret], [TurkLirasiUcret], [KurUcret], [KatilimciTipiUcret], [KonaklamaUcret], [TransferUcret], [KursUcret], [EtkinlikUcret], [Hash], [GuncellenmeTarihi], [EklenmeTarihi]) VALUES (@OdemeID, @OdemeTipiID, @KatilimciID, @Durum, @OdemeTarihi, @OdemeParametreleri, @DovizUcret, @TurkLirasiUcret, @KurUcret, @KatilimciTipiUcret, @KonaklamaUcret, @TransferUcret, @KursUcret, @EtkinlikUcret, @Hash, @GuncellenmeTarihi, @EklenmeTarihi)");
			VTIslem.AddWithValue("OdemeID", YeniKayit.OdemeID);
			VTIslem.AddWithValue("OdemeTipiID", YeniKayit.OdemeTipiID);
			VTIslem.AddWithValue("KatilimciID", YeniKayit.KatilimciID);
			VTIslem.AddWithValue("Durum", YeniKayit.Durum);

			if(YeniKayit.OdemeTarihi is null)
				VTIslem.AddWithValue("OdemeTarihi", DBNull.Value);
			else
				VTIslem.AddWithValue("OdemeTarihi", YeniKayit.OdemeTarihi);

			VTIslem.AddWithValue("OdemeParametreleri", YeniKayit.OdemeParametreleri);
			VTIslem.AddWithValue("DovizUcret", YeniKayit.DovizUcret);
			VTIslem.AddWithValue("TurkLirasiUcret", YeniKayit.TurkLirasiUcret);
			VTIslem.AddWithValue("KurUcret", YeniKayit.KurUcret);
			VTIslem.AddWithValue("KatilimciTipiUcret", YeniKayit.KatilimciTipiUcret);
			VTIslem.AddWithValue("KonaklamaUcret", YeniKayit.KonaklamaUcret);
			VTIslem.AddWithValue("TransferUcret", YeniKayit.TransferUcret);
			VTIslem.AddWithValue("KursUcret", YeniKayit.KursUcret);
			VTIslem.AddWithValue("EtkinlikUcret", YeniKayit.EtkinlikUcret);
			VTIslem.AddWithValue("Hash", YeniKayit.Hash);
			VTIslem.AddWithValue("GuncellenmeTarihi", YeniKayit.GuncellenmeTarihi);
			VTIslem.AddWithValue("EklenmeTarihi", YeniKayit.EklenmeTarihi);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecBilgiModel KayitGuncelle(OdemeTablosuModel GuncelKayit)
		{
			VTIslem.SetCommandText("UPDATE [OdemeTablosu] SET [OdemeTipiID] = @OdemeTipiID, [KatilimciID] = @KatilimciID, [Durum] = @Durum, [OdemeTarihi] = @OdemeTarihi, [OdemeParametreleri] = @OdemeParametreleri, [DovizUcret] = @DovizUcret, [TurkLirasiUcret] = @TurkLirasiUcret, [KurUcret] = @KurUcret, [KatilimciTipiUcret] = @KatilimciTipiUcret, [KonaklamaUcret] = @KonaklamaUcret, [TransferUcret] = @TransferUcret, [KursUcret] = @KursUcret, [EtkinlikUcret] = @EtkinlikUcret, [Hash] = @Hash, [GuncellenmeTarihi] = @GuncellenmeTarihi, [EklenmeTarihi] = @EklenmeTarihi WHERE [OdemeID] = @OdemeID");
			VTIslem.AddWithValue("OdemeTipiID", GuncelKayit.OdemeTipiID);
			VTIslem.AddWithValue("KatilimciID", GuncelKayit.KatilimciID);
			VTIslem.AddWithValue("Durum", GuncelKayit.Durum);

			if(GuncelKayit.OdemeTarihi is null)
				VTIslem.AddWithValue("OdemeTarihi", DBNull.Value);
			else
				VTIslem.AddWithValue("OdemeTarihi", GuncelKayit.OdemeTarihi.Value);

			VTIslem.AddWithValue("OdemeParametreleri", GuncelKayit.OdemeParametreleri);
			VTIslem.AddWithValue("DovizUcret", GuncelKayit.DovizUcret);
			VTIslem.AddWithValue("TurkLirasiUcret", GuncelKayit.TurkLirasiUcret);
			VTIslem.AddWithValue("KurUcret", GuncelKayit.KurUcret);
			VTIslem.AddWithValue("KatilimciTipiUcret", GuncelKayit.KatilimciTipiUcret);
			VTIslem.AddWithValue("KonaklamaUcret", GuncelKayit.KonaklamaUcret);
			VTIslem.AddWithValue("TransferUcret", GuncelKayit.TransferUcret);
			VTIslem.AddWithValue("KursUcret", GuncelKayit.KursUcret);
			VTIslem.AddWithValue("EtkinlikUcret", GuncelKayit.EtkinlikUcret);
			VTIslem.AddWithValue("Hash", GuncelKayit.Hash);
			VTIslem.AddWithValue("GuncellenmeTarihi", GuncelKayit.GuncellenmeTarihi);
			VTIslem.AddWithValue("EklenmeTarihi", GuncelKayit.EklenmeTarihi);
			VTIslem.AddWithValue("OdemeID", GuncelKayit.OdemeID);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecBilgiModel KayitSil(string OdemeID)
		{
			VTIslem.SetCommandText("DELETE FROM [OdemeTablosu] WHERE [OdemeID] = @OdemeID");
			VTIslem.AddWithValue("OdemeID", OdemeID);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecVeriModel<OdemeTablosuModel> KayitBilgisi(string OdemeID)
		{
			VTIslem.SetCommandText($"SELECT {OdemeTablosuModel.SQLSutunSorgusu} FROM [OdemeTablosu] WHERE [OdemeID] = @OdemeID");
			VTIslem.AddWithValue("OdemeID", OdemeID);
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
					SDataModel = new SurecVeriModel<OdemeTablosuModel>
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
				SDataModel = new SurecVeriModel<OdemeTablosuModel>
				{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataModel;
		}

		public virtual SurecVeriModel<IList<OdemeTablosuModel>> KayitBilgileri()
		{
			VTIslem.SetCommandText($"SELECT {OdemeTablosuModel.SQLSutunSorgusu} FROM [OdemeTablosu]");
			VTIslem.OpenConnection();
			SModel = VTIslem.ExecuteReader(CommandBehavior.Default);
			if (SModel.Sonuc.Equals(Sonuclar.Basarili))
			{
				VeriListe = new List<OdemeTablosuModel>();
				while (SModel.Reader.Read())
				{
					if (KayitBilgisiAl(0, SModel.Reader).Sonuc.Equals(Sonuclar.Basarili))
					{
						VeriListe.Add(SDataModel.Veriler);
					}
					else
					{
						SDataListModel = new SurecVeriModel<IList<OdemeTablosuModel>>{
							Sonuc = SDataModel.Sonuc,
							KullaniciMesaji = SDataModel.KullaniciMesaji,
							HataBilgi = SDataModel.HataBilgi
						};
						VTIslem.CloseConnection();
						return SDataListModel;
					}
				}
				SDataListModel = new SurecVeriModel<IList<OdemeTablosuModel>>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri listesi başarıyla çekildi",
					Veriler = VeriListe
				};
			}
			else
			{
				SDataListModel = new SurecVeriModel<IList<OdemeTablosuModel>>{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataListModel;
		}

		public virtual SurecVeriModel<OdemeTablosuModel> KayitBilgisiAl(int Baslangic, DbDataReader Reader)
		{
			try
			{
				SDataModel = new SurecVeriModel<OdemeTablosuModel>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri bilgisi başarıyla çekilmiştir.",
					Veriler = new OdemeTablosuModel{
						OdemeID = Reader.GetString(Baslangic + 0),
						OdemeTipiID = Reader.GetInt32(Baslangic + 1),
						KatilimciID = Reader.GetString(Baslangic + 2),
						Durum = Reader.GetBoolean(Baslangic + 3),
						OdemeTarihi = Reader.IsDBNull(Baslangic + 4) ? null : new DateTime?(Reader.GetDateTime(Baslangic + 4)),
						OdemeParametreleri = Reader.GetString(Baslangic + 5),
						DovizUcret = Reader.GetString(Baslangic + 6),
						TurkLirasiUcret = Reader.GetString(Baslangic + 7),
						KurUcret = Reader.GetString(Baslangic + 8),
						KatilimciTipiUcret = Reader.GetString(Baslangic + 9),
						KonaklamaUcret = Reader.GetString(Baslangic + 10),
						TransferUcret = Reader.GetString(Baslangic + 11),
						KursUcret = Reader.GetString(Baslangic + 12),
						EtkinlikUcret = Reader.GetString(Baslangic + 13),
						Hash = Reader.GetString(Baslangic + 14),
						GuncellenmeTarihi = Reader.GetDateTime(Baslangic + 15),
						EklenmeTarihi = Reader.GetDateTime(Baslangic + 16),
					}
				};
			}
			catch (InvalidCastException ex)
			{
				SDataModel = new SurecVeriModel<OdemeTablosuModel>{
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
				SDataModel = new SurecVeriModel<OdemeTablosuModel>{
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

		public virtual SurecVeriModel<IList<OdemeTablosuModel>> OdemeTipiBilgileri(int OdemeTipiID)
		{
			VTIslem.SetCommandText($"SELECT {OdemeTablosuModel.SQLSutunSorgusu} FROM [OdemeTablosu] WHERE [OdemeTipiID] = @OdemeTipiID");
			VTIslem.AddWithValue("OdemeTipiID", OdemeTipiID);
			VTIslem.OpenConnection();
			SModel = VTIslem.ExecuteReader(CommandBehavior.Default);
			if (SModel.Sonuc.Equals(Sonuclar.Basarili))
			{
				VeriListe = new List<OdemeTablosuModel>();
				while (SModel.Reader.Read())
				{
					if (KayitBilgisiAl(0, SModel.Reader).Sonuc.Equals(Sonuclar.Basarili))
					{
						VeriListe.Add(SDataModel.Veriler);
					}
					else
					{
						SDataListModel = new SurecVeriModel<IList<OdemeTablosuModel>>{
							Sonuc = SDataModel.Sonuc,
							KullaniciMesaji = SDataModel.KullaniciMesaji,
							HataBilgi = SDataModel.HataBilgi
						};
						VTIslem.CloseConnection();
						return SDataListModel;
					}
				}
				SDataListModel = new SurecVeriModel<IList<OdemeTablosuModel>>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri listesi başarıyla çekildi",
					Veriler = VeriListe
				};
			}
			else
			{
				SDataListModel = new SurecVeriModel<IList<OdemeTablosuModel>>{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataListModel;
		}

		public virtual SurecVeriModel<OdemeTablosuModel> KatilimciBilgisi(string KatilimciID)
		{
			VTIslem.SetCommandText($"SELECT {OdemeTablosuModel.SQLSutunSorgusu}FROM [OdemeTablosu] WHERE [KatilimciID] = @KatilimciID");
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
					SDataModel = new SurecVeriModel<OdemeTablosuModel>
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
				SDataModel = new SurecVeriModel<OdemeTablosuModel>
				{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataModel;
		}

	}
}