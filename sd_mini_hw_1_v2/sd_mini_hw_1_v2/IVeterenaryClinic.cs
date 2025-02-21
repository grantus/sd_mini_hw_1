namespace sd_mini_hw_1_v2;

public interface IVeterinaryClinic
{
    public string Name { get; set; }
    public string Address { get; set; }

    public bool CheckHealth(IAlive.Animal creature);

    public class VeterinaryClinic(string name, string address) : IVeterinaryClinic
    {
        public string Name { get; set; } = name;
        public string Address { get; set; } = address;

        public bool CheckHealth(IAlive.Animal creature)
        {
            Console.WriteLine($"Checking health of {creature.Name}...");
            return creature.IsHealthy;
        }
    }
}