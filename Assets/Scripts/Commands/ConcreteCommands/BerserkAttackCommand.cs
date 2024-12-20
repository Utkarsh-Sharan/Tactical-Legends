using Command.AbstractCommand;
using Command.Main;
using Command.Actions;

namespace Command.ConcreteCommands
{
    public class BerserkAttackCommand : UnitCommand
    {
        private bool willHitTarget;

        public BerserkAttackCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}
