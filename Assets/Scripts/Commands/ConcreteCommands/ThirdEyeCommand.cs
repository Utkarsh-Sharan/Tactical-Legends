using Command.AbstractCommand;
using Command.Main;
using Command.Actions;

namespace Command.ConcreteCommands
{
    public class ThirdEyeCommand : UnitCommand
    {
        private bool willHitTarget;
        private int previousHealth;

        public ThirdEyeCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute()
        {
            previousHealth = targetUnit.CurrentHealth; 
            GameService.Instance.ActionService.GetActionByType(CommandType.ThirdEye).PerformAction(actorUnit, targetUnit, willHitTarget);

        }

        public override void Undo()
        {
            if (!targetUnit.IsAlive())
                targetUnit.Revive();

            int healthToRestore = (int)(previousHealth * 0.25f);
            targetUnit.RestoreHealth(healthToRestore);
            targetUnit.CurrentPower -= healthToRestore;
            actorUnit.Owner.ResetCurrentActiveUnit();
        }
    }
}
