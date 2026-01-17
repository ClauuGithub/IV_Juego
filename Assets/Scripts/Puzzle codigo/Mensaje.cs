using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Mensaje : MonoBehaviour
{
    public int[] sol;
    public int ac;
    public int ap;

    public TMP_Text Pista;
    void Start()
    {
        Codigo.CodigoDig += Comprobar;

    }

    void Update()
    {

    }
    public void Comprobar(int[] cod)
    {
        sol = new int[] { 1, 2, 3 }
        ;
        ac = 0;
        ap = 0;
        for (int i = 0; i < sol.Length; i++)
        {
            if (sol[i] == cod[i])
            {
                ac++;
            }
            else
            {
                for (int j = 0; j < sol.Length; j++)
                {
                    if (sol[i] == cod[j])
                    {
                        ap++;
                        sol[i] = 0;
                    }
                }
            }
        }

        if (ac > 0)
        {
            if (ap > 0)
            {
                Pista.text = "Has tenido " + ac + " aciertos y " + ap + " aproximaciones";
            }
            else
            {
                Pista.text = "Has tenido " + ac + " aciertos";
            }
        }
        else
        {
            if (ap > 0)
            {
                Pista.text = "Has tenido " + ap + " aproximaciones";
            }
            else
            {
                Pista.text = "Nada esta bien";
            }
        }

        if (ac == 3)
        {
            GameStateSingleton.Instance.codeSolved = true;
            MessageManager.Instance.ShowMessage("¡Perfecto! Ya puedo usar la escalera para subir", 5f);
        }
    }
}

