using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWobble : MonoBehaviour
{
    TMP_Text textElement;
    Mesh mesh;
    Vector3[] vertices;

    void Start()
    {
        textElement = GetComponent<TMP_Text>();
    }

    void Update()
    {
        textElement.ForceMeshUpdate(); 
        mesh = textElement.mesh;
        vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 v = Wobble(Time.time + i);

            vertices[i] = vertices[i] + v;
        }

        mesh.vertices = vertices;
        textElement.canvasRenderer.SetMesh(mesh);
    }

    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * 3.3f), Mathf.Cos(time * 2.5f));
    }
}
