namespace ParallellProgrammingCSharpDomeTrainProCourse.Samples.ThanksGiving
{
    public abstract class FoodV2
    {



        readonly TimeSpan _cookTime; 

        public string Name { get; }

        protected FoodV2(TimeSpan cookTime)
        {
            _cookTime = cookTime;
            Name = GetType().Name;
        }

        public async Task<string> Cook(CancellationToken token = default)
        {
            //Trace.AutoFlush = true; 
            Console.WriteLine($"Cooking {Name}");

            await Task.Delay(_cookTime, token);
            Console.WriteLine($"{Name} Completed");

            return Name;
        }

    }

    public class TurkeyV2() : FoodV2(TimeSpan.FromSeconds(5));
    public class MashedPotatoesV2() : FoodV2(TimeSpan.FromSeconds(2));
    public class GravyV2() : FoodV2(TimeSpan.FromSeconds(1));
    public class StuffingV2() : FoodV2(TimeSpan.FromSeconds(2));


}
