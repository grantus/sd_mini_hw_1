namespace sd_mini_hw_1_v2;

using Microsoft.Extensions.DependencyInjection;

internal static class Program
{

    public static void Main(string[] args)
    {

        var services = new ServiceCollection();
        var theVetClinic = new IVeterinaryClinic.VeterinaryClinic("The Vet Clinic", "somewhere");
        services.AddSingleton<IVeterinaryClinic>(theVetClinic);
        services.AddTransient<Zoo>(_ => new Zoo(theVetClinic));

        var provider = services.BuildServiceProvider();

        var theZoo = provider.GetRequiredService<Zoo>();
        

        var tiger = new IAlive.Tiger("The Tiger", 5, true, 0);
        var monkey = new IAlive.Monkey("The Monkey", 5, true, 1, 2);
        var rabbit = new IAlive.Rabbit("The Rabbit", 2, true, 2, 10);

        theZoo.AddAnimal(tiger);
        theZoo.AddAnimal(monkey);
        theZoo.AddAnimal(rabbit);
        theZoo.GetAnimals();
        theZoo.GetAnimalsForContactZoo();
        theZoo.UpdateAnimalFood(tiger, 6);
        theZoo.GetAnimals();
        theZoo.GetTotalFood();
        theZoo.UpdateAnimalFood(rabbit, 1);
        theZoo.GetTotalFood();
    }

}