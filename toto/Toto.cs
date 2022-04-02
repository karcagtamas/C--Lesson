namespace toto;

public class Toto
{
    public int Year { get; set; }
    public int Week { get; set; }
    public int Round { get; set; }
    public int FullC { get; set; }
    public int Cost { get; set; }
    public string Result { get; set; } = string.Empty;

    public int FullCost { get { return FullC * Cost; } }

    public override string ToString()
    {
        return $"[Year = {Year}, Week = {Week}, Round = {Round}, FullC = {FullC}, Cost = {Cost}, Result = {Result}]";
    }
}