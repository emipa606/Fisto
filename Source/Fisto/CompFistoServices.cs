using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace Fisto
{
    // Token: 0x02000004 RID: 4
    public class CompFistoServices : ThingComp
    {
        // Token: 0x06000005 RID: 5 RVA: 0x000020E5 File Offset: 0x000002E5
        public override IEnumerable<FloatMenuOption> CompFloatMenuOptions(Pawn selPawn)
        {
            var option = new FloatMenuOption("Acquire services from Fisto",
                delegate
                {
                    selPawn.jobs.TryTakeOrderedJob(new Job(JobDefOf.AquireServices, new LocalTargetInfo(parent)));
                });
            yield return option;
        }
    }
}