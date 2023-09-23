using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public float toc_do;

    GameController m_gc;

    void Start()
    {
    m_gc = FindObjectOfType<GameController>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * toc_do * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Remove"))
        {
            m_gc.ScoreIncrement();

            Destroy(gameObject);
        }
    }

}
