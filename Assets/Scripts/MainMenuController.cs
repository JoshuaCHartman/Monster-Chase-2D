using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void PlayGame()
    {
        //Debug.Log("Button Pressed");
        //SceneManager.LoadScene("Gameplay");

        //string clickedCharacter = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        // ^^^ not importing whole library for one reference

        //Debug.Log("Selected Character : " + clickedCharacter);

        int selectedCharacter = 
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        // to use different character names other than 0,1,2, etc, cast from string to int or use an enum

        GameManager.instance.CharacterIndex = selectedCharacter;

        SceneManager.LoadScene("Gameplay");

       


    }
}
