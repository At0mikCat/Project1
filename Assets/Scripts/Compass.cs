using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public GameObject iconPrefab;
    List<TaskMarker> markers = new List<TaskMarker>();

    public Transform player;

    public RawImage compass;

    float compassUnit;

    public TaskMarker one;
    public TaskMarker two;
    public TaskMarker three;

    // Start is called before the first frame update
    void Start()
    {
        compassUnit = compass.rectTransform.rect.width / 360f;

        AddMarker(one);
        AddMarker(two);
        AddMarker(three);
    }

    // Update is called once per frame
    void Update()
    {
        compass.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);

        foreach (TaskMarker marker in markers)
        {
            marker.image.rectTransform.anchoredPosition = GetPosOnCompass(marker);
        }
    }

    public void AddMarker(TaskMarker marker)
    {
        GameObject newMarker = Instantiate(iconPrefab, compass.transform);
        marker.image = newMarker.GetComponent<Image>();
        markers.Add(marker);
    }

    Vector2 GetPosOnCompass (TaskMarker marker)
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.z);
        Vector2 playerFwd = new Vector2(player.position.x, player.position.z);

        float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);
        return new Vector2(compassUnit * angle, 0f);
    }
}
