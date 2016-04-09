using System;
using System.Reflection;
using System.Linq;

namespace Client.Game.Attributes
{
	public partial class ActorAttribute
	{

		static void ActorAttribte() {
			_all = typeof(ActorAttribute).GetFields ()
				.Where (a => a.IsStatic && a.FieldType.IsSubclassOf (typeof(GameAttribute)))
				.Select (a => a.GetValue (null) as GameAttribute)
				.OrderBy (a => a.Id)
				.ToArray();
		}

		private static GameAttribute[] _all;
		public static GameAttribute[] GetAll() {
			return _all;
		}

		public static readonly GameAttributeI Health = new GameAttributeI(1, 100, "health", GameAttributeEncoding.Int, 0, 100);
		public static readonly GameAttributeF Speed = new GameAttributeF(2, .5f, "speed", GameAttributeEncoding.Float16, 0, 10);
		public static readonly GameAttributeF JumpHeight = new GameAttributeF(3, 25, "jumpHeight", GameAttributeEncoding.Float16, 0, 50);

	}
}

