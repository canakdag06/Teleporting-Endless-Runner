using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Road : MonoBehaviour
{
    public Transform _transform;
    public Road nextRoad;
    public Road prevRoad;
    private float pieceLength;

    [SerializeField] public Vector3 endPosition;

    public float gizmosDistance = 100f;

    private void OnDrawGizmos()
    {
        pieceLength = _transform.GetChild(0).transform.localScale.z;
        Gizmos.color = Color.blue;
        Vector3 startPoint = endPosition + new Vector3(0f, 0f, (pieceLength / 3));
        Vector3 endPoint = endPosition + new Vector3(0f, 0f, (pieceLength / 3)) + transform.right * gizmosDistance;

        Gizmos.DrawLine(startPoint, endPoint);
    }
}
