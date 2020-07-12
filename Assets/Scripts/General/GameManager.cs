using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject options;

    public static GameManager instance = null;

    private AudioManager audio;
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

    private void Start() {
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    #endregion

    #region Scene
    public void Play() {
        audio.Play("Click");
        SceneManager.LoadScene("Levels");
    }

    public void ToMenu() {
        audio.Play("Click");
        SceneManager.LoadScene("MainMenu");
    }

    public void Win() {
        SceneManager.LoadScene("YouWin");
    }

    public void Quit() {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
		    Application.Quit();
    #endif
    }
    #endregion


    public void ToggleOptions() {
        audio.Play("Click");
        options.SetActive(!options.activeSelf);
    }
}
