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
		int numWeapons = 5;
		int numBuffs = 3;
		int numItems = 3;
		int numActiveItems = 1;

		public override void Start ()
		{
			var allInShop = CharacterDataTable.GetAll().Where(p=>(p.Availability & Availability.InShop) == Availability.InShop && p.ActorType == ActorType.Pickup);
			var buffs = allInShop.Where( p=>p.PickupType == PickupType.Buff).ToList();
			var items = allInShop.Where( p=>p.PickupType == PickupType.Item).ToList();

			Game.Seed.TakeFromList(buffs, numBuffs).ForEach(addItem);
			Game.Seed.TakeFromList(items, numItems).ForEach(addItem);

			AddWeapons();
			AddActiveItems();

			this.Game.RoomManager.OnRoomEntered += OnRoomEntered;

			this.ParentRoom = this.Game.RoomManager.CurrentRoom.Id;

		}

		
		private void AddActiveItems() {
			var allActive = CharacterDataTable.GetAll().Where(p=>(p.Availability & Availability.InShop) == Availability.InShop && p.ActorType == ActorType.ActiveItem);
			Game.Seed.TakeFromList(allActive.ToList(), numActiveItems).ForEach(addItem);
		}

		private void AddWeapons() {
			var allWeapons = CharacterDataTable.GetAll().Where(p=>(p.Availability & Availability.InShop) == Availability.InShop && p.ActorType == ActorType.Weapon);
			Game.Seed.TakeFromList(allWeapons.ToList(), numWeapons).ForEach(addItem);

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
			var signData = CharacterDataTable.FromId(context.data.spawnableDataId);
			this.Game.ActorManager.Spawn(signData);
			
			//also remove parent!
			context.source.Destroy();

            UI.EventLog.Post("See you later");
		}
		

		#endregion
	}
}

