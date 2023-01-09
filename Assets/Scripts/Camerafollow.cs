using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    List<Transform> list;

    [SerializeField]
    float distanceToWin = 1000f;

    private Manager manager;

    private TextMesh vinnerText;
    private TextMesh taperText;

    void Start()
    {
        manager = FindObjectOfType<Manager>();
        if (manager == null)
        {
            Debug.LogError("No Manager");
        }

        var textMeshes = GetComponentsInChildren<TextMesh>();
        if (textMeshes.Length > 0)
        {
            foreach (var textMesh in textMeshes)
            {
                if (textMesh.CompareTag("VinnerText"))
                {
                    vinnerText = textMesh;
                    vinnerText.text = "";
                }
                if (textMesh.CompareTag("TaperText"))
                {
                    taperText = textMesh;
                    taperText.text = "";
                }
            }
        }

        // Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var players = manager.GetPlayers();
        List<Transform> playerTransforms = new List<Transform>();
        foreach (var player in players)
        {
            playerTransforms.Add(player.transform);
        }
        var nextPos = GetMeanVectors(playerTransforms);
        transform.position = nextPos;
        vinnerText.text = manager.GetVinnerName();
        taperText.text = manager.GetTaperName();
    }

    private Vector3 GetMeanVectors(List<Transform> vectors)
    {
        Vector3 meanVector = new Vector3(0, 0, 0);
        foreach (var player in vectors)
        {
            meanVector += player.position;
            if (player.position.z >= distanceToWin)
            {
                // Time.timeScale = 0;
            }
        }

        return (meanVector / vectors.Count);
    }
}
