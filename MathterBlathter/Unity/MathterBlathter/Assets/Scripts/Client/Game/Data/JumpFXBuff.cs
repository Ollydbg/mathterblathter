using Client.Game.Abilities;
using Client.Game.Actors;
using Client.Game.Actors.Controllers;
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
            PlayTimeline(context.data.Timelines[0], obj.transform.position);
        }

        private void OnOwnerGrounded(Vector3 groundingVelocity) {
            PlayTimeline(context.data.Timelines[1], owner.transform.position);
        }

        public override void Update(float dt) {

        }

        public override bool IsComplete() {
            return false;
        }
    }
}
