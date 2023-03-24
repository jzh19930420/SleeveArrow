using CommunityToolkit.Mvvm.ComponentModel;
using SleeveArrow.IOC;
using SleeveArrow.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SleeveArrow
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl, IView<UserControl1ViewModel>
    {
        public UserControl1(UserControl1ViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;

            DataContext = ViewModel;
        }

        public UserControl1ViewModel ViewModel { get; }
    }

    public partial class UserControl1ViewModel : ObservableObject, ITransientDependency
    {
    }
}