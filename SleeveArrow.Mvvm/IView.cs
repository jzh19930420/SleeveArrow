using SleeveArrow.IOC;

namespace SleeveArrow.Mvvm;

public interface IView<out T> : ITransientDependency
{
    T ViewModel { get; }
}