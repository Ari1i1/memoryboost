using System;

namespace MemoryBoost.Services
{
    public class RandomNumbersService: IRandomNumbersService
    {
        public int GetRandomNumber()
        {
            Random rand = new Random();
            return rand.Next(1, 1);
        }
        public int GetRandomPlace(int numOfPlaces)
        {
            Random rand = new Random();
            return rand.Next(0, numOfPlaces);
        }
    }
}
