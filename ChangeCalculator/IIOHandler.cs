namespace ChangeCalculator
{
    public interface IIOHandler
    {
        string Load();
        void Save(string data);
    }
}
