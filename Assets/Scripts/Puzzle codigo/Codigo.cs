using UnityEngine;
using System;

public class Codigo : MonoBehaviour
{
    public int[] cod = new int[3];
    public int i = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static event Action<int[]> CodigoDig;

    public void Enviar()
    {
        CodigoDig?.Invoke(cod);
    }
    public void Seleccionar(int b)
    {
        i = b;
    }
    public void Recibir( string input)
    {
        int a = int.Parse(input);
        cod[i] = a;
    }
}
