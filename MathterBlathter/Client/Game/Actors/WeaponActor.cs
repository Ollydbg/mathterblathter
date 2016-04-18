using System;
using Client.Game.Data;

namespace Client.Game.Actors
{
	public class WeaponActor : Actor
	{
		public WeaponActor ()
		{
		}


		public override ActorType ActorType {
			get {
				return Data.ActorType;
			}
		}

	}
}

