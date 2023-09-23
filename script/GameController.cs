using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    public float SwapTime;
    float m_SwapTime;
    int m_core;
    bool m_isGameover;
    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_SwapTime = 0;
        m_core = 0;
        m_isGameover = false;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoretext("Score: " + m_core);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameover)
        {
            m_SwapTime = 0;
            m_ui.ShowGameoverPanel(true);
            return;
        }
        m_SwapTime -= Time.deltaTime;
        if (m_SwapTime <= 0)
        {
            SpawnObstacle();
            m_SwapTime = SwapTime;
        }
    }

    public void SpawnObstacle()
    {
        float randYpos = Random.Range(-4f,-2.5f);
        Vector2 spawnPos = new Vector2(11,randYpos);

        if (obstacle)
        {
            Instantiate(obstacle,spawnPos,Quaternion.identity);
        }

        
    }

    public void SetCore(int value)
    {
        m_core = value;
    }
    public int GetCore()
    {
        return m_core;
    } 

    public void ScoreIncrement()
    {
        if (m_isGameover)
            return;
       m_core++;
       m_ui.SetScoretext("Score : "+ m_core);
    }
    public bool IsGameover()
    {
        return m_isGameover;
    }
    
    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }
    public void Replay()
    {
        SceneManager.LoadScene("hello");
    }
}
