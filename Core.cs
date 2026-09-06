using MelonLoader;
using Alta;
using System.Reflection;

[assembly: MelonInfo(typeof(ViridiumBuff.Core), "ViridiumBuff", "1.0.0", "CGNik", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace ViridiumBuff
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }

        public override void OnLateInitializeMelon()
        {
            if (!NetworkSceneManager.IsServer)
            {
                return;
            }
            PhysicalMaterial physicalMaterial_viridium = PhysicalMaterial.All.Where(mat => mat.Hash == 16222u).First();
            typeof(PhysicalMaterial).GetField("damageMultiplier", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(physicalMaterial_viridium, 2f);
            typeof(PhysicalMaterial).GetField("durabilityMultiplier", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(physicalMaterial_viridium, 4.5f);
        }
    }
}