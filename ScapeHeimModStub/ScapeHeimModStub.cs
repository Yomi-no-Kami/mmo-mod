using BepInEx;
using HarmonyLib;
using Jotunn;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using ScapeHeimModStub.com.scapeheim;
using ScapeHeimModStub.com.scapeheim.content.customcontent;
using ScapeHeimModStub.com.scapeheim.entity.player.shops;
using ScapeHeimModStub.com.scapeheim.entity.player.shops.ui;
using ScapeHeimModStub.com.scapeheim.entity.player.skill;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.fletching;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.herblore;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.slayer;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.smithing;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;
using System.IO;
using System.Linq;
using UnityEngine;

/**
 * ScapeHeimModStub.cs
 * @author VerZik
 */
namespace ScapeHeimModStub
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class ScapeHeimModStub : BaseUnityPlugin
    {
        public const string PluginGUID = "com.scapeheim.scapeheimthemmo";
        public const string PluginName = "ScapeHeim";
        public const string PluginVersion = "0.0.1";

        public static CustomLocalization Localization =
            LocalizationManager.Instance.GetLocalization();

        private Harmony _harmony;

        /**
         * What happens when the Valheim.exe file is ran
         */
        private void Awake()
        {
            Logger.LogInfo("[ScapeHeim]: ScapeHeim has landed and is now starting up...");


            _harmony = new Harmony(PluginGUID);
            _harmony.PatchAll();
            Jotunn.Logger.LogInfo("[ScapeHeim]: Harmony patches loaded...");

            InitializeSkills();
            Jotunn.Logger.LogInfo("[ScapeHeim]: Custom skills loaded...");

            // Gets the name of the custom assemblies we make
            //Jotunn.Logger.LogInfo(string.Join(", ", typeof(ScapeHeimModStub).Assembly.GetManifestResourceNames()));
            ScapeHeimContent.Init();
            Jotunn.Logger.LogInfo("[ScapeHeim]: Custom unity prefabs loaded...");

            /**
             * IF ENABLED, press F8 nearby to view the names of prefabs/gameobjects
             */
            if (Constants.DEBUG_GAMEOBJECTS) {
                GameObject debugObj = new GameObject("DebugObjectScanner");
                UnityEngine.Object.DontDestroyOnLoad(debugObj);
                debugObj.AddComponent<com.scapeheim.utility.DebugObjectScanner>();

                Jotunn.Logger.LogInfo("[ScapeHeim]: GameObject Debug scanner loaded...");
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                ShopUI.Show();
            }
        }

        private void OnDestroy()
        {
            _harmony?.UnpatchSelf();
        }

        /**
         * Initialize our custom skills, and content related to skills
         */
        private void InitializeSkills()
        {
            SkillRegistry.Register(new SmithingSkill());
            SkillRegistry.Register(new SlayerSkill());
            SkillRegistry.Register(new FletchingSkill());
            SkillRegistry.Register(new HerbloreSkill());

            SkillLevelUnlockPatch.Init(this); // Initialize custom prefab level up popup prefabs
        }
    }
}