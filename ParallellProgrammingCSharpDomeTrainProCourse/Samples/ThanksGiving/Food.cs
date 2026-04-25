namespace ParallellProgrammingCSharpDomeTrainProCourse.Samples.ThanksGiving
{
    public abstract class Food
    {



        readonly TimeSpan _cookTime; 

        public string Name { get; }

        protected Food(TimeSpan cookTime)
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

    public class Turkey() : Food(TimeSpan.FromSeconds(5));
    public class MashedPotatoes() : Food(TimeSpan.FromSeconds(2));
    public class Gravy() : Food(TimeSpan.FromSeconds(1));
    public class Stuffing() : Food(TimeSpan.FromSeconds(2));


}
