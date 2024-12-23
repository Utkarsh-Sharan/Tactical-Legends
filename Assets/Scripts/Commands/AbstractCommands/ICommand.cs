namespace Command.AbstractCommand 
{
    public interface ICommand
    {
        public void Execute();     //defines the contract for executing a command.
        public void Undo();
    }
}