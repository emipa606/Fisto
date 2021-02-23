using RimWorld;
using Verse;

namespace Fisto
{
    // Token: 0x02000007 RID: 7
    [DefOf]
    public static class PawnKindDefOf
    {
        // Token: 0x04000003 RID: 3
        public static PawnKindDef Fisto;

        // Token: 0x06000009 RID: 9 RVA: 0x00002132 File Offset: 0x00000332
        static PawnKindDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(PawnKindDefOf));
        }
    }
}