namespace FinalProject.View;

using System;
using System.Threading;
using System.Threading.Tasks;
// Code from Gemini to run two Tasks simultaneously
public static class ConsoleSpinner
{
    public static async Task<T> RunWithLoadingAsync<T>(string message, Func<Task<T>> apiTask)
    {
        using var cts = new CancellationTokenSource();
        int initialLeft = Console.CursorLeft;
        int initialTop = Console.CursorTop;

        // Start background animation task
        Task animationTask = Task.Run(async () =>
        {
            int dotCount = 0;
            while (!cts.Token.IsCancellationRequested)
            {
                try
                {
                    // Reset cursor position to overwrite the current line
                    Console.SetCursorPosition(initialLeft, initialTop);

                    // Build string with dots and padding to clear leftover characters
                    string dots = new string('.', dotCount);
                    Console.Write($"{message}{dots}".PadRight(message.Length + 4));

                    dotCount = (dotCount + 1) % 4; // Cycle dots: 0 -> 1 -> 2 -> 3 -> 0
                }
                catch
                {
                    // Ignore terminal resize/cursor issues
                    break;
                }

                // Delay using Task.Delay without passing cts.Token to prevent TaskCanceledException
                // Check cancellation in short increments for responsive stopping
                for (int i = 0; i < 8; i++)
                {
                    if (cts.Token.IsCancellationRequested) break;
                    await Task.Delay(50);
                }
            }
        });

        try
        {
            // Execute the API call
            return await apiTask();
        }
        finally
        {
            // Signal animation to stop and wait for completion
            cts.Cancel();
            await animationTask;

            // Clear loading line and restore cursor position
            try
            {
                Console.SetCursorPosition(initialLeft, initialTop);
                Console.Write(new string(' ', message.Length + 4));
                Console.SetCursorPosition(initialLeft, initialTop);
            }
            catch
            {
                // Handle non-standard consoles gracefully
            }
        }
    }
}