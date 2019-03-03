using System;
using System.Collections.Generic;

namespace Application
{
    public class Quizz
    {
        public Random rand = new Random();

        SortedDictionary<String, List<List<String>>> dico = new SortedDictionary<string, List<List<string>>>();
        //List<List<String>> dico = new List<List<string>>();

        public Quizz(int level)
        {
            if (level == 1)
            {
                List<List<string>> maths = new List<List<string>>();
                maths.Add(new List<string> { "Question?", "Reponse juste", "Reponse fausse" });
                dico.Add("Maths", maths);

                List<List<string>> geo = new List<List<string>>();
                geo.Add(new List<string> { "Quelle est la capitale de l'Allemagne?", "Berlin", "Berne", "Zurich", "Munich", "Hamburg", "Vienne", "Paris" });
                geo.Add(new List<string> { "Quelle est la capitale de la France?", "Paris", "Nice", "Bordeaux", "Genève", "Lyon", "Madrid", "Vienne" });
                geo.Add(new List<string> { "Quelle est la capitale de l'Italie?", "Rome", "Milan", "Naples", "Venise", "Lugano", "Madrid" });
                geo.Add(new List<string> { "Quelle est la capitale de l'Autriche?", "Vienne", "Berne", "Paris", "Berlin", "Prague", "Karlsruhe", "Liechtenstein" });
                geo.Add(new List<string> { "Quelle est la capitale de l'Espagne?", "Madrid", "Barcelone", "Pampelune", "Lyon", "Puerto Rico", "Buenos Aires" });
                dico.Add("Geo", geo);

                List<List<string>> bio = new List<List<string>>();
                bio.Add(new List<string> { "Combien de pattes a un chien?", "4", "3", "2", "8", "1", "5" });
                bio.Add(new List<string> { "Nomme un légume orange:", "carotte", "mandarine", "orange" });
                bio.Add(new List<string> { "Qu'est-ce qui pousse sur un pommier?", "Des pommes", "Des poires", "Des oranges" });
                bio.Add(new List<string> { "Qu'est-ce que mange une vache?", "De l'herbe", "Des souris", "Du pain" });
                bio.Add(new List<string> { "Où peut-on trouver des poissons?", "Dans l'eau", "Dans le ciel", "Sur des arbres" });
                bio.Add(new List<string> { "Où pousse la carotte?", "Dans la terre", "Sur un arbre qui s'appelle le carrotier", "Sur des buissons" });
                bio.Add(new List<string> { "Qu'est-ce qui permet aux oiseaux de voler?", "Les ailes", "Les pattes", "Le bec" });
                dico.Add("Bio", bio);

                List<List<string>> francais = new List<List<string>>();
                francais.Add(new List<string> { "Quel est le pluriel du \"cheval\"?", "Les chevaux", "Les chevals", "Les cheveaux" });
                francais.Add(new List<string> { "Décline le verbe \"manger\": tu...", "manges", "mange", "mangent" });
                francais.Add(new List<string> { "Quelle est la nature du mot \"parler\"?", "Un verbe", "Un nom", "Un adjectif" });
                dico.Add("Francais", francais);

                //dico.Add("ss", new List<string> { "ss" });
                //dico.Add(new List<string> { "Question?", "Reponse juste", "Reponse fausse" });
            }

            if (level == 2)
            {
                List<List<string>> maths = new List<List<string>>();
                maths.Add(new List<string> { "Résoudre l'équation: x\u00B2 + 2x + 1 = 0", "x = -1", "x = 1", "x = 2" });
                maths.Add(new List<string> { "Résoudre l'équation: x\u00B2 + x + 1 = 0", "Pas de solution", "x = 1", "x = -1" });
                maths.Add(new List<string> { "Résoudre l'équation: 3x\u00B2 + 4x + 1 = 0", "x = -1 ou x = -\u2153", "Pas de solution", "x = 1" });
                maths.Add(new List<string> { "Calculer sin(\u00BC\u03C0)\u00B2:", "\u00BD", "-\u00BD", "\u00BC", "\u2153" });
                dico.Add("Maths", maths);


                List<List<string>> geo = new List<List<string>>();
                geo.Add(new List<string> { "Trouve une capitale qui commence par Z:", "Zagreb", "Zern", "Zurich" });
                geo.Add(new List<string> { "Quelle est la plus haute montagne dans le monde?", "Everest", "Mont-Blanc", "Jungfrau Joch", "Matterhorn" });
                geo.Add(new List<string> { "Combien y a-t-il d'états aux Etats-Unis?", "50", "42", "23"});
                dico.Add("Geo", geo);

                List<List<string>> hist = new List<List<string>>();
                hist.Add(new List<string> { "Quelle est l'année de la chute du mur de Berlin?", "1989", "1991", "1945" });
                hist.Add(new List<string> { "Quelle est l'année de la fin de la Première Gierre Mondiale?", "1918", "1945", "1917" });
                hist.Add(new List<string> { "Prague était la capitale de quel pays entre 1918 et 1992?", "Tchécoslovaquie", "Tchéquie", "Yugoslavie" });
                dico.Add("Hist", hist);

                List<List<string>> litt = new List<List<string>>();
                litt.Add(new List<string> { "Qui est l'auteur de \"Roméo et Juliette\"?", "Shakespeare", "Baudelaire", "Verlaine", "La Fontaine" });
                litt.Add(new List<string> { "Combien d'années Ulysse a-t-il voyagé après la guerre de Troie?", "10 ans", "20 ans", "1 an" });
                litt.Add(new List<string> { "Combien de mousquetaires étaient des proches amis de Porthos?", "2", "3", "4" });
                litt.Add(new List<string> { "Comment s'appelait l'ami de Robinson Crusoé?", "Vendredi", "Samedi", "Dimanche" });
                dico.Add("Litt", litt);
            }

            if (level == 3)
            {
                List<List<string>> maths = new List<List<string>>();
                maths.Add(new List<string> { "Soit A un sous-ensemble borné et non vide de \u211D. Alors InfA ∈ A et SupA ∈ A", "Faux", "Vrai" });
                maths.Add(new List<string> { "Soient f:\u211D→\u211D et g:\u211D→\u211D deux fonctions définies sur tout \u211D. Si f◦g est injective, alors g est injective", "Vrai", "Faux" });
                maths.Add(new List<string> { "Quelle est la transformée Fourier de \u2202(t)?", "1", "\u2202(u03C9)" });
                maths.Add(new List<string> { "Quelle est la complexité du tri fusion?", "O(nlogn)", "O(logn)", "O(n)" });
                maths.Add(new List<string> { "Soit p et q deux nombres premiers. Quelle est la valeur de l’indicatrice d’Euler φ(pᵃ, qᵇ)?",  "pᵃ⁻¹(p−1)qᵇ⁻¹(q−1)", "pᵃ(p−1)qᵇ(q−1)" });
                maths.Add(new List<string> { "Est-ce que l'égalité x + y - y = x est toujours vraie si implémentée en IEEE-754?", "Non", "Oui" });
                maths.Add(new List<string> { "La transformée Fourier du cosinus est sinus.", "Faux", "Vrai" });
                dico.Add("Maths", maths);

                /*
                List<List<string>> geo = new List<List<string>>();
                geo.Add(new List<string> { "Trouve une capitale qui commence par Z:", "Zagreb", "Zern", "Zurich" });
                geo.Add(new List<string> { "Quelle est la plus haute montagne dans le monde?", "Everest", "Mont-Blanc", "Jungfrau Joch", "Matterhorn" });
                geo.Add(new List<string> { "Combien y a-t-il d'états aux Etats-Unis?", "50", "42", "23" });
                dico.Add("Geo", geo);*/

            }

            if (level == 4)
            {

            }



        }


        public List<string> ask(string s)
        {
            List<List<string>> questions = new List<List<string>>();
            dico.TryGetValue(s, out questions);

            if (questions.Count > 0)
            {
                int choiceQ = rand.Next(0, questions.Count);
                List<string> q = questions[choiceQ];
                int choiceR = 1;
                int grade = rand.Next(0, 2);
                string r = "";
                if (grade == 1)
                {
                    r = q[grade];
                }
                else if (grade == 0)
                {
                    choiceR = rand.Next(2, q.Count);
                    r = q[choiceR];
                }
                questions.RemoveAt(choiceQ);

                return new List<string> { q[0], r, grade.ToString() };
            }
            else
            {
                return new List<string> { "Il n'y a plus de questions dans ce domaine", ":(", "1" };
            }

        }
        

    }
}
