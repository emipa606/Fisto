using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace Fisto;

public class CompFistoServices : ThingComp
{
    public override IEnumerable<FloatMenuOption> CompFloatMenuOptions(Pawn selPawn)
    {
        var option = new FloatMenuOption("FistoServices".Translate(),
            delegate
            {
                selPawn.jobs.TryTakeOrderedJob(new Job(JobDefOf.AquireServices, new LocalTargetInfo(parent)));
            });
        yield return option;
    }
}