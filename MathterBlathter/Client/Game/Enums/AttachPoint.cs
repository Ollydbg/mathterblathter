using System;
using UnityEngine;

namespace Client.Game.Enums
{
	public enum AttachPoint
	{
		Muzzle,
		Arm,
		Face,
		Eyes,
	}

	public class AttachPointComponent : MonoBehaviour {
		public AttachPoint Type;
	}
}

