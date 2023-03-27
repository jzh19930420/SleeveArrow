using SleeveArrow.Mvvm.Controls;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SleeveArrow.Mvvm
{
    public interface IDialogManager
    {
    }

    public class DialogManager : IDialogManager
    {
        private static ConcurrentDictionary<string, DialogContent> _hosts = new();

        public void RegistDialog(string name, DialogContent host)
        {
            _hosts.AddOrUpdate(name, host, (n, s) => host);
        }

        /// <summary>
        /// 展示弹框
        /// </summary>
        /// <typeparam name="T">弹出界面的vm</typeparam>
        /// <param name="name">注册的弹框区域名称</param>
        /// <param name="dialogView">弹出的界面</param>
        public void ShowDialog<T>(string name, IDialogView<T> dialogView)
        {
            if (_hosts.TryGetValue(name, out DialogContent content))
            {
                content.ShowDialog(dialogView);
            }
        }

        public void CloseDialog(string name)
        {
            if (_hosts.TryGetValue(name, out DialogContent content))
            {
                content.Close();
            }
        }
    }
}