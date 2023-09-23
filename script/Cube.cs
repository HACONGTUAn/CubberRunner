using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float h;
    Rigidbody2D rb;
    GameController m_gc;
    public AudioSource aus;
    public AudioClip jumpSound;
    public AudioClip loseSound;

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
     m_gc = FindObjectOfType<GameController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        bool Inputmess = Input.GetKeyUp(KeyCode.Space);
        if (Inputmess)
        {
            rb.AddForce(Vector2.up * h);
            Debug.Log("da nhay\n");
            if(aus && jumpSound)
            {
                aus.PlayOneShot(jumpSound);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Os"))
        {
            Debug.Log("da va cham");
            m_gc.SetGameoverState(true);
            if(aus && loseSound)
            {
                aus.PlayOneShot(loseSound);
            }
        }
    }
}
