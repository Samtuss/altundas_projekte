namespace AsyncTicketverkauf
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var buyers = Enumerable.Range(1, 20).Select(i => BuyTicketAsync($"Käufer {i}"));
            await Task.WhenAll(buyers);
            Console.WriteLine($"Finale Ticketanzahl: {availableTickets}");
            // Aufgabe 1:
            // Max 5 Tickets verkauft: 20
            // availableTickets am Ende: 0: -15
            // Restliche Käufer erhalten die Nachricht "Keine Tickets mehr!".: Ist nicht erfüllt
        }
        static SemaphoreSlim semaphore = new SemaphoreSlim(1,3);
        static int availableTickets = 5;
        static async Task BuyTicketAsync(string buyer)
        {
            await semaphore.WaitAsync();
            try
            {
                if (availableTickets > 0)
                {
                    await Task.Delay(10);
                    availableTickets--;
                    Console.WriteLine($"{buyer} kaufte Ticket. Noch {availableTickets} übrig.");
                }
                else
                {
                    Console.WriteLine($"{buyer}: Keine Tickets mehr!");
                }
            }
            finally
            {
                semaphore.Release();
            }
        }

    }
}
