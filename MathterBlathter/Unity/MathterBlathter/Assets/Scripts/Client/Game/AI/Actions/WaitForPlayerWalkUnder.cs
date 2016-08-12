using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Enums;

namespace Client.Game.AI.Actions {

    public class WaitForPlayerWalkUnder : AIAction {

        private int PlayerAndGround = LayerMask.GetMask(new string[] { Layers.Player.ToString() });

        public override AIResult Update(float dt, Character actor) {
            
            var hit = Physics2D.CircleCast(actor.transform.position, 4f, Vector2.down, 20f, PlayerAndGround);
            
            if(hit.transform != null) {
                return AIResult.Success;
            }

                
            return AIResult.Running;

        }

    }
}
