using GildedRoseKata;

namespace GildedRose
{
    public static class UpdateStrategyFactory
    {
        public static IUpdateStrategy GetStrategy(Item item)
        {
            return item.Name switch
            {
                "Sulfuras, Hand of Ragnaros" => new SulfurasStrategy(),
                "Aged Brie" => new AgedBrieStrategy(),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassStrategy(),
                _ => new RegularItemStrategy(),
            };
        }
    }

}
