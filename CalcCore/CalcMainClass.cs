namespace CalcCore
{
    public class CalcMainClass
    {
        private readonly Members _memberList;

        public CalcMainClass()
        {
            _memberList = new Members();
        }


        private void Parse(string tx)
        {
            Oper oper1;
            for (var i = 0; i < tx.Length; i += (oper1 == null) ? 1 : oper1.Name.Length)
            {
                oper1 = _memberList.OperList.GetOper(tx.Substring(i));
                if (oper1 != null) _memberList.add_oper(oper1.Name);
            }
        }


        //One public function. Heart of system.
        public string Calc_string(string tx)
        {
            _memberList.Clear();
            Parse(tx);
            return _memberList.calc_members();
        }
    }

}
