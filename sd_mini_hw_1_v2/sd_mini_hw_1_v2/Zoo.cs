namespace sd_mini_hw_1_v2;

public class Zoo(IVeterinaryClinic clinic)
{
    private readonly List<IAlive.Animal> _animals = [];
    private double _totalFood;

    public void AddAnimal(IAlive.Animal animal)
    {
        if (clinic.CheckHealth(animal))
        {
            _animals.Add(animal);
            if (animal is IAlive.Herbo herboAnimal)
            {
                if (herboAnimal.IsKind())
                {
                    _animalsForContactZoo.Add(herboAnimal);
                }
            }
            _totalFood += animal.Food;
            
            animal.OnTotalFoodChanged += OnAnimalFoodChanged;
            
            Console.WriteLine($"{animal.Name} is added to the zoo!");
        }
        else
        {
            Console.WriteLine(
                $"{animal.Name} is not added to the zoo due to health condition. It needs medical attention");
        }
    }

    public void GetAnimals()
    {
        Console.WriteLine("\nThe animals:");

        _animals.Sort((a, b) => string.Compare(a.Species, b.Species, StringComparison.Ordinal));
        var prev = "";
        foreach (var animal in _animals)
        {
            if (animal.Species != prev)
            {
                Console.WriteLine($"{animal.Species}s:");
                prev = animal.Species;
            }

            Console.WriteLine($"    {animal.Name}, food per day: {animal.Food} kg");
        }
        Console.WriteLine();
    }
    
    public void UpdateAnimalFood(IAlive.Animal animal, double newFoodAmount)
    {
        Console.WriteLine($"{animal.Name} is now requiring {newFoodAmount} kg of food per day (formerly {animal.Food} kg).");
        animal.Food = newFoodAmount;
    }

    public double GetTotalFood()
    {
        Console.WriteLine($"{_totalFood} is the total food");
        return _totalFood;
    }

    public List<IAlive.Herbo> GetAnimalsForContactZoo()
    {
        Console.WriteLine("Animals in contact zoo:");
        foreach (var animal in _animalsForContactZoo)
        {
            Console.WriteLine($"    {animal.Name}, kindness: {animal.Kindness}");
        }
        Console.WriteLine();
        return _animalsForContactZoo;
    }
    
    
    private void OnAnimalFoodChanged(double correction)
    {
        _totalFood += correction;
    }
    
    private readonly List<IAlive.Herbo> _animalsForContactZoo = [];
}