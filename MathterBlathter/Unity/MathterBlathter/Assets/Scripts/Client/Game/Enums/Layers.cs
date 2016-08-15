using System;

namespace Client.Game.Enums
{
	public enum Layers
	{
		Pickups,
		Projectiles,
		HardGeometry,
		SoftGeometry,
		Player,
		Door,
		Enemies,
		PassThrough,
		AirEnemies,
		GhostEnemies
	}

	public static class LayerGroups {
		public static string[] EnemyLayers {
			get {
				return new string[]{Layers.Enemies.ToString(), Layers.AirEnemies.ToString(), Layers.GhostEnemies.ToString()};
			}
		}

		public static string[] ProjectileCollision {
			get {
				return new string[]{Layers.HardGeometry.ToString(), Layers.Enemies.ToString(), Layers.AirEnemies.ToString(), Layers.GhostEnemies.ToString()};
			}
		}

        public static string[] WalkableSurfaces {
            get {
                return new string[] { Layers.HardGeometry.ToString(), Layers.SoftGeometry.ToString() };
            }
        }
        
	}
}

