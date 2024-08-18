using System.Collections;
using System.Drawing;
using Inventor;

namespace InventorRibbonBrowser;

class RibbonsInfo : Ribbons
{
    private readonly Ribbons _ribbons;

    public RibbonsInfo(Ribbons ribbons)
    {
        _ribbons = ribbons;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_ribbons).GetEnumerator();
    }

    public ObjectTypeEnum Type => _ribbons.Type;

    public Application Application => _ribbons.Application;

    public Ribbon this[object index] => _ribbons[index];

    public int Count => _ribbons.Count;

    IEnumerator Ribbons.GetEnumerator()
    {
        return _ribbons.GetEnumerator();
    }
}