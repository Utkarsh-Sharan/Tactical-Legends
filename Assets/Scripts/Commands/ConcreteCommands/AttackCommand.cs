using Command.AbstractCommand;
using Command.Main;
using Command.Actions;

namespace Command.ConcreteCommands
{
    public class AttackCommand : UnitCommand
    {
        private bool willHitTarget;

        public AttackCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Attack).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override void Undo()
        {
            if (willHitTarget)
            {
                if (!targetUnit.IsAlive())      //if target unit is dead, first revive, then restore its health and reset active unit.
                {
                    targetUnit.Revive();
                }

                targetUnit.RestoreHealth(actorUnit.CurrentPower);
                actorUnit.Owner.ResetCurrentActiveUnit();
            }
        }
    }
}
