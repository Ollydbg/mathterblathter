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
		
		int ParentRoomId;
		Room ParentRoom;

		int NumWeapons {
            get {
                return this.context.targetActor.Attributes[ActorAttributes.ShopKeeperNumWeapons];
            }
        }
		int NumBuffs {
            get {
                return this.context.targetActor.Attributes[ActorAttributes.ShopKeeperNumBuffs];
            }
        }
		int NumItems {
            get {
                return this.context.targetActor.Attributes[ActorAttributes.ShopKeeperNumItems];
            }
        }
		int NumActiveItems {
            get {
                return this.context.targetActor.Attributes[ActorAttributes.ShopKeeperNumActiveItems];
            }
        }


		public override void Start ()
		{
			var allInShop = CharacterDataTable.GetAll().Where(p=>(p.Availability & Availability.InShop) == Availability.InShop && p.ActorType == ActorType.Pickup);
			var buffs = allInShop.Where( p=>p.PickupType == PickupType.Buff).ToList();
			var items = allInShop.Where( p=>p.PickupType == PickupType.Item).ToList();

			Game.Seed.TakeFromList(buffs, NumBuffs).ForEach(addItem);
			Game.Seed.TakeFromList(items, NumItems).ForEach(addItem);

			AddWeapons();
			AddActiveItems();

			this.Game.RoomManager.OnRoomEntered += OnRoomEntered;

			this.ParentRoom = this.Game.RoomManager.CurrentRoom;
			this.ParentRoomId = ParentRoom.Id;

		}

		
		private void AddActiveItems() {
			var allActive = CharacterDataTable.GetAll().Where(p=>(p.Availability & Availability.InShop) == Availability.InShop && p.ActorType == ActorType.ActiveItem);
			Game.Seed.TakeFromList(allActive.ToList(), NumActiveItems).ForEach(addItem);
		}

		private void AddWeapons() {
			var allWeapons = CharacterDataTable.GetAll().Where(p=>(p.Availability & Availability.InShop) == Availability.InShop && p.ActorType == ActorType.Weapon);
			Game.Seed.TakeFromList(allWeapons.ToList(), NumWeapons).ForEach(addItem);

		}

        private void OnRoomEntered(Actor actor, Room oldRoom, Room newRoom)
        {
			if(newRoom.Id != ParentRoomId)
        		playerLeftShop = true;
		}

        int index = 0;
		void addItem(CharacterData data) {
			context.source.Attributes[ActorAttributes.ShopkeeperInventory, index] = data.Id;
			index++;
		}

        bool playerLeftShop;

        public override bool IsComplete ()
		{
			return playerLeftShop;	
		}

		#region implemented abstract members of AbilityBase

		public override void Update (float dt)
		{
			
		}

		bool didEnd = false;
		public override void End ()
		{
			if(!didEnd) {
				didEnd = true;
				var signData = CharacterDataTable.FromId(context.data.spawnableDataId);
				this.Game.ActorManager.Spawn(signData);
				
				var newFlags = ParentRoom.Type & ~RoomType.Store;
				Game.RoomManager.ModifyRoomType(ParentRoom, newFlags);

				//also remove parent!
				context.source.Destroy();

	            UI.EventLog.Post("See you later");
			}
		}
		

		#endregion
	}
}

