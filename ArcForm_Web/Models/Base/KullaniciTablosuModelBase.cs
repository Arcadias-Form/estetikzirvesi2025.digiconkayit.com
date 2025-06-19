using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ModelBase
{
	[Table("KullaniciTablosu")]
	public abstract class KullaniciTablosuModelBase
	{
		[Key]
		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(36, ErrorMessage = "UzunlukUyari")]
		[Column("KullaniciID", Order = 0)]
		public virtual string KullaniciID { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("AdSoyad", Order = 1)]
		public virtual string AdSoyad { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[EmailAddress(ErrorMessage = "GecersizUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("ePosta", Order = 2)]
		public virtual string ePosta { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("Sifre", Order = 3)]
		public virtual string Sifre { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[DataType(DataType.DateTime, ErrorMessage = "GecersizUyari")]
		[Column("GuncellenmeTarihi", Order = 4)]
		public virtual DateTime GuncellenmeTarihi { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[DataType(DataType.DateTime, ErrorMessage = "GecersizUyari")]
		[Column("EklenmeTarihi", Order = 5)]
		public virtual DateTime EklenmeTarihi { get; set; }


		public static int OzellikSayisi { get { return typeof(KullaniciTablosuModelBase).GetProperties().Count(x => !x.GetAccessors()[0].IsStatic); }}

		public static string SQLSutunSorgusu { get { return string.Join(", ", typeof(KullaniciTablosuModelBase).GetProperties().Where(x => !x.GetAccessors()[0].IsStatic).OrderBy(x => (x.GetCustomAttributes(typeof(ColumnAttribute), true).First() as ColumnAttribute).Order).Select(x => $"[KullaniciTablosu].[{x.Name}]")); }}

		public virtual string BaseJsonModel()
		{
			return JsonConvert.SerializeObject(this);
		}

	}
}