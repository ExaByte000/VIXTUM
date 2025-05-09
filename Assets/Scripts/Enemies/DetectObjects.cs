using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    private float rangeForGUICircle;
    private Vector2 rangeForGUIBox;
    public Collider2D[] Detect(float range, LayerMask layer)
    {
        rangeForGUICircle = range;
        Collider2D[] findObjects = Physics2D.OverlapCircleAll(transform.position, range, layer);
        return findObjects;
        
    }
    public Collider2D[] DetectForAttack(float range, LayerMask layer)
    {
        rangeForGUIBox = new(range, range);
        Collider2D[] currentObjects = Physics2D.OverlapBoxAll(transform.position, new(range, range), 0, layer.value);
        return currentObjects;

    }

    

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    // ���������������� ��� �������
    //    //GUIStyle style = new GUIStyle();
    //    //style.normal.textColor = Color.white;
    //    //style.fontSize = 20;
    //    //style.alignment = TextAnchor.UpperLeft;

    //    Gizmos.DrawWireCube(transform.position, rangeForGUIBox);
    //    Gizmos.DrawWireSphere(transform.position, rangeForGUICircle);

    //    //GUI.Label(new Rect(10, 10, 500, 30), $"������� ��� ������: {ListPrefabsForSpawn.Count}", style);
    //    //GUI.Label(new Rect(10, 40, 500, 30), $"������� ��� ��������: {prefabListForRespawn.Count}", style);
    //    //GUI.Label(new Rect(10, 70, 500, 30), $"������� �� �����: {spawnedBoxes.Count}", style);
    //    //GUI.Label(new Rect(10, 100, 500, 30), $"���� �������: {isMenuOpen}", style);
    //}
}
