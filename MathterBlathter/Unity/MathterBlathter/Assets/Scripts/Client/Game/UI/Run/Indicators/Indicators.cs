using System;
using UnityEngine;
using Client.Game.Map;
using Client.Game.Actors;
using System.Collections.Generic;

namespace Client.Game.UI.Run.Indicators
{
	using Game = Client.Game.Core.Game;

	public class Indicators : RunUI
	{

		public Dictionary<Actor, GameObject> indicators;

		public GameObject Template;
		Transform playerTransform;

		void Start() {
			Game.RoomManager.OnRoomEntered += OnRoomEntered;
			Game.RoomManager.OnCurrentRoomUnlocked += OnRoomUnlocked;
			
			playerTransform = Game.PossessedActor.transform;

			Template.SetActive(false);

			//invoke manually, since we get intanced late
			OnRoomEntered(Game.PossessedActor, null, Game.RoomManager.CurrentRoom);
					
		}

        private void OnRoomUnlocked(Room room)
        {
			
        }

        void Cleanup() {
			indicators = new Dictionary<Actor, GameObject>();
		}

		void diffIndicators() {
			foreach(var obj in Game.RoomManager.CurrentRoom.Waves.AliveActors) {
				if(!indicators.ContainsKey(obj)) {
					obj.OnDestroyed += HandleActorDeath;
					SpawnForObject(obj);
				}
			}
		}

		void OnRoomEntered (Actor actor, Room oldRoom, Room newRoom)
		{
			Cleanup();
		}
		
		private void SpawnForObject(Actor obj) {

			var indicator = GameObject.Instantiate(Template, Template.transform.position, Template.transform.rotation) as GameObject;
			indicator.SetActive(true);
			indicator.transform.SetParent(this.transform, false);
			indicator.transform.position = Template.transform.position;
			indicators[obj] = indicator;
		}

		void HandleActorDeath (Actor actor)
		{
			GameObject indicator;
			if(indicators.TryGetValue(actor, out indicator)) {
				GameObject.Destroy(indicator);
				this.indicators.Remove(actor);
			}
		}
		

		Vector3 constrained = Vector3.zero;
		void Update() {
			
			diffIndicators();
			
			foreach( var kvp in indicators) {
				var item = kvp.Value;
				var actor = kvp.Key;

				var screenPoint = Camera.main.WorldToScreenPoint(actor.HalfHeight);
				if(TryConstrainToScreen(screenPoint, out constrained)) {
					item.SetActive(true);

					item.transform.position = constrained;
					item.transform.rotation = PointToPosition(constrained);
				} else {
					item.SetActive(false);

				}
			}
		}

		bool TryConstrainToScreen (Vector3 point, out Vector3 constrained)
		{

			constrained = new Vector3(point.x, point.y, point.z);
			constrained.x = Mathf.Clamp(constrained.x, 0, Screen.width);
			constrained.y = Mathf.Clamp(constrained.y, 0, Screen.height);
		
			return constrained.x != point.x || constrained.y != point.y;
		}


		Quaternion PointToPosition (Vector3 screenPoint)
		{
			float angle = 0f;
			if(screenPoint.x == 0f) {
				angle = -90;
			}
			if(screenPoint.x == Screen.width) {
				angle = 90;
			}

			if(screenPoint.y == 0f) {
				angle = 0;
			}
			if(screenPoint.y == Screen.height) {
				angle = 180;
			}

			return Quaternion.AngleAxis(angle, Vector3.forward);
		}


		public override void Show ()
		{
		}
		public override void Hide ()
		{
			
		}

	}
}

