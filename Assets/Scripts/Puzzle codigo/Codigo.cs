using UnityEngine;

public class Codigo : MonoBehaviour
{
    public int[] cod = new int[3];
    public int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
