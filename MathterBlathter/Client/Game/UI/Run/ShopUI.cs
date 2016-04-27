﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Game.UI.Run
{
	public class ShopUI : RunUI
	{
		public ShopUI ()
		{
		}

		#region implemented abstract members of RunUI

		public override void Show ()
		{
			
		}

		public override void Hide ()
		{
		}

		#endregion


	}

	public class ShopItem : MonoBehaviour {
		public Text NameLabel;
		public Text CostLabel;
		public Text DescriptionLabel;
	}
}

