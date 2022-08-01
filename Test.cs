using System;

namespace FirstConsoleApp
{
    public record Person
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Address { get; init; }
        public string City { get; init; }
        public string Country { get; init; }
    }



    public class Test
    {
        public Test() { }

        public static void Method()
        {
            var person = new Person
            {
                FirstName = "Joydip",
                LastName = "Kanjilal",
                Address = "192/79 Stafford Hills",
                City = "Hyderabad",
                Country = "India"
            };
        }
    }
}
