namespace MiniProject03.multi
{
    public interface IComputer
    {
        string Processor { get; set; }
        string GPU { get; set; }
        int RAM { get; set; }
    }
}