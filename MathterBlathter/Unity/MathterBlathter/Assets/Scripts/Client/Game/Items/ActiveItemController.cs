using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Data;
using Client.Game.Abilities;

namespace Client.Game.Items
{

    public class ActiveItemController
	{
		Actor Owner; 

		public CharacterData CurrentItem;
		private AbilityData CurrentAbility;

		public ActiveItemController (Actor owner)
		{
			this.Owner = owner;
		}



		public void AddItem(CharacterData data) {
			CurrentItem = data;


			Owner.Attributes[ActorAttributes.ActiveItemId] = data.Id;

			var map = new AttributeMap(data.attributeData);
			CurrentAbility = AbilityDataTable.FromId(map[ActorAttributes.Abilities, 0]);


		}



		public void Update (float dt)
		{
			
		}

		public bool CanUseCurrent() {
			return true;
		}


		public void UseCurrent () {
			var context = new AbilityContext(Owner, CurrentAbility);
			Owner.Game.AbilityManager.ActivateAbility (context);
		}

	}

}

