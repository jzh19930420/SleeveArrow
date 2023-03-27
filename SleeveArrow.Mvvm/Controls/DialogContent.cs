using System.Windows.Controls;

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