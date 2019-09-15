namespace UltraBizert.CarsCRUD.Commands
{
    public interface ICommand
    {
        void Execute();
        bool ValidateData(string data);
        string DataExample { get; }
    }
}