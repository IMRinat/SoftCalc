namespace CalcCore
{
    public enum MembTyp // type of member
    {
        Oper,
        Nul
    };

    public enum OperTyp // type of operation
    {
        Unar,
        Binar,
        Ternar,
        Unarbinar,
        Space,
        Number
    };

    public delegate void CalcOperDelegat(int i);
}
