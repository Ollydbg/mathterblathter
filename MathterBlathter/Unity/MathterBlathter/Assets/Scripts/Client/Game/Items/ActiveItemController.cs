using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Data;
using Client.Game.Abilities;
using UnityEngine;

namespace Client.Game.Items
{

    public class ActiveItemController
	{
		Actor Owner; 

		public delegate void ItemAdded(CharacterData data);
		public event ItemAdded OnItemAdded;
		public ActiveItem CurrentItem;

		public ActiveItemController (Actor owner)
		{
			this.Owner = owner;
		}



		public void AddItem(CharacterData data) {
			
			CurrentItem = new ActiveItem(data, Owner);
			Owner.Attributes[ActorAttributes.ActiveItemId] = data.Id;


			if(OnItemAdded != null) {
				OnItemAdded(data);
			}

		}



		public void Update (float dt)
		{
			
		}

		public bool CanUseCurrent() {
			var cooldown = CurrentItem.UsableAt;
			float elapsed =  Time.realtimeSinceStartup - Owner.Attributes[ActorAttributes.LastFiredTime, CurrentItem.ItemData.Id];
			return elapsed >= cooldown;
		}


		public void UseCurrent () {
			if(CanUseCurrent()) {
				var context = new AbilityContext(Owner, CurrentItem.AbilityData);
				Owner.Game.AbilityManager.ActivateAbility (context);
				Owner.Attributes[ActorAttributes.LastFiredTime, CurrentItem.ItemData.Id] = Time.realtimeSinceStartup;	
			}
		}

	}
	
	public class ActiveItem {
		public CharacterData ItemData;
		public AbilityData AbilityData;
		public AttributeMap Attributes;
		Actor Owner;

		public float UsableAt {
			get {
				return Attributes[ActorAttributes.WeaponCooldown] * Owner.Attributes[ActorAttributes.ItemCooldownScalar];
			}
		}

		public ActiveItem(CharacterData data, Actor owner) {
			ItemData = data;
			Owner = owner;
			Attributes = new AttributeMap(data.attributeData);
			AbilityData = AbilityDataTable.FromId(Attributes[ActorAttributes.Abilities, 0]);

		}
	}
			
}

