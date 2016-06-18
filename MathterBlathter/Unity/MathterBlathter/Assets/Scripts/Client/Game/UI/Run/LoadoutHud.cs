using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Client.Game.Items;
using Client.Game.Data;
using Client.Game.Actors;
using Client.Game.Attributes;
using System.Linq;

namespace Client.Game.UI.Run
{
	
	public class LoadoutHud : RunUI
	{


		private Dictionary<LoadoutHudItem, WeaponActor> Items = new Dictionary<LoadoutHudItem, WeaponActor>();
		public LoadoutHudItem Template;

		public WeaponController weaponController;

		public static Vector3 SPACING = Vector3.right*100;
		public void Start ()
		{
			weaponController = Game.PossessedActor.WeaponController;
			weaponController.OnLoadoutChanged += Rebuild;

			Template.gameObject.SetActive(false);

			Rebuild(weaponController.currentWeapon, weaponController.ActiveLookup);
		}

		public void Update() {
			foreach( var kvp in Items ) {
				var charges = kvp.Value.Attributes[ActorAttributes.Charges]; 
				if(charges > 0) {
					kvp.Key.ChargesLabel.text = charges.ToString();
				}
			}
		}

		public void Rebuild(WeaponActor currentWeapon, Dictionary<CharacterData, WeaponActor> lookup)
		{
			Items.Keys.ToList().ForEach( p => GameObject.Destroy(p.gameObject));
			Items.Clear();

			int i = 0;
			foreach( var kvp in lookup) {
				var item = GameObject.Instantiate(Template.gameObject);
				var hudItem = item.GetComponent<LoadoutHudItem>();

				hudItem.Label.text = kvp.Key.Name;

				item.SetActive(true);

				if(kvp.Value != currentWeapon) {
					item.transform.localScale *= .8f;
				}
				item.transform.SetParent(Template.transform.parent);
				item.transform.position = Template.transform.position + SPACING * i;
				Items.Add(hudItem, kvp.Value);

				i++;
			}
		}

		#region implemented abstract members of RunUI

		public override void Show ()
		{
			throw new NotImplementedException ();
		}

		public override void Hide ()
		{
			throw new NotImplementedException ();
		}

		#endregion
	}


}

