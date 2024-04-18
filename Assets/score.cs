using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    public Text scoreText;

      public void Score()
    {
        int number = Random.Range(1, 20);
        scoreText.text = number.ToString();
    }
}
