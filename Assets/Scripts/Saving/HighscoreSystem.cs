using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class HighscoreSystem : MonoBehaviour
{
    private List<string> names = new List<string>();
    private List<float> scores = new List<float>();

    public int maxScores = 10;

    public Transform panel;
    public TMP_Text textPrefab;

    public static HighscoreSystem ins;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        RefreshScoreDisplay();
    }

    private void RefreshScoreDisplay()
    {
        for(int i = panel.childCount - 1; i >= 0; i--) 
        {
            Destroy(panel.GetChild(i).gameObject);
        }

        for (int i = 0; i < scores.Count; i++)
        {
            TMP_Text text = Instantiate(textPrefab,panel);
            text.text = names[i];

            text = Instantiate(textPrefab, panel);
            text.text = scores[i].ToString();
        }
    }

    string[] possibleNames = { "asd", "serer", "dsfdsf", "sdfsd" };
    public void NewScore(float score)
    {
        NewScore(possibleNames[Random.Range(0,possibleNames.Length)] ,score);
    }
    
    public void NewScore(string name, float score)
    {
        for(int index = 0; index < scores.Count ; index ++)
        {
            if(score < scores[index])
            {
                scores.Insert(index, score);
                names.Insert(index, name);
                RefreshScoreDisplay();
                if (scores.Count > maxScores)
                {
                    scores.RemoveAt(scores.Count - 1);
                    names.RemoveAt(names.Count - 1);
                }
                return;
            }
        }

        if (scores.Count < maxScores)
        {
            scores.Add(score);
            names.Add(name);
            RefreshScoreDisplay();
        }
    }
}
