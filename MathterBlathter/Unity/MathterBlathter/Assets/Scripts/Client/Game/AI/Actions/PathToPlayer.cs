using System;
using Client.Game.Actors;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Attributes;

namespace Client.Game.AI.Actions
{
	
	public class PathToPlayer : AIAction {

		PathingAgent Agent;
		float repathAccum = 0f;
		public const float REPATH_DELAY = 1.5f;

		Actor Self;

		public override void Start (Actor selfActor)
		{
			this.Self = selfActor;

			Repath();
		}

		void Repath() {
			Agent = new PathingAgent(CurrentRoom.Grid.SearchPath(Self.transform.position, PlayerMid));
			repathAccum = 0f;

			Agent.OnPathAdvance += () => {
				if(repathAccum >= REPATH_DELAY) 
					Repath();
				};

		}
		

		public override AIResult Update (float dt, Actor actor)
		{
			
			repathAccum += dt;

			Agent.TryMove(actor.GameObject, actor.Attributes[ActorAttributes.Speed] * dt);

			if(ActionUtil.HasLOS(actor, PlayerMid)) {
				return AIResult.Success;
			}


			return AIResult.Running;

		}

	}

	public class PathingAgent {
		
		Vector3[] PathNodes;
		int index = 0;
		public Action OnPathAdvance;
		public Vector3 CurrentNode {
			get {
				return PathNodes[index];
			}
		}



		public PathingAgent(Vector3[] nodes) {
			this.PathNodes = nodes;
			index = 0;

			/*
			for(int i = 0; i< nodes.Length; i++ ) {
				var node = nodes[i];
				
				var color = i == nodes.Length -1? Color.red : Color.magenta;
				if( i == 0 )
					color = Color.green;
				
				Debug.DrawRay(node, Vector3.back * 3f, color, 2f);
			}*/
		}

		bool ConsumeDistance(Vector3 from, float moveMag, out Vector3 newPosition) {
			var moveMagSq = moveMag * moveMag;
			var distanceVec = CurrentNode - from;

			if(distanceVec.sqrMagnitude < moveMagSq) {
				moveMag -= distanceVec.magnitude;
				var newFrom = CurrentNode;

				if(index == PathNodes.Length - 1) {
					newPosition = Vector3.zero;
					return false;
				}

				Advance();

				return ConsumeDistance(newFrom, moveMag, out newPosition);
			} else {
				newPosition = from + distanceVec.normalized * moveMag;
			}

			return true;
		}

		void Advance() {
			index++;
			if(OnPathAdvance != null) 
				OnPathAdvance();
		}

		
		public bool TryMove(GameObject obj, float moveAmount) {

			if(PathNodes.Length == 0) {
				return false;
			}

			Vector3 position = Vector3.zero;
			if(ConsumeDistance(obj.transform.position, moveAmount, out position)) {
				obj.transform.position = position;
				return true;
			} 

			return false;

		}
	}
}

