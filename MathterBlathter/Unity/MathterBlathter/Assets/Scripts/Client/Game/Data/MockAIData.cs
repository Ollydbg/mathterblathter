using Client.Game.AI.Actions;

namespace Client.Game.Data
{
    public static partial class MockAIData {
        
        public static AIData PATROL_THEN_PURSUE {
            get {
                var ret = new AIData();
                ret.Name = "Patrol Then Pursue";
                var patrolAction = new ActionData (
                    typeof(PatrolAction),
                    typeof(TestPlayerLOS)
                );
                patrolAction.Next = new ActionData(
                    typeof(FireAtPlayer),
                    typeof(HasPlayerLOS)
                    );
                ret.ActionData = patrolAction;
                
                return ret;
            }
        }
        
        public static AIData SEEK_TO_FIRE {
            get {
                var ret = new AIData();
                ret.Name = "Seek To Fire";
                ret.ActionData = new ActionData(typeof(SeekToPlayer));
                ret.ActionData.Next = new ActionData(
                typeof(FireAtPlayer), 
                    typeof(HasPlayerLOS));
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
                ret.ActionData.Next = new ActionData(typeof(WaitThenFire));
                return ret;
                
            }   
        }
        
        public static AIData FIRING_FIXTURE_AI {
            get {
                var ret = new AIData();
                ret.Name = "Fixture AI";
                ret.ActionData = new ActionData(typeof(FireFacingDirection));
                return ret;
            }    
        
        }
        
    }
}