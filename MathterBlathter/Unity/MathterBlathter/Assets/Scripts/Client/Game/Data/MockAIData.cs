using Client.Game.AI.Actions;

namespace Client.Game.Data
{
    public static partial class MockAIData {
        
        public static AIData PATROL_THEN_PURSUE {
            get {
                var ret = new AIData();
                var patrolAction = new ActionData(typeof(AI.Actions.PatrolAction));
                patrolAction.Next = new ActionData(
                    typeof(TestPlayerLOS),
                    typeof(SeekToPlayer),
                    typeof(FireAtPlayer)
                    );
                ret.ActionData = patrolAction;
                
                return ret;
            }
        }
        
        public static AIData SEEK_TO_FIRE {
            get {
                var ret = new AIData();
                ret.ActionData = new ActionData(
                    typeof(TestPlayerLOS),
                    typeof(SeekToPlayer),
                    typeof(FireAtPlayer)
                    );
                
                return ret;
            }
            
        }
        
        public static AIData SENTRY_AI {
            get {
                var ret = new AIData();
                ret.ActionData = new ActionData(typeof(AimScanForPlayer));
                ret.ActionData.Next = new ActionData(typeof(FireAimingDirectionAtPlayer));
                return ret;
                
            }
            
        }
        
         public static AIData SNIPER_AI {
            get {
                var ret = new AIData();
                ret.ActionData = new ActionData(typeof(AimScanForPlayer));
                ret.ActionData.Next = new ActionData(typeof(WaitThenFire));
                return ret;
                
            }
            
        }
        
    }
}