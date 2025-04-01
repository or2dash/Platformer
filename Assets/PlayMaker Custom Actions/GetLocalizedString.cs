using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using HutongGames.PlayMaker;

[HutongGames.PlayMaker.ActionCategory("Localization")]
[HutongGames.PlayMaker.Tooltip("Gets a localized string from the specified table and key.")]
public class GetLocalizedString : FsmStateAction
{
    [HutongGames.PlayMaker.Tooltip("Name of the localization table.")]
    public FsmString tableName;

    [HutongGames.PlayMaker.Tooltip("Key of the localized string in the table.")]
    public FsmString entryKey;

    [HutongGames.PlayMaker.UIHint(HutongGames.PlayMaker.UIHint.Variable)]
    [HutongGames.PlayMaker.Tooltip("The localized string result.")]
    public FsmString storeResult;

    public override void Reset()
    {
        tableName = null;
        entryKey = null;
        storeResult = null;
    }

    public override void OnEnter()
    {
        if (string.IsNullOrEmpty(tableName.Value) || string.IsNullOrEmpty(entryKey.Value))
        {
            Debug.LogError("Table Name and Entry Key must be specified.");
            Finish();
            return;
        }

        // Get the localized string
        var localizedString = LocalizationSettings.StringDatabase.GetLocalizedString(tableName.Value, entryKey.Value);
        storeResult.Value = localizedString;

        Finish();
    }
}
