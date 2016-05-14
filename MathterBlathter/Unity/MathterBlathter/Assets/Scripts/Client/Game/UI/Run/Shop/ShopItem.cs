﻿using System;
using UnityEngine;
using UnityEngine.UI;
using Client.Game.Data;

namespace Client.Game.UI.Run.Shop
{
	public class ShopItem : MonoBehaviour
	{
		public Text Label;

		public ShopItem ()
		{
		}

		public void InitWith (CharacterData characterData)
		{
			this.Label.text = characterData.Name;
		}
	}
}

