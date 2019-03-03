using Application;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour
{
    public Text questionText;
    public Text answerText;
    public GameObject Vampire;
    string n;
    string m;
    int pending = 0;
    static System.Random rnd = new System.Random();
    bool isRight;
    Quizz q;
    // Start is called before the first frame update
    void Start()
    {

        q = new Quizz(1);
        CreateNewQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        pending += 1;
        if (pending == 60)
        {
            
            answerText.text = m;
            
            
        }
        
    }

    public void CreateNewQuestion()
    {

        List<string> asking = q.ask("Geo");
        pending = 0;
        n = asking[0];
        m = asking[1];
        isRight = asking[2] == "1";
        questionText.text = n;
        answerText.text = "";

    }
    public void Valider()
    {
        Vampire.GetComponent<VampireMain>().EtreTriste();
    }

    public void TuAsTort()
    {
        if (pending > 60)
        {
            Vampire.GetComponent<VampireMain>().TuAsTort(isRight);
     
        }
    }
}
