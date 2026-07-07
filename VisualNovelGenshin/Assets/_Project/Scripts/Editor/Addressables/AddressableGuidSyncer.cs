using Project.Core.Scripts.Datas;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace Project.Core.Scripts.Addressables
{ 
    public static class AddressableGuidSyncer
    {
        [MenuItem("Tools/Sync Addressable GUIDs")]
        public static void SyncAll()
        {
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            if (settings == null)
            {
                Debug.LogError("No Addressable Settings found.");
                return;
            }

            var guids = AssetDatabase.FindAssets($"t:{nameof(ScriptableData)}");
            int synced = 0;

            foreach (var assetGuid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(assetGuid);
                var data = AssetDatabase.LoadAssetAtPath<ScriptableData>(path);

                if (data == null) 
                    continue;

                var entry = settings.FindAssetEntry(assetGuid);
                if (entry == null) 
                    continue; 

                entry.address = data.ID.ToString();
                synced++;
            }

            settings.SetDirty(AddressableAssetSettings.ModificationEvent.EntryModified, 
                null, true);
            
            AssetDatabase.SaveAssets();
            Debug.Log($"Synced {synced} Addressable GUIDs.");
        }
    }
}