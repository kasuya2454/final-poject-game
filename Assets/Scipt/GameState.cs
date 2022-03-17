using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [Header("Player Rule")]
    [SerializeField] private int MAX_SCORE;
    [SerializeField] private int MIN_SCORE;

    public float MAX_MINUTE_TIME;

    private int _score;
    private float _time;

    public float PlayTime
    {
        get => _time;
        set
        {
            _time = value;
        }
    }

    public int Score
    {
        get=>_score;
        set
        {
            if(value>MIN_SCORE&&value<MAX_SCORE) _score = value;
        }
    }

    public static GameState instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayTime += Time.deltaTime;
    }
}
