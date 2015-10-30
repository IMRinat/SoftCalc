using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ClassFormCalcBind 
{
    public class ClassWinBind : IClassWinBind
    {
        public ClassWinBind ()
        {
            _pole = "600/-20";
        }

        private string _pole;
        public event PropertyChangedEventHandler PropertyChanged;

        public void ButtonClick(object sender, EventArgs e)
        {
            Pole = Pole + ((Button)sender).Name;
        }

        public void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                MessageBox.Show("What the Ctrl+F?");
            }
        }



        public string Pole
        {
            get { return _pole; }
            set { if (value != _pole) { _pole = value; OnPropertyChanged(); } }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) { handler(this, new PropertyChangedEventArgs(propertyName)); }
        }

    }
}
