using RimWorld;
using Verse;

namespace Fisto;

[DefOf]
public static class PawnKindDefOf
{
    public static PawnKindDef Fisto;

    static PawnKindDefOf()
    {
        DefOfHelper.EnsureInitializedInCtor(typeof(PawnKindDefOf));
    }
}