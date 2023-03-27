using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleeveArrow.Mvvm
{
    public interface IDialogView<out T>
    {
        T ViewModel { get; }
    }
}