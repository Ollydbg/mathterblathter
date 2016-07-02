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
		Transform Player;
		bool wasCombat = false;
		bool isCombat {
			get {
				return !Game.RoomManager.CurrentRoom.Waves.IsComplete;
			}
		}

		void Start() {
			Game.RoomManager.OnRoomEntered += OnRoomEntered;
			Game.RoomManager.OnCurrentRoomUnlocked += OnRoomUnlocked;
			
			Player = Game.PossessedActor.transform;

			ThreatTemplate.SetActive(false);
			ObjectiveTemplate.SetActive(false);

			//invoke manually, since we get intanced late
			OnRoomEntered(Game.PossessedActor, null, Game.RoomManager.CurrentRoom);
					
		}

		void OnActorEntered ()
		{
			diffRoomState(force:true);
		}

        private void OnRoomUnlocked(Room room)
        {
			Game.RoomManager.CurrentRoom.Waves.OnActorEntered -= OnActorEntered;
        }

		void closestRoomTypePosition(RoomType type, List<Vector3> addToList) {
			
			var list = Game.RoomManager.RoomsOfType(type);
			var position = Game.PossessedActor.transform.position;
			float closestDistance = float.MaxValue;
			Room closestRoom = null;

			foreach( var room in list ) {
				var test = room.roomCenter - position;
				var testDistance = test.sqrMagnitude;
				if(testDistance < closestDistance) {
					closestRoom = room;
					closestDistance = testDistance; 
				}
			}

			if(closestRoom != null)
				addToList.Add(closestRoom.roomCenter);
			
		}


        void Cleanup() {
			if(indicators != null) {
				foreach( var go in indicators.Values)
					GameObject.Destroy(go);
			}
			
			indicators = new Dictionary<ObjectiveWrapper, GameObject>();
		}


		void diffRoomState(bool force) {
			var combat = isCombat;


			if(combat && (!wasCombat || force)) {
				Cleanup();
				foreach(var obj in Game.RoomManager.CurrentRoom.Waves.AliveActors) {
					var wrapper = new ObjectiveWrapper(obj);
					if(!indicators.ContainsKey(wrapper)) {
						obj.OnDestroyed += HandleActorDeath;
						SpawnForObject(wrapper);
					}
				}
			} else if ( !isCombat && (wasCombat || force)) {
				Cleanup();
				var zoneObjectives = new List<Vector3>();
				closestRoomTypePosition(RoomType.Store, zoneObjectives);
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
			Game.RoomManager.CurrentRoom.Waves.OnActorEntered += OnActorEntered;
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
			
			diffRoomState(force:false);
			
			foreach( var kvp in indicators) {
				var item = kvp.Value;
				var actor = kvp.Key;

				var screenPoint = Camera.main.WorldToScreenPoint(actor.Position);
				if(TryConstrainToScreen(screenPoint, out constrained)) {
					item.SetActive(true);

					item.transform.position = constrained;
					item.transform.rotation = PointToPosition(actor.Position);
				} else {
					item.SetActive(false);
				}
			}
		}

		bool TryConstrainToScreen (Vector3 point, out Vector3 constrained)
		{

			constrained = new Vector3(point.x, point.y, 0f);
			constrained.x = Mathf.Clamp(constrained.x, 0, Screen.width);
			constrained.y = Mathf.Clamp(constrained.y, 0, Screen.height);
		
			return constrained.x != point.x || constrained.y != point.y;
		}


		Quaternion PointToPosition (Vector3 screenPoint)
		{
			var direction = screenPoint - Player.position;
			var angle = Vector3.Angle(Vector3.right, screenPoint - Player.position);
			if(direction.y < 0) {
				angle *= -1f;
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

