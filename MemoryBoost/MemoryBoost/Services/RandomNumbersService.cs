using System;

namespace MemoryBoost.Services
{
    public class RandomNumbersService: IRandomNumbersService
    {
        public int GetRandomNumber()
        {
            Random rand = new Random();
            return rand.Next(1, 5);
        }
    }
}
