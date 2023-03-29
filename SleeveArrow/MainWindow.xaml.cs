using Autofac;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SleeveArrow.IOC;
using SleeveArrow.Mvvm;
using System.Windows;
using System.Windows.Controls;

namespace SleeveArrow;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, IView<MainWindowViewModel>
{
    private ILifetimeScope _lifetimeScope;

    public MainWindow(ILifetimeScope lifetimeScope, MainWindowViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = ViewModel;
        InitializeComponent();
        _lifetimeScope = lifetimeScope;
    }

    public MainWindowViewModel ViewModel { get; }
}

public partial class MainWindowViewModel : ObservableObject, ITransientDependency
{
    [ObservableProperty]
    private IView<UserControl1ViewModel> _view;

    public MainWindowViewModel()
    {
    }

    [RelayCommand]
    private void Test()
    {
    }
}