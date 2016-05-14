using System;
using Client.Game.Attributes;
using Client.Game.Data;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class ShopkeeperBuff : BuffBase
	{
		public ShopkeeperBuff ()
		{
			
		}

		public override void Start ()
		{
			//add some items to the npc
			addItem(MockActorData.CURSED_RABBITS_FOOT);
			addItem(MockActorData.CERAMIC_SHOTGUN);
			addItem(MockActorData.HEALTH_PICKUP);
			addItem(MockActorData.ROCKET_LAUNCHER);
		}
		
		int index = 0;
		void addItem(CharacterData data) {
			context.source.Attributes[ActorAttributes.ShopkeeperInventory, index] = data.Id;
			index++;
		}


		public override bool isComplete ()
		{
			return true;	
		}

		#region implemented abstract members of AbilityBase

		public override void Update (float dt)
		{
		}

		public override void End ()
		{
		}

		

		#endregion
	}
}

