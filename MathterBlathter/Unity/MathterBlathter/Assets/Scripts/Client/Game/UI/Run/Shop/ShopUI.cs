using System;
using UnityEngine;
using UnityEngine.UI;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Utils;
using Client.Game.UI.Run.Shop;
using System.Collections.Generic;
using Client.Game.Data;

namespace Client.Game.UI.Run.Shop
{
	public class ShopUI : RunUI
	{
		public ShopUI ()
		{
			
		}

		List<ShopItem> Items = new List<ShopItem>();

		#region implemented abstract members of RunUI
		public ShopItem Template;

		private Vector3 ItemOrigin {
			get {
				return new Vector3(Template.transform.position.x, Template.transform.position.y, Template.transform.position.z);
			}
		}

		void Awake() {
			Game.UIManager.ShopUI = this;
			Template.gameObject.SetActive(false);

			Hide();
		}

		void ShowInventory (NPC owner)
		{
			Clean();

			int index = 0;
		
			foreach( var dataId in ActorUtils.IterateAttributes(owner, ActorAttributes.ShopkeeperInventory)) {
				var item = (GameObject)GameObject.Instantiate(Template.gameObject, Template.transform.position, Template.transform.rotation);
				item.SetActive(true);
				item.transform.SetParent(Template.transform.parent, false);
				var itemComp = item.GetComponent<ShopItem>();
				var data = MockActorData.FromId(dataId);
				itemComp.InitWith(data);

				itemComp.OnBuy += () => {
					BuyItem(data, owner, Game.PossessedActor);
					ShowInventory(owner);
				};

				var pos = ItemOrigin;
				pos.x += 100 * index;

				itemComp.transform.position = pos;

				Items.Add(itemComp);

				index++;
			}
		}

		public void BuyItem(CharacterData data, Actor fromActor, Actor toActor) {

			List<int> keeperIds = ActorUtils.IterateAttributes(fromActor, ActorAttributes.ShopkeeperInventory);
			keeperIds.Remove(data.Id);
			ActorUtils.SetDataIdAttributes(fromActor, ActorAttributes.ShopkeeperInventory, keeperIds);

			var actor = Game.ActorManager.Spawn(data);

			float rangeX = Game.Seed.InRange(-5, 5);

			Vector3 sellerPos = fromActor.transform.position;

			actor.transform.position = new Vector3(sellerPos.x + rangeX, sellerPos.y + 1f, sellerPos.z);

		}

		void Clean ()
		{
			Items.ForEach(p => GameObject.Destroy(p.gameObject));
			Items.Clear();
		}

		public void ShowWithKeeper(NPC owner) {
			Toggle();
			if(this.gameObject.activeInHierarchy)
				ShowInventory(owner);
		}

		public void Toggle() {
			if(gameObject.activeInHierarchy) 
				Hide();
			else 
				Show();
		}

		public override void Show ()
		{
			this.gameObject.SetActive(true);
		}

		public override void Hide ()
		{

			Clean();
			this.gameObject.SetActive(false);
		}

		#endregion


	}

}

