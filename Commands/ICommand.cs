namespace UltraBizert.CarsCRUD.Commands
{
    public interface ICommand
    {
        void Execute();
        bool ValidateData(string data);
        bool InputRequired();
        string DataExample { get; }
    }
}