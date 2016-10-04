using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.Services
{
    public interface IRandomNumberGenerator
    {
        int GetNext(int min, int max);
    }
}
