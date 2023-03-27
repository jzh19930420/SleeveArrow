using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SleeveArrow.Mvvm.Controls;

public class DialogControl : UserControl
{
    public ICommand ClosedCommand
    {
        get { return (ICommand)GetValue(ClosedCommandProperty); }
        set { SetValue(ClosedCommandProperty, value); }
    }

    public static readonly DependencyProperty ClosedCommandProperty =
        DependencyProperty.Register("ClosedCommand", typeof(ICommand), typeof(DialogControl), new PropertyMetadata(null));

    public DialogControl()
    {
    }

    public void Close()
    {
        ClosedCommand?.Execute(null);
    }
}