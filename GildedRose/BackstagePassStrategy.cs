using GildedRoseKata;

namespace GildedRose
{
    public class BackstagePassStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
                if (item.SellIn <= 10)
                {
                    item.Quality++;
                }
                if (item.SellIn <= 5)
                {
                    item.Quality++;
                }
            }
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
