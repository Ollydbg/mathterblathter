using System;
using Client.Game.Attributes;
using Client.Game.Data;
using UnityEngine;
using System.Linq;

namespace Client.Game.Abilities.Scripts
{
	public class ShopkeeperBuff : BuffBase
	{
		public ShopkeeperBuff ()
		{
			
		}

		public override void Start ()
		{
			var allInShop = MockActorData.GetAll().Where(p=>(p.Availability & Availability.InShop) == Availability.InShop);
			foreach( var item in allInShop)
				addItem(item);

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

