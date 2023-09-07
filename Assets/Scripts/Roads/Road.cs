using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Road : MonoBehaviour
{
    public Transform _transform;
    public Road nextRoad;
    public Road prevRoad;
    [SerializeField] private float pieceLength = 240f;

    [SerializeField] public Vector3 endPosition;

    [SerializeField] private Transform fuels;

    public float gizmosDistance = 100f;

    private void OnEnable()
    {
        foreach (Transform fuel in fuels)
        {
            fuel.gameObject.SetActive(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 startPoint = endPosition + new Vector3(0f, 0f, (pieceLength / 3));
        Vector3 endPoint = endPosition + new Vector3(0f, 0f, (pieceLength / 3)) + transform.right * gizmosDistance;

        Gizmos.DrawLine(startPoint, endPoint);
    }
}
