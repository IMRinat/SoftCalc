using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CalcCore
{

    public partial class Members : ObservableCollection<Member>
    {
        public  Opers OperList;

        //constructor
        public Members()
        {
            InitOpers();
        }

        // choose index of next operation for calculate
        private int NextPriorityOperator()
        {
            var mn = 999999;
            var ind = 0;
            for (var index = 0; index < Count; index++)
            {
                var member = this[index];
                if ((member.Priority > 0) && (member.Priority < mn))
                {
                    mn = member.Priority;
                    ind = index;
                }
            }
            return ind;
        }

        //calculate all members
        public string calc_members()
        {
            if (Count < 1) return "Damn";
            if (Count < 2) return this[0].Realnumb.ToString(CultureInfo.InvariantCulture);

            var i = NextPriorityOperator();

            this[i].CalcOper(i);

            return calc_members();
        }


        //add new member
        public void add_oper(string st)
        {
            //становится очень важной процедурой. добавляет и операции и числа
            var oper1 = OperList.GetOper(st);

            if (oper1 == null) return;

            var lastitem = Count - 1;


            if ((oper1.Opertyp == OperTyp.Number) && (lastitem>=0) && (Items[lastitem].Opertyp == OperTyp.Number)) // TODO must die. need use ConvertNumber
            {
                Items[lastitem].Name = Items[lastitem].Name + oper1.Name;
            }
            else
            {
                Add(new Member
                    {
                        Name = oper1.Name,
                        Opertyp = oper1.Opertyp,
                        Realnumb = 0,
                        Priority = oper1.Priority,
                        Typ = MembTyp.Oper,
                        CalcOper = oper1.CalcOper, 
                        Oper = oper1 // TODO  must be only this, others where oper1 copy must delete
                    });
            }
        }
    }

    //Implementation of  INotifyPropertyChanged
    public class Member : INotifyPropertyChanged
    {
        private string _name;
        private MembTyp _typ;
        private int _priority;
        private double _realnumb;
        private OperTyp _opertyp; 
        private CalcOperDelegat _calcOper;
        private Oper _oper;

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

        public MembTyp Typ
        {
            get { return _typ; }
            set
            {
                _typ = value;
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

        public double Realnumb
        {
            get { return _realnumb; }
            set
            {
                _realnumb = value;
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

        public Oper Oper
        {
            get { return _oper; }
            set
            {
                _oper = value;
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
