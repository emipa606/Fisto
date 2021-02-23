using RimWorld;
using Verse;

namespace Fisto
{
    // Token: 0x02000006 RID: 6
    [DefOf]
    public static class ThingDefOf
    {
        // Token: 0x04000002 RID: 2
        public static ThingDef Fisto;

        // Token: 0x06000008 RID: 8 RVA: 0x0000211F File Offset: 0x0000031F
        static ThingDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThingDefOf));
        }
    }
}