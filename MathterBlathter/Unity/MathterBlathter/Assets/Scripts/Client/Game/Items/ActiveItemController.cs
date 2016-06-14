using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Data;
using Client.Game.Abilities;

namespace Client.Game.Items
{

    public class ActiveItemController
	{
		Actor Owner;

		public ActiveItemController (Actor owner)
		{
			this.Owner = owner;
		}



		public void AddItem(CharacterData data) {
			Owner.Attributes[ActorAttributes.ActiveItemId] = data.Id;
		}



		public void Update (float dt)
		{
			
		}

		public bool CanUseCurrent() {
			return true;
		}


		public void Use () {
			var abilityId = Owner.Attributes[ActorAttributes.ActiveItemId];
			var context = new AbilityContext(Owner,  MockAbilityData.FromId(abilityId));
			Owner.Game.AbilityManager.ActivateAbility (context);
			
		}

	}

}

