using System;
namespace MemoryBoost.Services
{
    public interface IRandomNumbersService
    {
        int GetRandomNumber();
        int GetRandomPlace(int numOfPlaces);
    }
}
