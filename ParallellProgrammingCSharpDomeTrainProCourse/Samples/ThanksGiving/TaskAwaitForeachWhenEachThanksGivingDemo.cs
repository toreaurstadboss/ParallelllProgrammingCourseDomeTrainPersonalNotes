using System.Diagnostics;

namespace ParallellProgrammingCSharpDomeTrainProCourse.Samples.ThanksGiving
{
   
    public class TaskAwaitForeachWhenEachThanksGivingDemo : IRunAsyncDemo
    {

        public async Task RunAsyncDemo()
        {
            var turkey = new Turkey();
            var gravy = new Gravy();
            var mashedPotatoes = new MashedPotatoes();
            var stuffing = new Stuffing();

            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            var token = cancellationTokenSource.Token;

            Console.WriteLine("Cooking started");

            List<Task<string>> cookingTaskList = [
                turkey.Cook(token),
                gravy.Cook(token),
                mashedPotatoes.Cook(token),
                stuffing.Cook()
                ];

            try
            {
                //meaning the same syntax with WhenEach : 
                //  await foreach (Task<string> completedCookingTask in Task.WhenEach(cookingTaskList).WithCancellation(token))


                await foreach (Task<string> completedCookingTask in cookingTaskList.ToAsyncEnumerable().WithCancellation(token))
                {
                    cookingTaskList.Remove(completedCookingTask);

                    var name = await completedCookingTask;
                    Trace.WriteLine($"Eating {name} ... {cookingTaskList.Count} items left!");
                }          
                Console.WriteLine("Dinner is ready! And you ate everything!");
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Error: Cooking took too long!");
            }


        }

    }
}
