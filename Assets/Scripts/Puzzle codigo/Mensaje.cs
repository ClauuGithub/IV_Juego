using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mensaje : MonoBehaviour
{
    public int[] sol;
    public int ac;
    public int ap;

    public static event Action<int> HacerCodigo;

    public TMP_Text Pista;
    void Start()
    {
        Pista.text = "Inserte el código";
        Codigo.CodigoDig += Comprobar;

    }

    void Update()
    {

    }
    public void Comprobar(int[] cod)
    {
        sol = new int[] { 1, 2, 3 };  // Estaba en 307

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
                Pista.text = "Ha obtenido " + ac + " aciertos y " + ap + " aproximaciones";
            }
            else
            {
                Pista.text = "Ha obtenido " + ac + " aciertos";
            }
        }
        else
        {
            if (ap > 0)
            {
                Pista.text = "Ha obtenido " + ap + " aproximaciones";
            }
            else
            {
                Pista.text = "Ningún dígito es correcto";
            }
        }

        if (ac == 3)
        {
            GameStateSingleton.Instance.currentState = GameStateSingleton.GameState.BalconyUnlocked;
            Debug.Log("Estado actual: " + GameStateSingleton.Instance.currentState);

            MessageManager.Instance.ShowMessage("¡Perfecto! Ya puedo subir al balcón.", 5f);
            HacerCodigo?.Invoke(2);
        }
    }

    void OnEnable()
    {
        Pista.text = "Inserte el código";
    }
}

