using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace Fisto
{
    // Token: 0x02000003 RID: 3
    public class JobDriver_AquireServices : JobDriver_Flick
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        protected override IEnumerable<Toil> MakeNewToils()
        {
            this.FailOnDespawnedNullOrForbidden(TargetIndex.A);
            this.FailOnDowned(TargetIndex.A);
            yield return Toils_Reserve.Reserve(TargetIndex.A);
            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.Touch);
            yield return Toils_General.WaitWith(TargetIndex.A, 300, true, true);
            AddFinishAction(delegate
            {
                var defName = "Numb";
                var named = DefDatabase<HediffDef>.GetNamed(defName, false);
                if (named != null)
                {
                    pawn.health.AddHediff(named);
                }
            });
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            var toilPawn = pawn;
            var targetA = job.targetA;
            var toilJob = job;
            return toilPawn.Reserve(targetA, toilJob, 1, -1, null, errorOnFailed);
        }
    }
}