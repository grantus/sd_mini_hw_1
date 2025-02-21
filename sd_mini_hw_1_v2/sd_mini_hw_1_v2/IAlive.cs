namespace sd_mini_hw_1_v2;

public delegate void TotalFoodChanged(double correction);
public interface IAlive
{

    double Food { get; set; }
    bool IsHealthy { get; set; }
    string Name { get; }
    int Number { get; }
    
    public abstract class Animal
    {
        public event TotalFoodChanged? OnTotalFoodChanged;
        
        private double _food;
        private const double Tolerance = 0.0001;
        public double Food
        {
            get => _food;
            set
            {
                if (!(Math.Abs(_food - value) > Tolerance)) return;
                OnTotalFoodChanged?.Invoke(value - _food);
                _food = value;
            } 
        }
        public bool IsHealthy { get; set; }
        public string Name { get; }
        public string Species { get; }

        protected Animal(string name, double food, bool isHealthy, int number)
        {
            Name = name;
            Food = food;
            IsHealthy = isHealthy;
            Species = GetType().Name;
            Number = number;
        }
        
        public int Number { get; }
    }

    public abstract class Herbo : Animal
    {
        private readonly int _kindness;
        public int Kindness => _kindness;
        protected Herbo(string name, double food, bool isHealthy, int number, int kindness)
            : base(name, food, isHealthy, number)
        {
            if (kindness is > 10 or < 0)
            {
                throw new ArgumentException("Kindness must be between 0 and 10.");
            }
            _kindness = kindness;
        }

        public bool IsKind()
        {
            return _kindness > 5;
        }
    }

    public abstract class Predator(string name, double food, bool isHealthy, int number) : Animal(name, food, isHealthy, number);

    public class Monkey(string name, double food, bool isHealthy,  int number, int kindness) : Herbo(name, food, isHealthy, number, kindness)
    {
        
    }

    public class Rabbit(string name, double food, bool isHealthy, int number, int kindness) : Herbo(name, food, isHealthy, number, kindness)
    {
        
    }

    public class Tiger(string name, double food, bool isHealthy, int number) : Predator(name, food, isHealthy, number);

    public class Wolf(string name, double food, bool isHealthy, int number) : Predator(name, food, isHealthy, number);
}