using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Data;
using UnityEngine;
using Client.Game.Enums;
using System.Collections.Generic;
using Client.Game.Abilities;
using Client.Game.Utils;
using Client.Game.Abilities.Utils;
using Client.Game.Abilities.Payloads;

namespace Client.Game.Items
{
	using WeaponLookup = Dictionary<CharacterData, WeaponActor>;

	public class WeaponController
	{
		Actor Owner;

		public WeaponLookup ActiveLookup = new WeaponLookup();
		public WeaponActor currentWeapon;

		public delegate void ChangedDelegate(WeaponActor currentWeapon, WeaponLookup all);
		public event ChangedDelegate OnLoadoutChanged;
		public TargetingProps TargetingProps = new TargetingProps();
		public Vector3 WeaponForward = Vector3.back;

		public WeaponController (Actor owner)
		{
			this.Owner = owner;
			for( int i = 0; i< ActorAttributes.Weapons.MaxValue; i++ ) {
				int id = Owner.Attributes[ActorAttributes.Weapons, i];
				if(id == ActorAttributes.Weapons.DefaultValue) {
					break;
				} else {
					AddWeapon(CharacterDataTable.FromId(id));
				}
			}
		}


		public void Destroy() {
			foreach( var wpn in ActiveLookup.Values) {
				if(!wpn.Destroyed) {
					wpn.Destroy();
				}
				
			}
		}

		public void ToggleWeapon() {
			
			var notCurrent = NotCurrent;
			if(notCurrent != null) {
				SwitchWeapon(notCurrent);
			}

		}

		public WeaponActor NotCurrent {
			get {
				foreach( var weapon in ActiveLookup.Values) {
					if(currentWeapon != weapon) {
						return weapon;
					}
				}
				return null;
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
			broadcast();
		}


		public void RemoveWeapon(WeaponActor wpn) {
			ActiveLookup.Remove(wpn.Data);
			wpn.transform.parent = null;

			foreach( var item in ActiveLookup) {
				SwitchWeapon(item.Value);
				break;
			}

			broadcast();
		}

		//called from pickup payload
		public void AddWeapon(CharacterData data) {
			if(CanAdd(data)) {
				
				var spawnedActor = Owner.Game.ActorManager.Spawn<WeaponActor>(data);
				ActorUtils.PropogateBuffs(spawnedActor, Owner);
				AddWeapon(spawnedActor);

			}
		}

		//called internally, and by weapon actor self-add
		public void AddWeapon(WeaponActor actor) {
			if(ActiveLookup.Count == Owner.Attributes[ActorAttributes.MaxWeapons])
				RemoveWeapon(currentWeapon);
			
			actor.transform.parent = GetAttachTransform(AttachPoint.WeaponSlot);
			actor.transform.localPosition = WeaponForward;
			

			ActiveLookup.Add(actor.Data, actor);
			Owner.Attributes[ActorAttributes.WeaponCount]++;

			Owner.Attributes[ActorAttributes.Weapons, 0] = actor.Data.Id;
			Owner.Attributes[ActorAttributes.CurrentWeaponIndex] = 0;

			SwitchWeapon(actor);

			broadcast();

		}

		private bool CanAdd(CharacterData data) {
			//for now just do this, TODO: actual weapon type checks
			return !ActiveLookup.ContainsKey(data);
		}
	

		private void broadcast() {
			if(OnLoadoutChanged != null) {
				OnLoadoutChanged(currentWeapon, ActiveLookup);
			}
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
			var aimDirection = GetAimDirection();
			var angle = Vector3.Angle(GetAimDirection(), Vector3.right);

			if(aimDirection.y < 0) 
				angle *= -1f;

			if(Mathf.Abs(angle) > 90) {
				Owner.FaceLeft();
				//because weapon is parented to the left facing transform, we have to compensate in the rotation
				angle = 180 - angle;
			} else {
				Owner.FaceRight();
			}

			currentWeapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}



		public Vector3 GetAimDirection() {

			if(TargetingProps.Direction == Vector3.zero) {
				return getMousingDirection();
			} else {
				return TargetingProps.Direction;
			}
		}

		private Vector3 getMousingDirection() {
			var weaponPos = Camera.main.WorldToScreenPoint(currentWeapon.transform.position);

			var worldDir3 = Input.mousePosition - weaponPos;
			return new Vector3(worldDir3.x, worldDir3.y).normalized;
		}

		public bool CanAttack(WeaponActor actor) {
			var cooldown = currentWeapon.Attributes[ActorAttributes.Cooldown] * Owner.Attributes[ActorAttributes.WeaponCooldownScalar];
			float elapsed =  Time.realtimeSinceStartup - currentWeapon.Attributes[ActorAttributes.LastFiredTime];

			return elapsed >= cooldown;
		}


		public void AimDirection(Vector3 aimVector) {
			this.TargetingProps.Direction = aimVector;
		}

		public void AttackStop ()
		{
			currentWeapon.AttackStop();
		}

		public void Attack () {
			if(currentWeapon != null) 
				Attack(GetAimDirection());
		}

		public void Attack(Vector3 direction) {
			if(CanAttack(currentWeapon)) {
				var abilityId = currentWeapon.Attributes[ActorAttributes.Abilities, 0];
				var context = new AbilityContext(Owner, currentWeapon, direction, AbilityDataTable.FromId(abilityId));

				new WeaponFirePayload(context, currentWeapon).Apply();

			}
		}
		

	}

	public class TargetingProps {
		public Vector3 Direction;
		public Vector3 EndPoint;
	}
}

