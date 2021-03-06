﻿using System;
using UnityEngine;
using UnityEngine.UI;
using Client.Game.Data;

namespace Client.Game.UI.Run.Shop
{
	public class ShopItem : MonoBehaviour
	{
		public Text Label;
		public Text Cost;
		public Action OnBuy;

		public ShopItem ()
		{
			
		}

		public void InitWith (CharacterData characterData)
		{
			this.Label.text = characterData.Name;
			this.Cost.text = characterData.Cost.ToString();

			var btn = this.GetComponent<Button>();
			btn.onClick.AddListener(() => OnBuy());


		}
	}
}

