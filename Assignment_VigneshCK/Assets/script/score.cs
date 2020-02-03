using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
     public Text sc ;
    public Text Hs;
     public static int a;
    // Start is called before the first frame update
    void Start()
    {

        Hs.text = PlayerPrefs.GetInt("highscore",0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
       sc.text = a.ToString();
        if (a > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", a);
            Hs.text = a.ToString();
        }
    }
  
   
}
