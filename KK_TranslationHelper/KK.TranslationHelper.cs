﻿using BepInEx;
using KKAPI;
using UnityEngine.SceneManagement;
using Manager;
using System;
using System.Linq;
using BepInEx.Configuration;
using ExtensibleSaveFormat;

namespace TranslationHelperPlugin
{
    [BepInPlugin(GUID, PluginName, Version)]
    public partial class TranslationHelper : BaseUnityPlugin
    {
        public static ConfigEntry<bool> KK_GivenNameFirst { get; private set; }
        internal void GameSpecificAwake()
        {
            SplitNamesBeforeTranslate = false;
        }

        internal void GameSpecificStart()
        {
            SplitNamesBeforeTranslate = false;

            KK_GivenNameFirst = Config.Bind("Translate Card Name Options", "Show given name first",
                false, "Reverses the order of names to be Given Family instead of Family Given");
            
        }

        internal static string ProcessFullnameString(string input)
        {
            if (!KK_GivenNameFirst.Value) return input;
            if (string.IsNullOrEmpty(input)) return input;
            var parts = input.Split();
            return parts.Length != 2 ? input : string.Join(" ", parts.Reverse().ToArray());
        }
    }
}
