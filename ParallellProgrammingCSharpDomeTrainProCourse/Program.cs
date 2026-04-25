using ParallellProgrammingCSharpDomeTrainProCourse.Samples.ThanksGiving;


System.Diagnostics.Trace.Listeners.Add(
    new System.Diagnostics.TextWriterTraceListener(Console.Out)
);

//await (new TaskWhenAllThanksGivingDemo()).RunAsyncDemo();

await (new TaskWhenAnyThanksGivingDemo()).RunAsyncDemo(); 



