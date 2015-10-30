using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ClassFormCalcBind
{
    public interface IClassWinBind : INotifyPropertyChanged
    {
        string Pole { get; set; }
        void ButtonClick(object sender, EventArgs e);
        void MainForm_KeyDown(object sender, KeyEventArgs e);
    }
}
