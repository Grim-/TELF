using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace TELF
{
	public class IncidentWorker_StartFog : IncidentWorker
	{
		protected WeatherDef FogWeather => DefDatabase<WeatherDef>.GetNamed("Fog");

		protected override bool CanFireNowSub(IncidentParms parms)
		{
			return ((Map)parms.target).weatherManager.curWeather != FogWeather;
		}


		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			Map map = (Map)parms.target;
			int duration = Mathf.RoundToInt(this.def.durationDays.RandomInRange * 60000f);
			map.weatherManager.TransitionTo(FogWeather);
			return true;
		}
	}
}
