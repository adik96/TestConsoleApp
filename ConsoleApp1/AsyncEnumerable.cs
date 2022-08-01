
namespace AsyncEnumerable;

public static class AsyncEnumerableTester
{
    public static async IAsyncEnumerable<string> ReadWordsFromStreamAsync()
    {
        string text =
            @"Ham hock ground round ipsum drumstick turkey nulla chicken aliqua turducken.
            Laborum turducken t-bone esse sirloin.  Cillum prosciutto laborum, 
            pastrami kevin rump ad elit pork loin commodo pork belly pork chop excepteur eiusmod filet mignon. 
            Nostrud jowl turkey bresaola in in.  Sed in exercitation lorem.  Alcatra drumstick frankfurter cupim meatball fatback.  
            Pastrami ut drumstick swine shoulder anim aliqua pancetta.";


        using var readStream = new StringReader(text);

        string? line = await readStream.ReadLineAsync();

        while (line != null)
        {
            yield return line;

            await Task.Delay(2000);

            line = await readStream.ReadLineAsync();
        }
    }
}