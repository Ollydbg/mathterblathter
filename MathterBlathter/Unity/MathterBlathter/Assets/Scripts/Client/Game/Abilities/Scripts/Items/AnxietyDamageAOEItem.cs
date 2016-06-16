using System;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;

namespace Client.Game.Abilities.Scripts.Items
{

	//Converts current anxiety to damage, multiplies it by some scalr, and applies to all current room enemies
	public class AnxietyDamageAOEItem : AbilityBase
	{
		public AnxietyDamageAOEItem ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{


			var currentAnxiety = context.source.Attributes[ActorAttributes.Anxiety];
			var scale = this.Attributes[AbilityAttributes.AnxietyToDamageScalar];

			var dmg = currentAnxiety * scale;
			var roomActors = Game.RoomManager.CurrentRoom.Waves.AliveActors;
			foreach( var actor in roomActors) {
				
				new DamagePayload(this.context, actor, dmg).Apply();
			
			}
			
			
			//set to 0
			context.source.Attributes[ActorAttributes.Anxiety] = 0;
		}

		public override void Update (float dt)
		{
			
		}

		public override void End ()
		{
			
		}

		#endregion
	}
}

