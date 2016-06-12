using System;
using UnityEngine;
using Client.Game.Map;
using Client.Game.Actors;
using System.Collections.Generic;
using Client.Game.Data;

namespace Client.Game.UI.Run.Indicators
{
	using Game = Client.Game.Core.Game;

	public class Indicators : RunUI
	{

		public Dictionary<ObjectiveWrapper, GameObject> indicators;

		public GameObject ThreatTemplate;
		public GameObject ObjectiveTemplate;
		Transform playerTransform;
		bool wasCombat = false;
		bool isCombat {
			get {
				return !Game.RoomManager.CurrentRoom.Waves.IsComplete;
			}
		}

		void Start() {
			Game.RoomManager.OnRoomEntered += OnRoomEntered;
			Game.RoomManager.OnCurrentRoomUnlocked += OnRoomUnlocked;
			
			playerTransform = Game.PossessedActor.transform;

			ThreatTemplate.SetActive(false);
			ObjectiveTemplate.SetActive(false);

			//invoke manually, since we get intanced late
			OnRoomEntered(Game.PossessedActor, null, Game.RoomManager.CurrentRoom);
					
		}

        private void OnRoomUnlocked(Room room)
        {
			
        }

		Vector3 closestRoomTypePosition(RoomType type) {
			
			var list = Game.RoomManager.RoomsOfType(type);
			var position = Game.PossessedActor.transform.position;
			Vector3 closest = Vector3.one * float.MaxValue;
			float closestDistance = float.MaxValue;
			Room closestRoom = null;

			foreach( var room in list ) {
				var test = room.roomCenter - position;
				var testDistance = test.sqrMagnitude;
				if(testDistance < closestDistance) {
					closest = test;
					closestRoom = room;
					closestDistance = testDistance; 
				}
			}

			return closestRoom.roomCenter;
			
		}


        void Cleanup() {
			if(indicators != null) {
				foreach( var go in indicators.Values)
					GameObject.Destroy(go);
			}
			
			indicators = new Dictionary<ObjectiveWrapper, GameObject>();
		}


		void diffIndicators() {
			var combat = isCombat;
			if(combat && !wasCombat) {
				Cleanup();
				foreach(var obj in Game.RoomManager.CurrentRoom.Waves.AliveActors) {
					var wrapper = new ObjectiveWrapper(obj);
					if(!indicators.ContainsKey(wrapper)) {
						obj.OnDestroyed += HandleActorDeath;
						SpawnForObject(wrapper);
					}
				}
			} else if ( !isCombat && wasCombat) {
				Cleanup();
				var zoneObjectives = new List<Vector3>();
				zoneObjectives.Add(closestRoomTypePosition(RoomType.Store));
				foreach(var obj in zoneObjectives) {
					var wrapper = new ObjectiveWrapper(obj);
					if(!indicators.ContainsKey(wrapper)) {
						SpawnForObject(wrapper);
					}
				}
			}

			wasCombat = combat;

			
		}

		void OnRoomEntered (Actor actor, Room oldRoom, Room newRoom)
		{
			//Cleanup();
		}
		
		private void SpawnForObject(ObjectiveWrapper obj) {
			var template = obj.Threat ? ThreatTemplate : ObjectiveTemplate;
			
			var indicator = GameObject.Instantiate(template, template.transform.position, template.transform.rotation) as GameObject;
			indicator.SetActive(true);
			indicator.transform.SetParent(this.transform, false);
			indicator.transform.position = template.transform.position;
			indicators[obj] = indicator;
		}

		void HandleActorDeath (Actor actor)
		{
			GameObject indicator;
			var wrapper = new ObjectiveWrapper(actor);
			if(indicators.TryGetValue(wrapper, out indicator)) {
				GameObject.Destroy(indicator);
				this.indicators.Remove(wrapper);
			}
		}
		

		Vector3 constrained = Vector3.zero;
		void Update() {
			
			diffIndicators();
			
			foreach( var kvp in indicators) {
				var item = kvp.Value;
				var actor = kvp.Key;

				var screenPoint = Camera.main.WorldToScreenPoint(actor.Position);
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

		public struct ObjectiveWrapper {
            public bool Threat { get{ return actor != null;} }

            private Actor actor;
			private Vector3 position;

			public ObjectiveWrapper(Actor inActor) { this.actor = inActor; position = Vector3.zero; }
			public ObjectiveWrapper(Vector3 position) { this.position = position; actor = null; }

			public override int GetHashCode() {
				if(actor != null)
					return actor.GetHashCode();
				else 
					return position.GetHashCode();
			}

			public Vector3 Position {
				get {
					if(actor == null) {
						return position;
					} else {
						return actor.HalfHeight;
					}
				}
			}

		}

	}
}

