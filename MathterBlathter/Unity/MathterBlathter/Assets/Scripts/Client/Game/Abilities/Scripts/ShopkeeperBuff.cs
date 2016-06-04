using System;
using Client.Game.Attributes;
using Client.Game.Data;
using UnityEngine;
using System.Linq;
using Client.Game.Managers;
using Client.Game.Actors;
using Client.Game.Map;

namespace Client.Game.Abilities.Scripts
{
	public class ShopkeeperBuff : BuffBase
	{
		public ShopkeeperBuff ()
		{
			
		}
		
		int ParentRoom;

		public override void Start ()
		{
			var allInShop = MockActorData.GetAll().Where(p=>(p.Availability & Availability.InShop) == Availability.InShop);
			foreach( var item in allInShop)
				addItem(item);
				
			
			this.Game.RoomManager.OnRoomEntered += OnRoomEntered;

			this.ParentRoom = this.Game.RoomManager.CurrentRoom.Id;

		}

        private void OnRoomEntered(Actor actor, Room oldRoom, Room newRoom)
        {
			if(newRoom.Id != ParentRoom)
        		playerLeftShop = true;
		}

        int index = 0;
		void addItem(CharacterData data) {
			context.source.Attributes[ActorAttributes.ShopkeeperInventory, index] = data.Id;
			index++;
		}

        bool playerLeftShop;

        public override bool isComplete ()
		{
			return playerLeftShop;	
		}

		#region implemented abstract members of AbilityBase

		public override void Update (float dt)
		{
			
		}

		public override void End ()
		{
			var signData = MockActorData.FromId(context.data.spawnableDataId);
			this.Game.ActorManager.Spawn(signData);
			
			//also remove parent!
			context.source.Destroy();
		}
		

		#endregion
	}
}

