using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Data;
using UnityEngine;
using Client.Game.Enums;
using System.Collections.Generic;
using Client.Game.Abilities;

namespace Client.Game.Items
{
	public class WeaponController
	{
		Character Owner;

		Dictionary<CharacterData, WeaponActor> ActiveLookup = new Dictionary<CharacterData, WeaponActor>();
		public WeaponActor currentWeapon;

		public WeaponController (Character owner)
		{
			this.Owner = owner;

			for( int i = 0; i< ActorAttributes.Weapons.MaxValue; i++ ) {
				int id = Owner.Attributes[ActorAttributes.Weapons, i];
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

		public void Aim(Vector3 aim) {

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

		private Vector3 getMousingDirection() {
			var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var worldDir3 = worldPoint - currentWeapon.transform.position;
			return new Vector3(worldDir3.x, worldDir3.y).normalized;
		}

		public void AttackStart () {
			var abilityId = currentWeapon.Attributes[ActorAttributes.Abilities];
			var direction = getMousingDirection();

			Owner.Game.AbilityManager.ActivateAbility (new AbilityContext(Owner, direction, MockAbilityData.FromId(abilityId)));
		}


		public void AttackComplete() {
			
		}
	}
}

