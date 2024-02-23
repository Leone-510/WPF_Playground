namespace DIInWPF.StartupHelpers;

public interface IAbstractFactory<T>
{
    T Create();
}