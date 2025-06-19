using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using VeritabaniIslemSaglayici.Access;

namespace VeritabaniIslemMerkeziBase
{
	public abstract class OdaTipiTablosuIslemlerBase
	{
		protected VTOperatorleri VTIslem;

		protected List<OdaTipiTablosuModel> VeriListe;

		protected SurecBilgiModel SModel;
		protected SurecVeriModel<OdaTipiTablosuModel> SDataModel;
		protected SurecVeriModel<IList<OdaTipiTablosuModel>> SDataListModel;

		public OdaTipiTablosuIslemlerBase()
		{
			VTIslem = new VTOperatorleri();
		}

		public OdaTipiTablosuIslemlerBase(OleDbTransaction Transcation)
		{
			VTIslem = new VTOperatorleri(Transcation);
		}

		public virtual SurecBilgiModel YeniKayitEkle(OdaTipiTablosuModel YeniKayit)
		{
			VTIslem.SetCommandText("INSERT INTO [OdaTipiTablosu] ([OtelID], [CokErkenUcret], [ErkenUcret], [NormalUcret], [BaslangicTarihi], [BitisTarihi], [TarihSecim], [RefakatciDurum], [RefakatciCarpan], [Sira], [GuncellenmeTarihi], [EklenmeTarihi]) VALUES (@OtelID, @CokErkenUcret, @ErkenUcret, @NormalUcret, @BaslangicTarihi, @BitisTarihi, @TarihSecim, @RefakatciDurum, @RefakatciCarpan, @Sira, @GuncellenmeTarihi, @EklenmeTarihi)");
			VTIslem.AddWithValue("OtelID", YeniKayit.OtelID);
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
			VTIslem.AddWithValue("BaslangicTarihi", YeniKayit.BaslangicTarihi);
			VTIslem.AddWithValue("BitisTarihi", YeniKayit.BitisTarihi);
			VTIslem.AddWithValue("TarihSecim", YeniKayit.TarihSecim);
			VTIslem.AddWithValue("RefakatciDurum", YeniKayit.RefakatciDurum);
			VTIslem.AddWithValue("RefakatciCarpan", YeniKayit.RefakatciCarpan);
			VTIslem.AddWithValue("Sira", YeniKayit.Sira);
			VTIslem.AddWithValue("GuncellenmeTarihi", YeniKayit.GuncellenmeTarihi);
			VTIslem.AddWithValue("EklenmeTarihi", YeniKayit.EklenmeTarihi);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecBilgiModel KayitGuncelle(OdaTipiTablosuModel GuncelKayit)
		{
			VTIslem.SetCommandText("UPDATE [OdaTipiTablosu] SET [OtelID] = @OtelID, [CokErkenUcret] = @CokErkenUcret, [ErkenUcret] = @ErkenUcret, [NormalUcret] = @NormalUcret, [BaslangicTarihi] = @BaslangicTarihi, [BitisTarihi] = @BitisTarihi, [TarihSecim] = @TarihSecim, [RefakatciDurum] = @RefakatciDurum, [RefakatciCarpan] = @RefakatciCarpan, [Sira] = @Sira, [GuncellenmeTarihi] = @GuncellenmeTarihi, [EklenmeTarihi] = @EklenmeTarihi WHERE [OdaTipiID] = @OdaTipiID");
			VTIslem.AddWithValue("OtelID", GuncelKayit.OtelID);
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
			VTIslem.AddWithValue("BaslangicTarihi", GuncelKayit.BaslangicTarihi);
			VTIslem.AddWithValue("BitisTarihi", GuncelKayit.BitisTarihi);
			VTIslem.AddWithValue("TarihSecim", GuncelKayit.TarihSecim);
			VTIslem.AddWithValue("RefakatciDurum", GuncelKayit.RefakatciDurum);
			VTIslem.AddWithValue("RefakatciCarpan", GuncelKayit.RefakatciCarpan);
			VTIslem.AddWithValue("Sira", GuncelKayit.Sira);
			VTIslem.AddWithValue("GuncellenmeTarihi", GuncelKayit.GuncellenmeTarihi);
			VTIslem.AddWithValue("EklenmeTarihi", GuncelKayit.EklenmeTarihi);
			VTIslem.AddWithValue("OdaTipiID", GuncelKayit.OdaTipiID);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecBilgiModel KayitSil(int OdaTipiID)
		{
			VTIslem.SetCommandText("DELETE FROM [OdaTipiTablosu] WHERE [OdaTipiID] = @OdaTipiID");
			VTIslem.AddWithValue("OdaTipiID", OdaTipiID);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecVeriModel<OdaTipiTablosuModel> KayitBilgisi(int OdaTipiID)
		{
			VTIslem.SetCommandText($"SELECT {OdaTipiTablosuModel.SQLSutunSorgusu} FROM [OdaTipiTablosu] WHERE [OdaTipiID] = @OdaTipiID");
			VTIslem.AddWithValue("OdaTipiID", OdaTipiID);
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
					SDataModel = new SurecVeriModel<OdaTipiTablosuModel>
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
				SDataModel = new SurecVeriModel<OdaTipiTablosuModel>
				{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataModel;
		}

		public virtual SurecVeriModel<IList<OdaTipiTablosuModel>> KayitBilgileri()
		{
			VTIslem.SetCommandText($"SELECT {OdaTipiTablosuModel.SQLSutunSorgusu} FROM [OdaTipiTablosu]");
			VTIslem.OpenConnection();
			SModel = VTIslem.ExecuteReader(CommandBehavior.Default);
			if (SModel.Sonuc.Equals(Sonuclar.Basarili))
			{
				VeriListe = new List<OdaTipiTablosuModel>();
				while (SModel.Reader.Read())
				{
					if (KayitBilgisiAl(0, SModel.Reader).Sonuc.Equals(Sonuclar.Basarili))
					{
						VeriListe.Add(SDataModel.Veriler);
					}
					else
					{
						SDataListModel = new SurecVeriModel<IList<OdaTipiTablosuModel>>{
							Sonuc = SDataModel.Sonuc,
							KullaniciMesaji = SDataModel.KullaniciMesaji,
							HataBilgi = SDataModel.HataBilgi
						};
						VTIslem.CloseConnection();
						return SDataListModel;
					}
				}
				SDataListModel = new SurecVeriModel<IList<OdaTipiTablosuModel>>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri listesi başarıyla çekildi",
					Veriler = VeriListe
				};
			}
			else
			{
				SDataListModel = new SurecVeriModel<IList<OdaTipiTablosuModel>>{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataListModel;
		}

		public virtual SurecVeriModel<OdaTipiTablosuModel> KayitBilgisiAl(int Baslangic, DbDataReader Reader)
		{
			try
			{
				SDataModel = new SurecVeriModel<OdaTipiTablosuModel>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri bilgisi başarıyla çekilmiştir.",
					Veriler = new OdaTipiTablosuModel{
						OdaTipiID = Reader.GetInt32(Baslangic + 0),
						OtelID = Reader.GetInt32(Baslangic + 1),
						CokErkenUcret = Reader.GetDecimal(Baslangic + 2),
						ErkenUcret = Reader.GetDecimal(Baslangic + 3),
						NormalUcret = Reader.GetDecimal(Baslangic + 4),
						BaslangicTarihi = Reader.GetDateTime(Baslangic + 5),
						BitisTarihi = Reader.GetDateTime(Baslangic + 6),
						TarihSecim = Reader.GetBoolean(Baslangic + 7),
						RefakatciDurum = Reader.GetBoolean(Baslangic + 8),
						RefakatciCarpan = Reader.GetInt32(Baslangic + 9),
						Sira = Reader.GetInt32(Baslangic + 10),
						GuncellenmeTarihi = Reader.GetDateTime(Baslangic + 11),
						EklenmeTarihi = Reader.GetDateTime(Baslangic + 12),
					}
				};
			}
			catch (InvalidCastException ex)
			{
				SDataModel = new SurecVeriModel<OdaTipiTablosuModel>{
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
				SDataModel = new SurecVeriModel<OdaTipiTablosuModel>{
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

		public virtual SurecVeriModel<IList<OdaTipiTablosuModel>> OtelBilgileri(int OtelID)
		{
			VTIslem.SetCommandText($"SELECT {OdaTipiTablosuModel.SQLSutunSorgusu} FROM [OdaTipiTablosu] WHERE [OtelID] = @OtelID");
			VTIslem.AddWithValue("OtelID", OtelID);
			VTIslem.OpenConnection();
			SModel = VTIslem.ExecuteReader(CommandBehavior.Default);
			if (SModel.Sonuc.Equals(Sonuclar.Basarili))
			{
				VeriListe = new List<OdaTipiTablosuModel>();
				while (SModel.Reader.Read())
				{
					if (KayitBilgisiAl(0, SModel.Reader).Sonuc.Equals(Sonuclar.Basarili))
					{
						VeriListe.Add(SDataModel.Veriler);
					}
					else
					{
						SDataListModel = new SurecVeriModel<IList<OdaTipiTablosuModel>>{
							Sonuc = SDataModel.Sonuc,
							KullaniciMesaji = SDataModel.KullaniciMesaji,
							HataBilgi = SDataModel.HataBilgi
						};
						VTIslem.CloseConnection();
						return SDataListModel;
					}
				}
				SDataListModel = new SurecVeriModel<IList<OdaTipiTablosuModel>>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri listesi başarıyla çekildi",
					Veriler = VeriListe
				};
			}
			else
			{
				SDataListModel = new SurecVeriModel<IList<OdaTipiTablosuModel>>{
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