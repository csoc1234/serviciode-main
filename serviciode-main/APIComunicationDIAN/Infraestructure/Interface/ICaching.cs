namespace APIComunicationDIAN.Infraestructure.Interface
{
    public interface ICaching
    {
        bool TryGetValue(string key, out string value);

        bool Set(string key, string value);
    }
}
