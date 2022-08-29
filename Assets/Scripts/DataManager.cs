using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;
using TMPro;

[DefaultExecutionOrder(1000)]
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string scoreName;
    public string bestScoreName;
    public Text sentence;
    public int bestScoreNumber;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Serializable]
    class SaveDataNumber
    {
        public int bestScoreNumber;
    }

    public void SaveScore()
    {
        SaveDataNumber data = new SaveDataNumber();
        data.bestScoreNumber = bestScoreNumber;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDataNumber data = JsonUtility.FromJson<SaveDataNumber>(json);

            bestScoreNumber = data.bestScoreNumber;
        }
    }

    [Serializable]
    class SaveDataName
    {
        public string scoreName;
    }

    public void SaveName()
    {
        SaveDataName nameData = new SaveDataName();
        nameData.scoreName = scoreName;

        string nameJson = JsonUtility.ToJson(nameData);

        File.WriteAllText(Application.persistentDataPath + "/savefile1.json", nameJson);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile1.json";

        if (File.Exists(path))
        {
            string nameJson = File.ReadAllText(path);
            SaveDataName nameData = JsonUtility.FromJson<SaveDataName>(nameJson);

            scoreName = nameData.scoreName;
        }
    }

    [Serializable]
    class SaveDataBestName
    {
        public string bestScoreName;
    }

    public void SaveBestName()
    {
        SaveDataBestName bestNameData = new SaveDataBestName();
        bestNameData.bestScoreName = bestScoreName;

        string bestNameJson = JsonUtility.ToJson(bestNameData);

        File.WriteAllText(Application.persistentDataPath + "/savefile3.json", bestNameJson);
    }

    public void LoadBestName()
    {
        string path = Application.persistentDataPath + "/savefile3.json";

        if (File.Exists(path))
        {
            string bestNameJson = File.ReadAllText(path);
            SaveDataBestName bestNameData = JsonUtility.FromJson<SaveDataBestName>(bestNameJson);

            bestScoreName = bestNameData.bestScoreName;
        }
    }

    [Serializable]
    class SaveDataSentence
    {
        public Text sentence;
    }

    public void SaveSentence()
    {
        SaveDataSentence sentenceData = new SaveDataSentence();
        sentenceData.sentence = sentence;

        string sentenceJson = JsonUtility.ToJson(sentenceData);

        File.WriteAllText(Application.persistentDataPath + "/savefile2.json", sentenceJson);
    }

    public void LoadSentence()
    {
        string path = Application.persistentDataPath + "/savefile2.json";

        if (File.Exists(path))
        {
            string sentenceJson = File.ReadAllText(path);
            SaveDataSentence sentenceData = JsonUtility.FromJson<SaveDataSentence>(sentenceJson);

            sentence = sentenceData.sentence;
        }
    }
}
