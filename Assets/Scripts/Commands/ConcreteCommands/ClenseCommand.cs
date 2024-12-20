using Command.AbstractCommand;
using Command.Main;
using Command.Actions;

namespace Command.ConcreteCommands
{
    public class ClenseCommand : UnitCommand
    {
        private bool willHitTarget;

        public ClenseCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Cleanse).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}
