using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Client.Game.Items;
using Client.Game.Data;
using Client.Game.Actors;

namespace Client.Game.UI.Run
{
	
	public class LoadoutHud : RunUI
	{


		private List<GameObject> Items = new List<GameObject>();
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
			
		}

		public void Rebuild(WeaponActor currentWeapon, Dictionary<CharacterData, WeaponActor> lookup)
		{
			Items.ForEach( p => GameObject.Destroy(p));
			int i = 0;
			foreach( var kvp in lookup) {
				var item = GameObject.Instantiate(Template.gameObject);
				item.GetComponentInChildren<Text>().text = kvp.Key.Name;

				item.SetActive(true);

				if(kvp.Value != currentWeapon) {
					item.transform.localScale *= .8f;
				}
				item.transform.SetParent(Template.transform.parent);
				item.transform.position = Template.transform.position + SPACING * i;
				Items.Add(item);

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

