using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    #region Fields

    private readonly SceneHandler _sceneHandler = new SceneHandler();

    #endregion

    #region Methods

    public void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly!!!!");
                break;
            case "Finish":
                Debug.Log("Finish!!!!");
                break;
            case "Fuel":
                Debug.Log("Fuel!!!!");
                break;
            default:
                _sceneHandler.ReloadLevel();
                break;
        }
    }

    #endregion
}
