namespace Home_Central.Data.Entities;

public class WoningVerbruikModel
{
    public int Id { get; set; }
    public DateTime datum { get; set; }
    public int GasStand { get; set; }
    public int DagTeller { get; set; }
    public int NachtTeller { get; set; }
    public int Zon { get; set; }
}
