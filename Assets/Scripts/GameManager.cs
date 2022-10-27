using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string playerName;
    public int playerScore;

    public string bestPlayer;
    public int bestScore;

    public InputField nickField;
    public Text bestScoreText;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
       
    }
    private void Start()
    {
        LoadScore();
        bestScoreText.text = "Best Score : "+bestPlayer+" "+bestScore;   
        
        playerName=nickField.text;
    }
    

    [System.Serializable]
    public class SaveData
    {
        public string _playerName;
        public int _playerScore;

        public string _bestPlayer;
        public int _bestScore;
    }

    public void SaveScore()
    {
        SaveData database = new SaveData();

        database._playerName = playerName;
        database._playerScore = playerScore;
        database._bestScore = bestScore;
        database._bestPlayer = bestPlayer;
        
        string json = JsonUtility.ToJson(database);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData database = JsonUtility.FromJson<SaveData>(json);

            //playerName = database._playerName;
            playerScore = database._playerScore;

            bestScore = database._bestScore;
            bestPlayer = database._bestPlayer;
        }
    }

    public void PlayGame()
    {
        playerName = nickField.text;
       
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
//#if UNITY_EDITOR
//        EditorApplication.ExitPlaymode();
//        GameManager.instance.SaveScore();
//        //#else
//        //Application.Quit(); // original code to quit Unity player
//#endif
//        GameManager.instance.SaveScore();
//        Application.Quit();
    }

}
