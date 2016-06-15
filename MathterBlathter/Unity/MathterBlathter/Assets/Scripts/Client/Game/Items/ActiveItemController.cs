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


		public void UseCurrent () {
			/*var itemId = Owner.Attributes[ActorAttributes.ActiveItemId];
			var itemData = CharacterDataTable.FromId(itemId);

			var context = new AbilityContext(Owner,  AbilityDataTable.FromId(abilityId));
			Owner.Game.AbilityManager.ActivateAbility (context);*/
		}

	}

}

