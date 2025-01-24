using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using CustomBatteries.API;
using HarmonyLib;
using Nautilus.Utility;


namespace NuclearBatteries
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    [BepInDependency("com.snmodding.nautilus", BepInDependency.DependencyFlags.HardDependency)]
    public class Main : BaseUnityPlugin
    {
        #region[Declarations]
        public const string
            MODNAME = "BiochemicalBatteries",
            AUTHOR = "Metious",
            GUID = AUTHOR + "_" + MODNAME,
            VERSION = "1.0.0.0";
        #endregion
        private static readonly Assembly myAssembly = Assembly.GetExecutingAssembly();
        private static readonly string ModPath = Path.GetDirectoryName(myAssembly.Location);
        private static readonly string AssetsFolder = Path.Combine(ModPath, "Assets");
        public const string modName = "[NuclearBattery]";
          public static readonly List<TechType> typesToMakePickupables = new();
          public static readonly List<TechType> NuclearBatteries = new();
    
   
        private static void CreateAndPatchPrefabs()
        {
            var NuclearBattery = new CbBattery()
            {
                ID = "NuclearBattery",
                Name = "Ion-fused Nuclear Battery",
                FlavorText = "A Battery made by the Precursor Technology and its interaction with Nuclear Power.",
                EnergyCapacity = 2500,
                CraftingMaterials = new List<TechType>() { TechType.UraniniteCrystal,
                    TechType.UraniniteCrystal,
                    TechType.PrecursorIonCrystal,
                    TechType.Lead,
                    TechType.Lead,
                    TechType.Nickel },
                UnlocksWith = TechType.UraniniteCrystal,




                CustomIcon = ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "NuclearBattery.png")),
                CBModelData = new CBModelData()
                {
                    CustomTexture = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "NuclearBatteryskin.png")),
                    //CustomNormalMap = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "battery_normal.png")),
                    CustomSpecMap = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "NuclearBatteryspec.png")),
                    CustomIllumMap = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "NuclearBatteryillum.png")),
                    CustomIllumStrength = 1f,
                    UseIonModelsAsBase = true,
                },


            };
            NuclearBattery.Patch();
            NuclearBatteries.Add(NuclearBattery.TechType);
            var skinPath = Path.Combine(AssetsFolder, "NuclearCellskin.png");
            
            var specPath = Path.Combine(AssetsFolder, "NuclearCellspec.png");
            var illumPath = Path.Combine(AssetsFolder, "NuclearCellillum.png");

            var skin = ImageUtils.LoadTextureFromFile(skinPath);
            //var normal = ImageUtils.LoadTextureFromFile(normalPath);
            var spec = ImageUtils.LoadTextureFromFile(specPath);
            var illum = ImageUtils.LoadTextureFromFile(illumPath);


            var NuclearPowercell = new CbPowerCell()
            {
                EnergyCapacity = 5000,
                ID = "NuclearPowercell",
                Name = "Ion-fused Nuclear Power Cell",
                FlavorText = "A Power Cell made by the Precursor Technology and its interaction with Nuclear Power.",


                CraftingMaterials = new List<TechType>() { NuclearBattery.TechType, NuclearBattery.TechType, TechType.Silicone },
                UnlocksWith = NuclearBattery.TechType,

                CustomIcon = ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "NuclearCell.png")),
                CBModelData = new CBModelData()
                {
                    CustomTexture = skin,
                    //CustomNormalMap = normal,
                    CustomSpecMap = spec,
                    CustomIllumMap = illum,
                    CustomIllumStrength = 1f,
                    UseIonModelsAsBase = true,
                },


            };

            NuclearPowercell.Patch();
            NuclearBatteries.Add(NuclearPowercell.TechType);
            var VolatileBattery = new CbBattery()
            {
                ID = "VolatileBattery",
                Name = "Volatile Radioactive Battery",
                FlavorText = "This Battery pulsates with Radioactive energy. Extreme caution when handling; Contains too much Uranium!",
                EnergyCapacity = 5250,
                CraftingMaterials = new List<TechType>() { TechType.UraniniteCrystal,
                    TechType.UraniniteCrystal,
                    TechType.UraniniteCrystal,
                    TechType.Lead,
                    TechType.Lead,
                    TechType.Sulphur,
                    TechType.Sulphur,
                    TechType.Sulphur },
                UnlocksWith = NuclearBattery.TechType,




                CustomIcon = ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "VolatileBattery.png")),
                CBModelData = new CBModelData()
                {
                    CustomTexture = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "VolatileBatteryskin.png")),
                    //CustomNormalMap = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "battery_normal.png")),
                    CustomSpecMap = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "VolatileBatteryspec.png")),
                    CustomIllumMap = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "VolatileBatteryillum.png")),
                    CustomIllumStrength = 1f,
                    UseIonModelsAsBase = true,
                },


            };
            VolatileBattery.Patch();
            NuclearBatteries.Add(VolatileBattery.TechType);
            var skinPath2 = Path.Combine(AssetsFolder, "VolatileCellskin.png");

            var specPath2 = Path.Combine(AssetsFolder, "VolatileCellspec.png");
            var illumPath2 = Path.Combine(AssetsFolder, "VolatileCellillum.png");

            var skin2 = ImageUtils.LoadTextureFromFile(skinPath);
            //var normal = ImageUtils.LoadTextureFromFile(normalPath);
            var spec2 = ImageUtils.LoadTextureFromFile(specPath);
            var illum2 = ImageUtils.LoadTextureFromFile(illumPath);


            var VolatilePowercell = new CbPowerCell()
            {
                EnergyCapacity = 10500,
                ID = "VolatilePowercell",
                Name = "Volatile Radioactive Power Cell",
                FlavorText = "This Power Cell pulsates with Radioactive energy. Extreme caution when handling; Contains too much Uranium!",


                CraftingMaterials = new List<TechType>() { VolatileBattery.TechType, VolatileBattery.TechType, TechType.Silicone },
                UnlocksWith = NuclearPowercell.TechType,

                CustomIcon = ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "VolatileCell.png")),
                CBModelData = new CBModelData()
                {
                    CustomTexture = skin,
                    //CustomNormalMap = normal,
                    CustomSpecMap = spec,
                    CustomIllumMap = illum,
                    CustomIllumStrength = 1f,
                    UseIonModelsAsBase = true,
                },


            };

            VolatilePowercell.Patch();
            NuclearBatteries.Add(VolatilePowercell.TechType);
        
        var CBDeepBattery = new CbBattery()
        {
            ID = "CBDeepBattery",
            Name = "Deep Battery",
            FlavorText = "A longer lasting battery created from rare materials and stronger chemicals.",
            EnergyCapacity = 250,
            CraftingMaterials = new List<TechType>() { TechType.WhiteMushroom, TechType.WhiteMushroom,
                    TechType.Lithium,
                    TechType.AluminumOxide,
                    TechType.Magnetite },
            UnlocksWith = TechType.WhiteMushroom,




            CustomIcon = ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "DeepBattery.png")),
            CBModelData = new CBModelData()
            {
                CustomTexture = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "DeepBatteryskin.png")),
                //CustomNormalMap = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "battery_normal.png")),
                CustomSpecMap = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "DeepBatteryspec.png")),
                CustomIllumMap = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "DeepBatteryillum.png")),
                CustomIllumStrength = 1f,
                UseIonModelsAsBase = false,
            },


        };
        CBDeepBattery.Patch();
            NuclearBatteries.Add(CBDeepBattery.TechType);
            var skinPath3 = Path.Combine(AssetsFolder, "DeepCellskin.png");

        var specPath3 = Path.Combine(AssetsFolder, "DeepCellspec.png");
        var illumPath3 = Path.Combine(AssetsFolder, "DeepCellillum.png");

        var skin3 = ImageUtils.LoadTextureFromFile(skinPath);
        //var normal = ImageUtils.LoadTextureFromFile(normalPath);
        var spec3 = ImageUtils.LoadTextureFromFile(specPath);
        var illum3 = ImageUtils.LoadTextureFromFile(illumPath);


        var CBDeepCell = new CbPowerCell()
        {
            EnergyCapacity = 500,
            ID = "CBDeepCell",
            Name = "Deep Power Cell",
            FlavorText = "A long lasting power cell created from rare materials and stronger chemicals.",


            CraftingMaterials = new List<TechType>() {  CBDeepBattery.TechType, CBDeepBattery.TechType,
                    TechType.Silicone },
            UnlocksWith = CBDeepBattery.TechType,

            CustomIcon = ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "DeepCell.png")),
            CBModelData = new CBModelData()
            {
                CustomTexture = skin,
                //CustomNormalMap = normal,
                CustomSpecMap = spec,
                CustomIllumMap = illum,
                CustomIllumStrength = 1f,
                UseIonModelsAsBase = false,
            },


        };

        CBDeepCell.Patch();
            NuclearBatteries.Add(CBDeepCell.TechType);
        
        var enzymeBattery = new CbBattery()
        {
            ID = "enzymeBattery",
            Name = "Enzyme-Charged Ion Battery",
            FlavorText = "A new battery based on the discovery of a chemical interaction between hatching enzymes, radiation, and ion crystals.",
            EnergyCapacity = 1000,
            CraftingMaterials = new List<TechType>() { TechType.PrecursorIonCrystal, TechType.HatchingEnzymes, TechType.HatchingEnzymes, TechType.Lead, TechType.UraniniteCrystal, TechType.UraniniteCrystal },
            UnlocksWith = TechType.HatchingEnzymes,




            CustomIcon = ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "EnzymeBattery.png")),
            CBModelData = new CBModelData()
            {
                CustomTexture = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "EnzymeBatteryskin.png")),
                //CustomNormalMap = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "battery_normal.png")),
                CustomSpecMap = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "EnzymeBatteryspec.png")),
                CustomIllumMap = ImageUtils.LoadTextureFromFile(Path.Combine(AssetsFolder, "EnzymeBatteryillum.png")),
                CustomIllumStrength = 1f,
                UseIonModelsAsBase = false,
            },


        };
         enzymeBattery.Patch();
            NuclearBatteries.Add(enzymeBattery.TechType);
            var skinPath4 = Path.Combine(AssetsFolder, "EnzymeCellskin.png");

        var specPath4 = Path.Combine(AssetsFolder, "EnzymeCellskin.png");
        var illumPath4 = Path.Combine(AssetsFolder, "EnzymeCellillum.png");

        var skin4 = ImageUtils.LoadTextureFromFile(skinPath);
        //var normal = ImageUtils.LoadTextureFromFile(normalPath);
        var spec4 = ImageUtils.LoadTextureFromFile(specPath);
        var illum4 = ImageUtils.LoadTextureFromFile(illumPath);


        var CBEnzymeCell = new CbPowerCell()
        {
            EnergyCapacity = 2000,
            ID = "EnzymePowerCell",
            Name = "Enzyme-Charged Ion Power Cell",
            FlavorText = "A new power cell based on the discovery of a chemical interaction between hatching enzymes, radiation, and ion crystals.",


            CraftingMaterials = new List<TechType>() { enzymeBattery.TechType, enzymeBattery.TechType, TechType.Silicone },
            UnlocksWith = TechType.HatchingEnzymes,

            CustomIcon = ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "EnzymeCell.png")),
            CBModelData = new CBModelData()
            {
                CustomTexture = skin,
                //CustomNormalMap = normal,
                CustomSpecMap = spec,
                CustomIllumMap = illum,
                CustomIllumStrength = 1f,
                UseIonModelsAsBase = false,
            },


        };

            CBEnzymeCell.Patch();
            NuclearBatteries.Add(CBEnzymeCell.TechType);
        }


    public void Awake()
        {
            Debug.WriteLine(modName,"1.0.0");
            try
            {
                var harmony = new Harmony("Metious.nuclearbatteries.mod");
                
               
                CreateAndPatchPrefabs();
                Debug.WriteLine("Nuclear Battery and PowerCell Patched");
                Debug.WriteLine("Volatile Battery and PowerCell Patched");
                Debug.WriteLine("Deep Battery and PowerCell Patched");
                Debug.WriteLine("Enzyme Battery and PowerCell Patched");




                harmony.PatchAll(Assembly.GetExecutingAssembly());

                Debug.WriteLine(modName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(modName, ex);
            }
        }
    }
}
