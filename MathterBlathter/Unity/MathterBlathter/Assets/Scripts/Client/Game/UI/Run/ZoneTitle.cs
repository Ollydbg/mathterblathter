using System.Collections;
using Client.Game.Data;
using UnityEngine;
using UnityEngine.UI;
namespace Client.Game.UI.Run
{
    public class ZoneTitle : RunUI
	{
		
		private int currentZoneId = -1;
		public Text UIText;
		public Text NowEntering;
		public Text PopulationText;
		public Text ElevationText;
		
		public ZoneTitle ()
		{
			
		}
		
		void Start() {
			CheckZoneChanged();
			Game.RoomManager.OnRoomEntered += (actor, oldRoom, newRoom) => CheckZoneChanged();
		}

        private void CheckZoneChanged()
        {
			var currentZone = Game.RoomManager.CurrentRoom.Zone;
			if(currentZone.Id != currentZoneId) {
				currentZoneId = currentZone.Id;
				ShowTitle(currentZone);
			}
        }

        private void ShowTitle(ZoneData zone)
        {
			UIText.text = zone.Name.ToUpper();
			PopulationText.text = string.Format("District Warden: {0}", "Prophet-5");
			
			this.StartCoroutine(ShowThenHide());
						
        }

        private IEnumerator ShowThenHide()
        {
			UIText.CrossFadeAlpha(1f, 1f, false);
			PopulationText.CrossFadeAlpha(1f, 1f, false);
			NowEntering.CrossFadeAlpha(1f, 1f, false);
			
			yield return new WaitForSeconds(2f);
			
			UIText.CrossFadeAlpha(0f, 1f, false);
			PopulationText.CrossFadeAlpha(0f, 1f, false);
			NowEntering.CrossFadeAlpha(0f, 1f, false);
			
        }

      
        public override void Show ()
		{
		}

		public override void Hide ()
		{
		}

		

	}
}

