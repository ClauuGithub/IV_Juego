using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowCutPuzzle : MonoBehaviour
{
    [Header("Configuración del puzzle")]
    public Collider2D shapeTemplate; // Collider2D invisible con la forma correcta
    public LineRenderer lineRenderer; // Para dibujar el trazo
    public GameObject templateVisual;   // Template de la forma a seguir

    [Header("Dibujo")]
    [SerializeField] private float minDistance = 0.05f;

    [Header("Victoria")]
    [SerializeField] private string victoryScene = "VictoryScene";
    [SerializeField] private float victoryDelay = 4f;

    private bool isDrawing = false;
    private List<Vector3> points = new List<Vector3>();
    private bool templateShown = false; // Para el primer click

    private void Awake()
    {
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        if (templateVisual != null)
            templateVisual.SetActive(false); // empieza invisible
    }

    private void OnMouseDown()
    {
        // PRIMER CLICK: muestra la plantilla
        if (!templateShown)
        {
            templateShown = true;
            if (templateVisual != null)
                templateVisual.SetActive(true);

            MessageManager.Instance.ShowMessage("Observa la forma y luego dibuja sobre ella", 3f);
            return; // NO empezamos a dibujar todavía
        }

        // SEGUNDO CLICK: comienzo del trazo
        isDrawing = true;
        points.Clear();
        lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        if (!isDrawing) return;

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Plano 2D
            points.Add(mousePos);

            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPositions(points.ToArray());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
            CheckCut();
        }
    }

    private void CheckCut()
    {
        bool correct = true;

        // Compara cada punto con el collider del shapeTemplate
        foreach (Vector3 p in points)
        {
            if (!shapeTemplate.OverlapPoint(p))
            {
                correct = false;
                break;
            }
        }

        if (correct)
        {
            MessageManager.Instance.ShowMessage("¡Has cortado correctamente la ventana!", 3f);
            //if (!string.IsNullOrEmpty(nextScene))
            StartCoroutine(LoadVictoryScene());
        }
        else
        {
            MessageManager.Instance.ShowMessage("El corte no es correcto. Intenta de nuevo.", 3f);
            lineRenderer.positionCount = 0;
            points.Clear();
        }
    }

    private IEnumerator LoadVictoryScene()
    {
        yield return new WaitForSeconds(victoryDelay);
        SceneManager.LoadScene(victoryScene);
    }
}