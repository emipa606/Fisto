using RimWorld;
using Verse;

namespace Fisto;

[DefOf]
public static class ThingDefOf
{
    public static ThingDef Fisto;

    static ThingDefOf()
    {
        DefOfHelper.EnsureInitializedInCtor(typeof(ThingDefOf));
    }
}