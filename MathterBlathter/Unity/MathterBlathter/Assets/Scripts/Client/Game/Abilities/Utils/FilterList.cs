using System;
using Client.Game.Actors;
using System.Collections.Generic;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Utils
{
	public class FilterList : List<Client.Game.Abilities.Utils.FilterList.Filter>
	{
		public delegate bool Filter(AbilityContext ctx, Actor actor);

		public FilterList (params Filter[] filters)
		{
			AddRange(filters);
		}

		public bool Check(AbilityContext ctx, Actor actor) {
			foreach (var filter in this) {
				if(!filter (ctx, actor))
					return false;

			}

			return true;
		}

		public static FilterList QuickFilters {
			get {
				return new FilterList(Filters.NotSelfFilter, Filters.Hittable, Filters.NotPendingDelete);
			}
		}



	}

	public static class Filters {
		public static bool NotSelfFilter(AbilityContext ctx, Actor actor) {
			return actor.Id != ctx.source.Id;
		}

		public static bool IsProjectile(AbilityContext ctx, Actor actor) {
			return actor.ActorType == Client.Game.Data.ActorType.Projectile;
		}
		public static bool Hittable(AbilityContext ctx, Actor actor) {
			return actor.Attributes[ActorAttributes.TakesDamage] == true;
		}

		public static bool NotPendingDelete(AbilityContext ctx, Actor actor) {
			return !actor.Destroyed;
		}
	}

}

