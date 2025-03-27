using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HospitalManagement.Filters
{
    public class LongActionFilter: Attribute, IResourceFilter
    {
        private Stopwatch _stopwatch;

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            Console.WriteLine($"Executing: {context.ActionDescriptor.DisplayName}");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _stopwatch.Stop();
            Console.WriteLine($"Executed: {context.ActionDescriptor.DisplayName} Elapsed: {_stopwatch.Elapsed.Milliseconds} ms");
        }
    }
}
