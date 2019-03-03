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

    public string firstTextVictoire = "Tout ce sang ! On peut dire que j'ai eu mon diplôme hahaha !";
    public string secondTextVictory = " Je pourrais peut-être faire un doctorat.";

    public string firstTextD = "Objection ! On ne mange pas les élèves qui répondent juste !";
    public string secondTextD = "C'était votre dernier blâme. Vous êtes virés !";

    public Sprite Idle;
    public Sprite RaiseHand;
    public Sprite Jump;
    public Sprite Triste;
    public Sprite Mange;
    public Sprite Bco;
    public Sprite Dco;
    public Sprite Buni;
    public Sprite Duni;
    public Sprite E1g;
    public Sprite E1f;
    public Sprite E2g;
    public Sprite E2f;
    public Sprite E3g;
    public Sprite E3f;
    public GameObject craie1;
    public GameObject craie2;
    public GameObject Student;
    public GameObject Background;
    public GameObject Desk;
    public GameObject Director;
    public GameObject BlackBoard;
    public GameObject TuAsTortSprite;
    public List<GameObject> Coeurs;
    public GameObject Bulle;
    public GameObject BulleD;
    public GameObject fadeOut;
    public GameObject victoryscreen;
    public GameObject gameoverscreen;
    SpriteRenderer sprite;
    int Timer = 181;
    bool wrong;
    bool changerEcole = false;
    bool losing = false;
    bool jumping;
    Vector3 posi;
    public int level = 1;
    bool girl;
    bool decu;
    bool gagner = false;

    // Start is called before the first frame update
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        posi = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Timer += 1;
        if (decu && Timer == 121)
        {
            decu = false;
            sprite.sprite = Idle;

        }
        if (jumping)
        {
            if (Timer <= 30)
            {
                float t = 0.3f * Timer;
                transform.position = posi + new Vector3(1.5f*t, t - 0.1f*t * t, 0);
            }
            if(Timer == 30)
            {
                sprite.sprite = Mange;
                Student.SetActive(false);
                transform.position = Student.transform.position;
            }
            if (Timer == 240)
            {
                transform.position = posi;
                jumping = false;


                Student.SetActive(true);
                Student.transform.Translate(new Vector3(0, -2, 0));
                Student.transform.Rotate(new Vector3(0, 0, 90));
                if (wrong)
                {
                    Lose();
                }
                else
                {
                    win();
                }
                sprite.sprite = Idle;

            }
        }
        else
        {
            if (Timer == 120 && !changerEcole && !losing && !decu && !gagner)
            {
                MangerEleve();

                TuAsTortSprite.SetActive(false);

            }
            if (Timer == 121 && !changerEcole && !losing && !gagner)
            {

                BlackBoard.GetComponent<Questions>().CreateNewQuestion();
            }

            if (Timer == 120 && changerEcole && !gagner)
            {
                Bulle.GetComponentInChildren<Text>().text = secondTextBox;

            }
            if (Timer >= 240 && Timer <= 480 && changerEcole && !gagner)
            {
                fadeOut.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, ((float)(Timer - 240)) / 240);
                fadeOut.SetActive(true);
            }
            if (Timer == 480 && changerEcole && !gagner)
            {
                Bulle.SetActive(false);
                level += 1;
                if (level == 2)
                {
                    craie1.GetComponent<Text>().color = Color.black;
                    craie2.GetComponent<Text>().color = Color.black;
                    Background.GetComponent<SpriteRenderer>().sprite = Bco;
                    Desk.GetComponent<SpriteRenderer>().sprite = Dco;
                }
                else if (level == 3)
                {
                    craie1.GetComponent<Text>().color = Color.white;
                    craie2.GetComponent<Text>().color = Color.white;
                    Background.GetComponent<SpriteRenderer>().sprite = Buni;
                    Desk.GetComponent<SpriteRenderer>().sprite = Duni;
                }

            }
            if (Timer == 540 && changerEcole && !gagner)
            {
                fadeOut.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                fadeOut.SetActive(false);
                changerEcole = false;
                BlackBoard.GetComponent<Questions>().CreateNewQuestion();
                ChangerEleve();
            }


            if (Timer == 120 && gagner)
            {
                Bulle.GetComponentInChildren<Text>().text = secondTextVictory;

            }
            if (Timer >= 240 && Timer <= 480 && gagner)
            {
                fadeOut.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, ((float)(Timer - 240)) / 240);
                fadeOut.SetActive(true);
            }
            if (Timer == 480 && gagner)
            {
                Bulle.SetActive(false);
                fadeOut.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                fadeOut.SetActive(false);
                victoryscreen.SetActive(true);

            }

            if (Timer == 180 && losing && life != 0)
            {
                BulleD.SetActive(false);
                Director.SetActive(false);
                losing = false;
                BlackBoard.GetComponent<Questions>().CreateNewQuestion();

                ChangerEleve();

            }

            if (Timer == 180 && losing && life == 0)
            {
                BulleD.GetComponentInChildren<Text>().text = secondTextD;

            }
            if (Timer == 300 && losing && life == 0)
            {
                gameoverscreen.SetActive(true);
                Timer = 1000;

            }
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
        BulleD.GetComponentInChildren<Text>().text = firstTextD;
        Timer = 0;
    }

    public void win()
    {
        score += 1;
        if (score == TargetScore || score == TargetScore*2)
        {
            changerEcole=true;
            Bulle.SetActive(true);
            Bulle.GetComponentInChildren<Text>().text = firstTextBox;
            Timer = 0;
        }
        if (score == TargetScore * 3)
        {
            gagner = true;
            Bulle.SetActive(true);
            Bulle.GetComponentInChildren<Text>().text = firstTextVictoire;
            Timer = 0;

        }
    }
    public void MangerEleve()
    {
        sprite.sprite = Jump;
        jumping = true;
        Timer = 0;
    }
    public void EtreTriste()
    {
        Timer = 0;
        decu = true;
        sprite.sprite = Triste;
    }
    public void ChangerEleve()
    {

        Student.transform.Rotate(new Vector3(0, 0, -90));
        Student.transform.Translate(new Vector3(0, 2, 0));
        if (level == 1)
        {
            if (girl)
            {
                Student.GetComponent<SpriteRenderer>().sprite = E1g;
            }
            else
            {
                Student.GetComponent<SpriteRenderer>().sprite = E1f;
            }

        }
        else if (level == 2)
        {
            if (girl)
            {
                Student.GetComponent<SpriteRenderer>().sprite = E2g;
            }
            else
            {
                Student.GetComponent<SpriteRenderer>().sprite = E2f;
            }

        }
        else if (level == 3)
        {
            if (girl)
            {
                Student.GetComponent<SpriteRenderer>().sprite = E3g;
            }
            else
            {
                Student.GetComponent<SpriteRenderer>().sprite = E3f;
            }

        }
        girl = !girl;
    }
}

