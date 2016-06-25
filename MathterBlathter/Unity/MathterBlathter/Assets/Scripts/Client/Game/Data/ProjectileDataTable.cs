using System;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Enums;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public static partial class CharacterDataTable
	{
        public static CharacterData BEAM_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 2000;
				ret.ResourcePath = "Projectiles/BeamProjectile_prefab";
				ret.ActorType = ActorType.Projectile;
				return ret;
			}
		}


		public static CharacterData FAT_BLACK_SLUG_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 2001;
				ret.ActorType = ActorType.Projectile;
				ret.ResourcePath = "Projectiles/FatSlug_prefab";
				return ret;
			}
			
		}
        
        public static CharacterData PINK_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 2002;
				ret.ActorType = ActorType.Projectile;
				ret.ResourcePath = "Projectiles/enemyTest_prefab";

				return ret;
			}
		}
        
        
		public static CharacterData RAIL_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 2003;
				ret.ActorType = ActorType.Projectile;
				ret.ResourcePath = "Projectiles/HotRail_prefab";
				return ret;

			}
		}

		public static CharacterData ROCKET_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 2004;
				ret.ActorType = ActorType.Projectile;
				ret.ResourcePath = "Projectiles/SmallRocket_prefab";
				return ret;
			}
		}
        
        public static CharacterData AIM_RAY {
			get {
				var ret = new CharacterData();
				ret.Id = 2005;
				ret.ResourcePath = "Projectiles/VFX/aimLine_prefab";
				ret.ActorType = ActorType.Projectile;
				return ret;
			}
		}
		public static CharacterData SHIELD_BLOCK_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 2006;
				ret.ResourcePath = "Weapons/Shield_prefab";
				ret.ActorType = ActorType.Projectile;
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.ProjectileLifespan.Id,
					float.MaxValue
				));
				return ret;
			}
		}
		public static CharacterData BLUE_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 2007;
				ret.ActorType = ActorType.Projectile;
				ret.ResourcePath = "Projectiles/BlueProjectile_prefab";
				return ret;

			}
		}
		
		public static CharacterData GRENADE_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 2008;
				ret.ActorType = ActorType.Projectile;
				ret.ResourcePath = "Projectiles/Grenade_prefab";
				
				return ret;
			}
		}

    }
}