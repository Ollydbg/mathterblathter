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
		
		public override void Start (Actor selfActor)
		{
			Agent = new PathingAgent(CurrentRoom.Grid.SearchPath(selfActor.transform.position, PlayerMid));
			
		}

		public override AIResult Update (float dt, Actor actor)
		{

			var isComplete = Agent.TryMove(actor.GameObject, actor.Attributes[ActorAttributes.Speed] * dt);

			return AIResult.Running;

		}

	}

	public class PathingAgent {
		
		Vector3[] PathNodes;
		int index = 0;
		public Vector3 CurrentNode {
			get {
				return PathNodes[index];
			}
		}

		const float CLOSE_ENOUGH_SQ = .01f;

		public PathingAgent(Vector3[] nodes) {
			this.PathNodes = nodes;
			index = 0;
		}

		public Vector3 NextGoal() {
			return CurrentNode;
		}

		bool IsCloseEnough (Vector3 position, Vector3 currentNode)
		{
			return (position - currentNode).sqrMagnitude <= CLOSE_ENOUGH_SQ;
		}
		void Advance() {
			index++;
		}

		
		public bool TryMove(GameObject obj, float moveAmount) {

			if(IsCloseEnough(obj.transform.position, CurrentNode)) {
				if(index == PathNodes.Length -1)
					return false;
				
				Advance();
			}

			var moveVector = (CurrentNode - obj.transform.position).normalized;
			obj.transform.position += moveVector*moveAmount;

			return true;
		}
	}
}

