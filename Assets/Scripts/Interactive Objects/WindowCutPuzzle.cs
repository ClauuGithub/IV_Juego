using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class WindowCutPuzzle : MonoBehaviour
{
    [Header("Configuración del puzzle")]
    public Collider2D shapeTemplate; // Collider2D invisible con la forma correcta
    public LineRenderer lineRenderer; // Para dibujar el trazo
    public GameObject templateVisual;   // Template de la forma a seguir
    public float minLength; // Longitud mínima del trazo (puntos)
    public float maxLength; // Longitud mínima del trazo (puntos)
    private float length;

    [Header("Dibujo")]
    [SerializeField] private float minDistance = 0.05f;

    [Header("Victoria")]
    [SerializeField] private string nextScene = "CutScene2";
    [SerializeField] private float sceneDelay = 3f;

    private bool isDrawing = false;
    private List<Vector3> points = new List<Vector3>();
    private bool templateShown = false; // Para el primer click

    public static event Action<int> EntrarBalcon;

    private void Awake()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        if (templateVisual != null)
            templateVisual.SetActive(false); // empieza invisible
    }

    // private void OnMouseDown()
    // {
    //     // PRIMER CLICK: muestra la plantilla
    //     if (!templateShown)
    //     {
    //         templateShown = true;
    //         if (templateVisual != null)
    //             templateVisual.SetActive(true);
    // 
    //         MessageManager.Instance.ShowMessage("Observa la forma y luego dibuja sobre ella", 3f);
    //         return; // NO empezamos a dibujar todavía
    //     }
    // 
    //     // SEGUNDO CLICK: comienzo del trazo
    //     isDrawing = true;
    //     points.Clear();
    //     lineRenderer.positionCount = 0;
    // }

    private void Update()
    {
        // 1. PRIMER CLICK: muestra la plantilla
        if (Input.GetMouseButtonDown(0))
        {
            if (!templateShown)
            {
                templateShown = true;
                templateVisual.SetActive(true);
                MessageManager.Instance.ShowMessage("Observa la forma", 2f);
                return;
            }

            // 2. SEGUNDO CLICK: comienzo del trazo
            isDrawing = true;
            points.Clear();
            lineRenderer.positionCount = 0;
        }

        // 3. DIBUJO 
        if (isDrawing && Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;

            if (shapeTemplate.OverlapPoint(mousePos))
            {
                if (points.Count == 0 || Vector3.Distance(points[^1], mousePos) > minDistance)
                {
                    points.Add(mousePos);
                    lineRenderer.positionCount = points.Count;
                    lineRenderer.SetPositions(points.ToArray());
                }
            }
        }

        // 4. SOLTAR
        if (Input.GetMouseButtonUp(0) && isDrawing)
        {
            isDrawing = false;
            CheckCut();
        }
    }

    private void CheckCut()
    {
        MessageManager.Instance.ShowMessage("Puntos: " + points.Count, 5f);
        // Longitud mínima
        length = GetTotalLength();

        if (length < minLength || length > maxLength)
        {
            Fail();
            return;
        }

        // Cuántos puntos están dentro del collider
        int inside = 0;

        // Compara cada punto con el collider del shapeTemplate
        foreach (Vector3 p in points)
        {
            if (shapeTemplate.OverlapPoint(p))
            {
                inside++;
            }
        }

        MessageManager.Instance.ShowMessage("¡Has cortado correctamente la ventana!", 3f);
        //MessageManager.Instance.ShowMessage("¡Has cortado correctamente la ventana! Longitud: " + length, 3f);
        StartCoroutine(LoadNextScene());
        // lineRenderer.positionCount = 0;
        // points.Clear();
    }
    private void Fail()
    {
        MessageManager.Instance.ShowMessage("El corte no es válido. Prueba de nuevo", 3f);
        // MessageManager.Instance.ShowMessage("El corte no es válido. Prueba de nuevo. Longitud: " + length, 3f);
        lineRenderer.positionCount = 0;
        points.Clear();
    }

    private float GetTotalLength()
    {
        float total = 0f;

        for (int i = 1; i < points.Count; i++)
        {
            total += Vector3.Distance(points[i - 1], points[i]);
        }

        return total;
    }

    private IEnumerator LoadNextScene()
    {
        EntrarBalcon?.Invoke(3);
        yield return new WaitForSeconds(sceneDelay);
        SceneManager.LoadScene(nextScene);
    }
}