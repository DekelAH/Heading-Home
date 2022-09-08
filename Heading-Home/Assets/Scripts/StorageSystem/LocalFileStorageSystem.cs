using Assets.Scripts.Infastructure;
using System;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.StorageSystem
{
    public class LocalFileStorageSystem : StorageSystem
    {
        protected override void LoadInternal()
        {
            if (File.Exists(Application.dataPath + "/save.txt"))
            {
                string json = File.ReadAllText(Application.dataPath + "/save.txt");
                Debug.Log("Loaded: " + json);

                var playerModel = PlayerModelProvider.Instance.GetCurrentSaveType;
                JsonUtility.FromJsonOverwrite(json, playerModel);
            }
            else
            {
                Debug.Log("No Save!");
            }
        }

        protected override void SaveInternal()
        {

            var playerModel = PlayerModelProvider.Instance.GetCurrentSaveType;
            string json = JsonUtility.ToJson(playerModel);
            File.WriteAllText(Application.dataPath + "/save.txt", json);

            Debug.Log("Saved!");
        }
    }
}
