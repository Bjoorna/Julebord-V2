using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private TextMesh placeText;
    private TextMesh nameText;
    private Manager manager;

    // Start is called before the first frame update
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
                if (textMesh.CompareTag("PlaceText"))
                {
                    placeText = textMesh;
                }
                if (textMesh.CompareTag("NameText"))
                {
                    nameText = textMesh;
                    nameText.text = gameObject.name;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int pos;
        var getPos = manager.GetPos(this, out pos);
        if (getPos)
        {
            placeText.text = pos.ToString();
        }
        // updateDistance();
    }

    private void updateDistance()
    {
        placeText.text = transform.position.z.ToString();
    }

    public void DestroySelf()
    {
        foreach (var child in GetComponentsInParent<Transform>())
        {
            if (child.CompareTag("Meshtag"))
            {
                child.gameObject.SetActive(false);
            }
        }
        StartCoroutine(DestroyDelay());
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }
}
