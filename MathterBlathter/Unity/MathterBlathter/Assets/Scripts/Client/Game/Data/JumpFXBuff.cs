using Client.Game.Abilities;
using Client.Game.Actors;
using Client.Game.Actors.Controllers;
using Client.Game.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Client.Game.Abilities.Scripts.Buffs {

    public class JumpFXBuff : BuffBase {
        public override void End() {

        }

        Character owner;

        public override void Start() {
            owner = (context.targetActor as Character);
            var controller = owner.Controller as CharacterController2D;

            controller.OnJump += OnOwnerJump;
            controller.OnGrounded += OnOwnerGrounded;
        }

        private void OnOwnerJump(Character obj) {
            PlayTimeline(context.data.Timelines[0], GroundingPoint);
        }

        Vector2 GroundingPoint {

            get {
                
                var hit = Physics2D.BoxCast(context.targetActor.transform.position, new Vector2(2.4f, .1f), 0f, Vector2.down, 2f, LayerMask.GetMask(LayerGroups.WalkableSurfaces));
                if (hit.transform != null)
                    return hit.point;
                Debug.LogError("Couldn't get grounding point on actor!!");
                return context.targetActor.transform.position;
            }
        }

        private void OnOwnerGrounded(Vector3 groundingVelocity) {
            PlayTimeline(context.data.Timelines[1], GroundingPoint);
        }

        public override void Update(float dt) {

        }

        public override bool IsComplete() {
            return false;
        }
    }
}
