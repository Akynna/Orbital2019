using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour
{
    public Text questionText;
    public Text answerText;
    public GameObject Vampire;
    int n;
    int m;
    int r;
    int pending = 0;
    static System.Random rnd = new System.Random();
    bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        CreateNewQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        pending += 1;
        if (pending == 60)
        {
            isRight= rnd.Next(0,2)!=0;
            int error = Random.Range(1,3)*new List<int>() {-100,-10,-1, 1, 10, 100 }[rnd.Next(0,3)];
            if (isRight){
                answerText.text = "" + r;
            }
            else
            {
                answerText.text = "" + (r+error);
            }
            
        }
        
    }

    public void CreateNewQuestion()
    {
        pending = 0;
        n = Random.Range(0, 999);
        m = Random.Range(0, 999);
        r = n + m;
        questionText.text = n + " + " + m + " = ?";
        answerText.text = "";

    }
    public void Valider()
    {
        CreateNewQuestion();
    }

    public void TuAsTort()
    {
        if (pending > 60)
        {
            Vampire.GetComponent<VampireMain>().TuAsTort(isRight);
     
        }
    }
}
