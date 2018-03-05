using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayTutorial()
    {
        GameController.isTutorialMode = true;
        Initiate.Fade("Tutorial", Color.cyan, 0.5f);
    }

    public void PlayLevel1()
    {
        GameController.isTutorialMode = false;
        Initiate.Fade("Level1", Color.cyan, 0.5f);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
