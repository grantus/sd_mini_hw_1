namespace sd_mini_hw_1_v2;

public interface IInventory
{
    public string Name { get; set; }
    public int Number { get; set; }

    public abstract class Thing(string name)
    {
        public string Name { get; set; } = name;
        public int Number { get; set; }
        
    }

    public class Table(string name) : Thing(name)
    {
        
    }

    public class Computer(string name) : Thing(name)
    {
        
    }
}