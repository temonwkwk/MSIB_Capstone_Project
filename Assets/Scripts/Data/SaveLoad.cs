using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveGame()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SceneSaved", activeScene);

        int gameProgress = GameData.instance.progressData;
        PlayerPrefs.SetInt("gameProgress", gameProgress);

        int powerUpAvaiable = PowerIndicator.instance.maxPower;
        PlayerPrefs.SetInt("powerUp", powerUpAvaiable);

    }

    public void LoadGame()
    {
        if(PlayerPrefs.HasKey("SceneSaved"))
        {
            string lastScene = PlayerPrefs.GetString("SceneSaved");
            SceneManager.LoadScene(lastScene); 
        }

        GameData.instance.progressData = PlayerPrefs.GetInt("gameProgress");
        PowerIndicator.instance.maxPower = PlayerPrefs.GetInt("powerUp");

        /*        if(PlayerPrefs.HasKey("gameProgress"))
                {
                    //int loadProgress = PlayerPrefs.GetInt("gameProgress");
                    //GameData.instance.progressData = loadProgress;
                }*/
    }

    public void ResetNewGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
