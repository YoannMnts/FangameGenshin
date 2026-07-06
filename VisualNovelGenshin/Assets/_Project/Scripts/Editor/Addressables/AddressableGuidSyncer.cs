#if UNITY_EDITOR
using Project.Core.Scripts.Datas;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;

namespace Project.Core.Scripts.Addressables
{

    public static class AddressableGuidSyncer
    {
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            ObjectChangeEvents.changesPublished += OnChangesPublished;
        }

        private static void OnChangesPublished(ref ObjectChangeEventStream stream)
        {
            for (int i = 0; i < stream.length; i++)
            {
                if (stream.GetEventType(i) != ObjectChangeKind.ChangeAssetObjectProperties)
                    continue;

                stream.GetChangeAssetObjectPropertiesEvent(i, out var e);
                var asset = EditorUtility.EntityIdToObject(e.entityId); 
                
                if (asset is ScriptableData scriptableData)
                    SyncGuid(scriptableData);
            }
        }

        private static void SyncGuid(ScriptableData data)
        {
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            if (settings == null) return;

            var assetPath = AssetDatabase.GetAssetPath(data);
            var assetGuid = AssetDatabase.AssetPathToGUID(assetPath);
            var entry = settings.FindAssetEntry(assetGuid);

            if (entry == null) return;

            entry.address = data.ID.ToString();
            settings.SetDirty(AddressableAssetSettings.ModificationEvent.EntryModified, 
                entry, true);
        }
    }
}
#endif
