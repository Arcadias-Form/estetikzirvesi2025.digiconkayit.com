using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ModelBase;
using Model;

namespace ModelRelation
{
	public abstract class KatilimciTipiTablosuModelRelation : KatilimciTipiTablosuModelBase
	{
		public virtual IList<KatilimciTablosuModel> KatilimciBilgisi { get; set; }
		public virtual IList<KatilimciTipiDilTablosuModel> KatilimciTipiDilBilgisi { get; set; }

		public virtual string RelationJsonModel()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}