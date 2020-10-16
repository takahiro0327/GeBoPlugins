﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GameLoadCharaFileSystem;
using HarmonyLib;

namespace TranslationHelperPlugin.Translation
{
    internal partial class Hooks
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(LobbyCharaSelectInfoScrollController), nameof(LobbyCharaSelectInfoScrollController.Init))]
        [HarmonyPatch(typeof(LobbyCharaSelectInfoScrollController1),
            nameof(LobbyCharaSelectInfoScrollController1.Init))]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "HarmonyPatch")]
        // ReSharper disable once InconsistentNaming
        private static void LobbyCharaSelectInfoScrollControllerInitPrefix(List<GameCharaFileInfo> _lst)
        {
            TranslateFileInfos(_lst);
        }
    }
}
