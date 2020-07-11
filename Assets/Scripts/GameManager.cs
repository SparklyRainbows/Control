using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    #region Unity_funcs
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } 
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Scene
    public void Play() {
        SceneManager.LoadScene("Levels");
    }

    public void Quit() {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
		    Application.Quit();
    #endif
    }
    #endregion
}
