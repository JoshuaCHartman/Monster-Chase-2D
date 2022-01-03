using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance; // make static instance so variables can be accessed and set 
                                        // in other classes (main menu controller) ex- intance.CharacterIndex


    [SerializeField] private GameObject[] characters; // character choice

    private int _characterIndex;
    public int CharacterIndex 
    { 
        get { return _characterIndex; } 
        set { _characterIndex = value; } 
    }

    private void Awake()
    {
        // make GameManager singleton - only 1 copy

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // save this gameObject when moving between scenes
        }
        else
        {
            Destroy(gameObject); // destroys gameObject component attached to (self) - prevents dupes 
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinsihedLoading; // delegate subscribing
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinsihedLoading; // delegate UNsubscribing
    }

    void OnLevelFinsihedLoading(Scene scene, LoadSceneMode mode) // listening 
    {
        if (scene.name == "Gameplay") // other scenes could be loaded, character not instantiated unless add other tags or else statements
        {
            Instantiate(characters[CharacterIndex]);
        }
    }

}
