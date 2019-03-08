using System;
using System.Reflection;
using UnityModManagerNet;
using Harmony12;
using UnityEngine;

namespace HarderEconomyMod
{
    public class Main
    {
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = HarmonyInstance.Create(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            // Something
            return true; // If false the mod will show an error.
        }
    }

    [HarmonyPatch(typeof(JobPaymentCalculator), "CalculateHaulPayment")]
    class JobPaymentCalculator_CalculateHaulPayment_Patch
    {
        static void Postfix(ref float __result)
        {
            __result = Mathf.Round(__result * 0.25f);
        }
    }

    [HarmonyPatch(typeof(JobPaymentCalculator), "CalculateShuntingPayment")]
    class JobPaymentCalculator_CalculateShuntingPayment_Patch
    {
        static void Postfix(ref float __result)
        {
            __result = Mathf.Round(__result * 0.25f);
        }
    }
}