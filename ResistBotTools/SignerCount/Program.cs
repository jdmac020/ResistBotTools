using System;

namespace SignerCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = new SignerCount(new CustomRestClient());
            
        }
    }
}
