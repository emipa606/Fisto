﻿using RimWorld;
using UnityEngine;
using Verse;

namespace Fisto
{
    // Token: 0x02000008 RID: 8
    public class IncidentWorker_FistoPasses : IncidentWorker
    {
        // Token: 0x0600000A RID: 10 RVA: 0x00002148 File Offset: 0x00000348
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            var map = (Map) parms.target;
            return !map.gameConditionManager.ConditionIsActive(GameConditionDefOf.ToxicFallout) &&
                   map.mapTemperature.SeasonAndOutdoorTemperatureAcceptableFor(ThingDefOf.Fisto) &&
                   TryFindEntryCell(map, out _);
        }

        // Token: 0x0600000B RID: 11 RVA: 0x00002198 File Offset: 0x00000398
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            var map = (Map) parms.target;
            bool result;
            if (!TryFindEntryCell(map, out var intVec))
            {
                result = false;
            }
            else
            {
                var fisto = PawnKindDefOf.Fisto;
                var num = StorytellerUtility.DefaultThreatPointsNow(map);
                var num2 = GenMath.RoundRandom(num / fisto.combatPower);
                var num3 = Rand.RangeInclusive(2, 4);
                num2 = Mathf.Clamp(num2, 1, num3);
                var num4 = Rand.RangeInclusive(90000, 150000);
                if (!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(intVec, map, 10f,
                    out var invalid))
                {
                    invalid = IntVec3.Invalid;
                }

                Pawn pawn = null;
                for (var i = 0; i < num2; i++)
                {
                    var loc = CellFinder.RandomClosewalkCellNear(intVec, map, 10);
                    pawn = PawnGenerator.GeneratePawn(fisto);
                    GenSpawn.Spawn(pawn, loc, map, Rot4.Random);
                    pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + num4;
                    var isValid = invalid.IsValid;
                    if (isValid)
                    {
                        pawn.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(invalid, map, 10);
                    }
                }

                Find.LetterStack.ReceiveLetter("LetterLabelFistoPasses".Translate(fisto.label).CapitalizeFirst(),
                    "LetterFistoPasses".Translate(fisto.label), LetterDefOf.PositiveEvent, pawn);
                result = true;
            }

            return result;
        }

        // Token: 0x0600000C RID: 12 RVA: 0x00002308 File Offset: 0x00000508
        private bool TryFindEntryCell(Map map, out IntVec3 cell)
        {
            return RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f);
        }
    }
}