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

		List<ShopItem> Items;

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
			int index = 0;
			foreach( var dataId in ActorUtils.IterateAttributes(owner, ActorAttributes.ShopkeeperInventory)) {
				var item = (GameObject)GameObject.Instantiate(Template.gameObject, Template.transform.position, Template.transform.rotation);
				item.SetActive(true);
				item.transform.SetParent(Template.transform.parent, false);
				var itemComp = item.GetComponent<ShopItem>();
				itemComp.InitWith(MockActorData.FromId(dataId));

				var pos = ItemOrigin;
				pos.x += 100 * index;

				itemComp.transform.position = pos;

				index++;
			}
		}

		void Clean ()
		{
			
		}

		public void ShowWithKeeper(NPC owner) {
			Show();
			
			ShowInventory(owner);
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

