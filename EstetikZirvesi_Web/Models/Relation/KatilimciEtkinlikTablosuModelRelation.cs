using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ModelBase;
using Model;

namespace ModelRelation
{
	public abstract class KatilimciEtkinlikTablosuModelRelation : KatilimciEtkinlikTablosuModelBase
	{
		public virtual KatilimciTablosuModel KatilimciBilgisi { get; set; }
		public virtual EtkinlikTablosuModel EtkinlikBilgisi { get; set; }

		public virtual string RelationJsonModel()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}