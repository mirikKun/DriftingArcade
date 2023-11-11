using System;

namespace Data
{
    [Serializable]
    public class MoneyData
    {
        public int _coins;
        public Action Changed;

        public void Collect(int newCoins)
        {
            _coins += newCoins;
            Changed?.Invoke();
        }
    }
}