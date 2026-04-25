namespace ParallellProgrammingCSharpDomeTrainProCourse.Samples.ThanksGiving
{
    public class TaskWhenAllThanksGivingDemo : IRunAsyncDemo
    {

        public async Task RunAsyncDemo()
        {
            var turkey = new Turkey();
            var gravy = new Gravy();
            var mashedPotatoes = new MashedPotatoes();
            var stuffing = new Stuffing();

            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(4));

            var token = cancellationTokenSource.Token;

            Console.WriteLine("Cooking started");

            try
            {

                await Task.WhenAll(turkey.Cook(), gravy.Cook(), mashedPotatoes.Cook(), stuffing.Cook(token))
                    .WaitAsync(token);

                Console.WriteLine("Dinner is ready!");

            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Error: Cooking took too long!");
            }

         
        }

    }
}
