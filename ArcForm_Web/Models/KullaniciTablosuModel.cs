using Newtonsoft.Json;
using System;
using ModelRelation;

namespace Model
{
	public partial class KullaniciTablosuModel : KullaniciTablosuModelRelation
	{

		public virtual string FullJsonModel()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}