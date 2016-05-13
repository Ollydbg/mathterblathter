using System;
using UnityEngine;

namespace Client.Utils
{
	public static class VectorUtils
	{
		public static Vector3 GetFacingVector(GameObject obj) {
			var eulerAng = obj.gameObject.transform.rotation.eulerAngles;
			float x = eulerAng.x > 180? eulerAng.x-360 : eulerAng.x;
			float y = eulerAng.y > 180? eulerAng.y-360 : eulerAng.y;
			float z = eulerAng.z > 180? eulerAng.z-360 : eulerAng.z;

			return new Vector3(x, y, z);

		}

	}
}

