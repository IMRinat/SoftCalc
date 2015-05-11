namespace CalcCore
{
    partial class Members
    {

        private void InitOpers()
        {
            OperList = new Opers
                {
                    //0 - ignore
                    //1 - for number
                    // 2 for dot and brackets
                    //3 etc for other operations

                    new Oper {Name = "sin", Priority = 3, Opertyp = OperTyp.Unar},
                    new Oper {Name = "*", Priority = 4, Opertyp = OperTyp.Binar, CalcOper = BinarMulltiple},
                    new Oper {Name = "/", Priority = 4, Opertyp = OperTyp.Binar, CalcOper = BinarDivide},
                    new Oper {Name = "+", Priority = 3, Opertyp = OperTyp.Unarbinar,CalcOper = UnarBinarPlus},
                    new Oper {Name = "-", Priority = 3, Opertyp = OperTyp.Unarbinar,CalcOper = UnarBinarMinus},
                    new Oper {Name = ")", Priority = 2, Opertyp = OperTyp.Unar, CalcOper = BracketProc},
                    new Oper {Name = ".", Priority = 2, Opertyp = OperTyp.Binar, CalcOper = BinarDot},
                    new Oper {Name = ",", Priority = 2, Opertyp = OperTyp.Binar, CalcOper = BinarDot},

                    new Oper {Name = "(", Priority = 0, Opertyp = OperTyp.Unar},
                    new Oper {Name = " ", Priority = 1, Opertyp = OperTyp.Space, CalcOper = SpaceProc},
                    new Oper {Name = "0", Priority = 1, Opertyp = OperTyp.Number, CalcOper = ConvertNumber},
                    new Oper {Name = "1", Priority = 1, Opertyp = OperTyp.Number, CalcOper = ConvertNumber},
                    new Oper {Name = "2", Priority = 1, Opertyp = OperTyp.Number, CalcOper = ConvertNumber},
                    new Oper {Name = "3", Priority = 1, Opertyp = OperTyp.Number, CalcOper = ConvertNumber},
                    new Oper {Name = "4", Priority = 1, Opertyp = OperTyp.Number, CalcOper = ConvertNumber},
                    new Oper {Name = "5", Priority = 1, Opertyp = OperTyp.Number, CalcOper = ConvertNumber},
                    new Oper {Name = "6", Priority = 1, Opertyp = OperTyp.Number, CalcOper = ConvertNumber},
                    new Oper {Name = "7", Priority = 1, Opertyp = OperTyp.Number, CalcOper = ConvertNumber},
                    new Oper {Name = "8", Priority = 1, Opertyp = OperTyp.Number, CalcOper = ConvertNumber},
                    new Oper {Name = "9", Priority = 1, Opertyp = OperTyp.Number, CalcOper = ConvertNumber}
                };
        }

        private void ConvertNumber(int i)
        {
            this[i].Realnumb = double.Parse(this[i].Name);
            this[i].Priority = 0;
        }

        private void UnarBinarMinus(int i)
        {
            //Unar minus
            if (((i > 0) && (this[i - 1].Opertyp != OperTyp.Number)) || (i == 0))
            {
                this[i + 1].Realnumb = this[i + 1].Realnumb * (-1);
                RemoveAt(i);
            }

            //Binar minus
            if ((i > 0) && (this[i - 1].Opertyp == OperTyp.Number))
            {
                // TODO  MAKE GENERAL ALGORITHM

                if (this[i].Priority == 10)
                {
                    this[i - 1].Realnumb = this[i - 1].Realnumb - this[i + 1].Realnumb;
                    RemoveAt(i);
                    RemoveAt(i);
                }
                else
                {
                    if (this[i].Priority == 3)
                    {
                        this[i].Priority = 10;
                    }
                }
            }
        }

        private void UnarBinarPlus(int i)
        {
            //Unar plus
            if (((i > 0) && (this[i - 1].Opertyp != OperTyp.Number)) || (i == 0))
            {
                RemoveAt(i);
            }

            //Binar plus
            if ((i > 0) && (this[i - 1].Opertyp == OperTyp.Number))
            {
                // TODO  MAKE GENERAL ALGORITHM

                if (this[i].Priority == 10)
                {
                    this[i - 1].Realnumb = this[i - 1].Realnumb + this[i + 1].Realnumb;
                    RemoveAt(i);
                    RemoveAt(i);
                }
                else
                {
                    if (this[i].Priority == 3)
                    {
                        this[i].Priority = 10;
                    }
                }
            }
        }

        private void BinarDot(int i)
        {

            while (this[i + 1].Realnumb >= 1)
            {
                this[i + 1].Realnumb /= 10;
            }

            this[i - 1].Realnumb = this[i - 1].Realnumb + this[i + 1].Realnumb;
            RemoveAt(i);
            RemoveAt(i);
        }
        
        private void BinarDivide(int i)
        {
            this[i - 1].Realnumb = this[i - 1].Realnumb / this[i + 1].Realnumb;
            RemoveAt(i);
            RemoveAt(i);
        }

        private void BinarMulltiple(int i)
        {
            this[i - 1].Realnumb = this[i - 1].Realnumb * this[i + 1].Realnumb;
            RemoveAt(i);
            RemoveAt(i);
        }

        private void SpaceProc(int i)
        {
            RemoveAt(i);
        }

        private void BracketProc(int i)
        {
            var clonememberList = new Members();

            //Clone members in brackets
            //бля ссылки на методы тоже клонируются
            //должны быть свои
            int j;
            for (j = i-1; j >= 0; j--)
            {
                if (this[j].Name == "(") break;
                clonememberList.Insert(0, this[j]);
                //может сохранить где-нить перед добавлением
                // нет
                // есть оперлист
                // надо в клонах проставить ссылки на методы из клона
                // а там стоят родные
                // 
                //TODO MAKE BETTER ALGORITHM
                clonememberList[0].CalcOper = clonememberList.OperList.GetOper(clonememberList[0].Name).CalcOper;
                RemoveAt(j);
            }
            RemoveAt(j);
            //calc cloneable members
            clonememberList.calc_members();
            //TODO   check for errors in result clonememberlist 
            this[j] = clonememberList[0];

        }

    }
}
