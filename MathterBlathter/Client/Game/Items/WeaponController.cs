using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Data;
using UnityEngine;
using Client.Game.Enums;
using System.Collections.Generic;

namespace Client.Game.Items
{
	public class WeaponController
	{
		Actor Owner;

		Dictionary<CharacterData, WeaponActor> ActiveLookup = new Dictionary<CharacterData, WeaponActor>();
		public WeaponActor currentWeapon;

		public WeaponController (Actor owner)
		{
			this.Owner = owner;

			for( int i = 0; i< ActorAttributes.Weapons.MaxValue; i++ ) {
				int id = Owner.Attributes[ActorAttributes.Weapons, i];
				Debug.Log(id);
				if(id == ActorAttributes.Weapons.DefaultValue) {
					break;
				} else {
					AddWeapon(MockWeaponData.FromId(id));
				}
			}
		}

		public void ToggleWeapon() {
			foreach( var weapon in ActiveLookup.Values) {
				if(currentWeapon != weapon) {
					SwitchWeapon(weapon);
					return;
				}
			}
		}

		public void SwitchWeapon (WeaponActor toWeapon)
		{
			foreach( var weapon in ActiveLookup.Values) {
				if(weapon.Id != toWeapon.Id) {
					weapon.GameObject.SetActive(false);
				} 
			}
			currentWeapon = toWeapon;
			toWeapon.GameObject.SetActive(true);
		}

		public void AddWeapon(CharacterData data) {
			var spawnedActor = Owner.Game.ActorManager.Spawn<WeaponActor>(data);

			spawnedActor.transform.parent = GetAttachTransform(AttachPoint.Arm);
			spawnedActor.transform.localPosition = Vector3.zero;
			ActiveLookup.Add(data, spawnedActor);
			Owner.Attributes[ActorAttributes.WeaponCount]++;
			
			Owner.Attributes[ActorAttributes.Weapons, 0] = data.Id;
			Owner.Attributes[ActorAttributes.CurrentWeaponIndex] = 0;

			SwitchWeapon(spawnedActor);

		}

		private Transform GetAttachTransform(AttachPoint pt) {
			foreach( var ap in Owner.GameObject.GetComponentsInChildren<AttachPointComponent>()) {
				if(ap.Type == pt) {
					return ap.transform; 
				}
			}
			return Owner.transform;
		}

		public void Update (float dt)
		{
			
		}
	}
}

