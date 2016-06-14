using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Game.UI
{
    public class ActiveItemHud : RunUI
    {

        public Image LoadBar;
        public Text Label;
        PlayerCharacter playerCharacter;

        public override void Hide()
        {
        }

        void Start() {
            playerCharacter = Game.PossessedActor;
            CheckShowing();

        }

        void CheckShowing() {
            var itemId = playerCharacter.Attributes[ActorAttributes.ActiveItemId]; 
            bool visible = ( itemId != 0 );

            this.gameObject.SetActive(visible);
        }


        public override void Show()
        {
        }
    }
}