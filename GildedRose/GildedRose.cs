using GildedRose;

namespace GildedRoseKata;

public class GildedRose
{
    private IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            var strategy = UpdateStrategyFactory.GetStrategy(item);
            strategy.Update(item);
        }
    }
}