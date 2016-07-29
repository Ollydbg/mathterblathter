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

		}
		

		public override AIResult Update (float dt, Character actor)
		{
			
			repathAccum += dt;

			var didMove = Agent.TryMove(actor, actor.Attributes[ActorAttributes.Speed] * dt);

			var hasLOS = ActionUtil.HasLOS(actor, PlayerMid);

			if(hasLOS) {
				return AIResult.Success;
			}

			var forceRepath = !didMove && !hasLOS;

			if((repathAccum >= REPATH_DELAY)) {
				Repath();

				if(Agent.PathNodes.Length == 0) 
					return AIResult.Failure;
			}


			return AIResult.Running;

		}

	}

	public class PathingAgent {
		
		public Vector3[] PathNodes;
		int index = 0;
		public Action OnPathAdvance;
		public Vector3 CurrentNode {
			get {
				return PathNodes[index];
			}
		}

		void DebugDrawNodes(Vector3[] nodes) {
			for(int i = 0; i< nodes.Length; i++ ) {
				var node = nodes[i];

				var color = i == nodes.Length -1? Color.red : Color.magenta;
				if( i == 0 )
					color = Color.green;

				Debug.DrawRay(node, Vector3.back * 3f, color, 2f);
			}
		}

		public PathingAgent(Vector3[] nodes) {
			this.PathNodes = nodes;
			index = 0;

			if(nodes.Length > 2)
				index = 1;


			DebugDrawNodes(nodes);
		}


		const float EPSILON = .01f;
		bool ConsumeDistance(Vector3 from, float moveMag, out Vector3 newDirection) {
			var moveMagSq = moveMag * moveMag;
			var distanceVec = CurrentNode - from;

			//if we're going to overshoot the next node on this move, then round the corner
			if(distanceVec.sqrMagnitude < EPSILON) {
				moveMag -= distanceVec.magnitude;
				var newFrom = CurrentNode;

				if(index == PathNodes.Length - 1) {
					newDirection = Vector3.zero;
					return false;
				}

				Advance();

				return ConsumeDistance(newFrom, moveMag, out newDirection);
			} else {
				newDirection = distanceVec.normalized;
			}

			return true;
		}

		void Advance() {
			index++;
			if(OnPathAdvance != null) 
				OnPathAdvance();
		}

		
		public bool TryMove(Character obj, float moveAmount) {

			if(PathNodes.Length == 0) {
				return false;
			}

			Vector3 direction = Vector3.zero;
			if(ConsumeDistance(obj.transform.position, moveAmount, out direction)) {
				obj.Controller.MoveDirection(direction);
				return true;
			} 

			return false;

		}
	}
}

