using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class Menu : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI scoreText;
    private string bestName;
    private int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadBestName();
        DataManager.Instance.LoadScore();

        bestName = DataManager.Instance.bestScoreName;
        bestScore = DataManager.Instance.bestScoreNumber;

        scoreText.text = $"Best Score: {bestName} {bestScore}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewScene()
    {

        DataManager.Instance.scoreName = nameInput.text;

        DataManager.Instance.SaveName();

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
