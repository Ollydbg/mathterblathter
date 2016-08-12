using Client.Game.AI.Actions;
using System;
using System.Collections.Generic;

namespace Client.Game.Data
{
    public static partial class AIDataTable {
        



		public static AIData PATROL_THEN_PURSUE_AI {
			get {
				var ret = new AIData();
				ret.Name = "Patrol Then Pursue";
				var patrolAction = new ActionData (
					typeof(PatrolAction),
					typeof(WaitForPlayerLOS)
				);
				patrolAction.Next = new ActionData(
					typeof(AggroFireAtPlayer),
					typeof(CheckPlayerLOS)
				);
				ret.ActionData = patrolAction;

				return ret;
			}
		}
        
		public static AIData AIR_PATH_TO_FIRE_AI {
			get {
				var ret = new AIData();
				ret.ActionData = new ActionData(typeof(PathToPlayer));
				ret.ActionData.Next = new ActionData(
					typeof(AggroFireAtPlayer),
					typeof(CheckPlayerLOS)
				);

				return ret;
			}
		}

        public static AIData SEEK_TO_FIRE_IF_LOS_AI {
            get {
				
                var ret = new AIData();
                ret.Name = "Seek To Fire";
				ret.ActionData = new ActionData(typeof(WaitForPlayerLOS));
                ret.ActionData.Next = new ActionData(typeof(SeekToPlayer));
                ret.ActionData.Next.Next = new ActionData(
                	typeof(AggroFireAtPlayer), 
                    typeof(CheckPlayerLOS)
				);
                return ret;
            }
        }
        
		public static AIData IDLE_THEN_SEEK_AI {
			get {
				var ret = new AIData();

				ret.ActionData = new ActionData(new Type[]{
						typeof(Idle),
						typeof(WaitForPlayerLOS)
						}
				).Then (
					new ActionData(new Type[]{
						typeof(WaitAction),
						typeof(AggroFireAtPlayer), 
						typeof(CheckPlayerLOS)})
					.Else(
						typeof(PathToPlayer)
					)
				);

				return ret;
			}
		}
        
        public static AIData SENTRY_AI {
            get {
                var ret = new AIData();
                ret.Name = "Sentry AI";
                ret.ActionData = new ActionData(typeof(AimScanForPlayer));
                ret.ActionData.Next = new ActionData(typeof(FireAimingDirectionAtPlayer));
                return ret;
                
            }
            
        }
        
        public static AIData SNIPER_AI {
            get {
                var ret = new AIData();
                ret.Name = "Sniper AI";
                ret.ActionData = new ActionData(typeof(AimScanForPlayer));
                ret.ActionData.Next = new ActionData(typeof(WaitThenFireIfLOS));
                return ret;
            }   
        }

		public static AIData WANDERING_SNIPER_AI {
			get {
				var ret = new AIData();
				ret.Name = "Pathing Sniper AI";

				ret.ActionData = new ActionData(new Type[]{
					typeof(AimScanForPlayer),
					typeof(PatrolAction)
					}
				).Then(typeof(WaitForAimLock))
						.Then(typeof(WaitAction))
							.Then(typeof(FireAimingWhileAimedAtPlayer)

				);
				
				return ret;

			}   
		}

		public static AIData HUNTING_SNIPER_AI {
			get {
				var ret = new AIData();
				ret.Name = "Pathinf Sniper AI";

				ret.ActionData = new ActionData(
					typeof(PathToPlayer)
				).Then(
					typeof(AimAtPlayerAction)
				).Then(
					typeof(WaitThenFireIfLOS)	
				);


				return ret;

			}   
		}

        
        public static AIData FIRING_FIXTURE_AI {
            get {
                var ret = new AIData();
                ret.Name = "Fixture AI";
                ret.ActionData = new ActionData(typeof(FireSpawnDirection));
                return ret;
            }    
        
        }

		public static AIData ROVING_FIRING_FIXTURE_AI {
			get {
				var ret = new AIData();
				ret.Name = "Roving Firing Fixture AI";

				ret.ActionData = new ActionData (
					typeof(PatrolAction),
					typeof(FireFacingDirection)
				);

				return ret;
			}
		}

		public static AIData FIRE_THEN_TELEPORT {
			get {
				var ret = new AIData();
				ret.Name = "Fire then teleport";
				
				
				ret.ActionData = new ActionData(
					typeof(WaitAction)
				).Then(
					typeof(AimAtPlayerAction)
				).Then (
					typeof(FireAimingOnce)
				).Then(
					typeof(WaitAction)
				).Then(
					typeof(TeleportRandom)
				);

				return ret;
			}
		}

		public static AIData AIM_STEER_THROUGH_GEO {
			get {
				var ret = new AIData();
				ret.ActionData = new ActionData(
					typeof(AimSteerAtPlayer),
					typeof(FireWhileSteeringTowardsPlayer)
				);
				return ret;
			}
		}

    }
}