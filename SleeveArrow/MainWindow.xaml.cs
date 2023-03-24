using Autofac;
using CommunityToolkit.Mvvm.ComponentModel;
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
        InitializeComponent();
        ViewModel = viewModel;
        _lifetimeScope = lifetimeScope;

        DataContext = ViewModel;
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
}