using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class PlayControl : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int score;
    public Text scoreText;
    public Text winText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        winText.text = " ";
    }

    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movHorizontal, 0.0f, movVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("item")) ;
        {
            other.gameObject.SetActive(false); 
            score = score + 1; 
            SetScoreText(); 
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score:" + score.ToString();
        if (score >= 10)
        {
            winText.text = "You Win!";
        }
    }
}