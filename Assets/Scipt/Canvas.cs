using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    [SerializeField] private Text scoreTextObject;
    [SerializeField] private Text timeTextObject;

    private string baseTimeText;
    private string baseScoreText;
    // Start is called before the first frame update
    void Start()
    {
        baseTimeText = timeTextObject.text;
        baseScoreText = scoreTextObject.text;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextObject.text = $"{baseScoreText} {GameState.instance.Score}";
        timeTextObject.text = $"{baseTimeText} {GameState.instance.PlayTime.ToString("n2")}";
    }
}
