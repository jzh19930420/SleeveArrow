using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SleeveArrow.Mvvm.Controls
{
    public class DialogContent : ContentControl
    {
        private DialogControl _dialogControl;

        public void ShowDialog(object content)
        {
            if (content is DialogControl dialog)
            {
                _dialogControl = dialog;
                Content = _dialogControl;
                Visibility = System.Windows.Visibility.Visible;
            }
        }

        public void Close()
        {
            _dialogControl?.Close();
            Content = null;
            Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}