using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CalcCore
{
    public class Opers : ObservableCollection<Oper>
    {
        private int min(int a, int b)
        {
            return (a < b) ? a : b;
        }

        public Oper GetOper(string st)
        {
            return this.FirstOrDefault(oper => oper.Name == st.Substring(0, min(oper.Name.Length,st.Length)));
        }
    }

    public class Oper : INotifyPropertyChanged
    {
        private string _name;     // Name of Operation
        private int _priority;    // priority of operation
        private OperTyp _opertyp; // Type of operation 
        private CalcOperDelegat _calcOper;


        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }


        public int Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                OnPropertyChanged();
            }
        }


        public OperTyp Opertyp
        {
            get { return _opertyp; }
            set
            {
                _opertyp = value;
                OnPropertyChanged();
            }
        }

        public CalcOperDelegat CalcOper
        {
            get { return _calcOper; }
            set
            {
                _calcOper = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
