namespace ParallellProgrammingCSharpDomeTrainProCourse.Samples.WhenAnyThanksGiving
{
    public class TaskWhenAllThanksGivingDemo : IRunAsyncDemo
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

            await Task.WhenAll(
                turkey.Cook(token),
                gravy.Cook(token),
                mashedPotatoes.Cook(token),
                stuffing.Cook(token)
                );
        }

    }
}
