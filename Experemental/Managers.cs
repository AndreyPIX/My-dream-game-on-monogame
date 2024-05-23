using StrategyRTS.GameObjects;
using System.Collections.Generic;

namespace StrategyRTS.Experemental
{
    public class Managers<T> where T : GameObject
    {
        protected List<T> list;

    }
}
