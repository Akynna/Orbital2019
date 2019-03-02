using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VampireMain : MonoBehaviour
{
    public int life = 3;
    public int score = 0;
    public int TargetScore = 5;
    public string firstTextBox = "Je me suis assez empifré de ces incapables...";
    public string secondTextBox = "Il est temps de passer à un plat un peu plus coriace !";

    public Sprite Idle;
    public Sprite RaiseHand;
    public GameObject Director;
    public GameObject BlackBoard;
    public GameObject TuAsTortSprite;
    public List<GameObject> Coeurs;
    public GameObject Bulle;
    public GameObject BulleD;
    public GameObject fadeOut;
    SpriteRenderer sprite;
    int Timer = 181;
    bool wrong;
    bool changerEcole = false;
    bool losing = false;

    // Start is called before the first frame update
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Timer += 1;
        if (Timer == 120 && ! changerEcole && !losing)
        {
            if (wrong)
            {
                Lose();
            }
            else
            {
                MangerEleve();
            }
            sprite.sprite = Idle;
            TuAsTortSprite.SetActive(false);

        }
        if (Timer == 121 && !changerEcole)
        {

            BlackBoard.GetComponent<Questions>().CreateNewQuestion();
        }
            if (Timer == 120 && changerEcole)
        {
            Bulle.GetComponentInChildren<Text>().text = secondTextBox;

        }
        if (Timer >= 240 && Timer <= 480 && changerEcole)
        {
            fadeOut.GetComponent<SpriteRenderer>().color = new Color(0,0,0, ((float)(Timer-240))/240);
            fadeOut.SetActive(true);
        }
        if (Timer == 480 && changerEcole)
        {
            Bulle.SetActive(false);

        }
        if (Timer == 540 && changerEcole)
        {
            fadeOut.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            fadeOut.SetActive(false);
            changerEcole = false;
        }
        if (Timer == 120 && losing)
        {
            BulleD.SetActive(false);
            Director.SetActive(false);
            losing = false;

        }
    }
    public void TuAsTort(bool w)
    {
        wrong = w;
        TuAsTortSprite.SetActive(true);
        sprite.sprite = RaiseHand;
        Timer = 0;
    }
    public void Lose()
    {

        life -= 1;
        Coeurs[life].SetActive(false);
        losing = true;
        BulleD.SetActive(true);
        Director.SetActive(true);
        Timer = 0;
    }

    public void MangerEleve()
    {
        score += 1;
        if (score == TargetScore)
        {
            changerEcole=true;
            Bulle.SetActive(true);
            Bulle.GetComponentInChildren<Text>().text = firstTextBox;
            Timer = 0;
        }
    }
}
