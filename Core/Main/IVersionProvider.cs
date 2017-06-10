namespace Core.Main
{
    public interface IVersionProvider
    {
        string GetVersion();

        void SaveVersion(string version);
    }
}
