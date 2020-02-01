using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] targets;

    public Transform camera;

    //20 by 20
    public int areaSize = 20;
    public Vector3 centerView;

    // Start is called before the first frame update
    void Start()
    {
        int size = PlayerManager.instance.players.Count;
        targets = new Transform[size];

        for (int i = 0; i < PlayerManager.instance.players.Count; ++i)
            targets[i] = PlayerManager.instance.players[i].transform;
    }

    // Update is called once per frame
    void Update()
    {
        float minX = float.MaxValue;
        float maxX = float.MinValue;

        float minZ = float.MaxValue;
        float maxZ = float.MinValue;

        foreach (Transform t in targets)
        {
            minX = Mathf.Min(minX, t.position.x);
            maxX = Mathf.Max(maxX, t.position.x);

            minZ = Mathf.Min(minZ, t.position.z);
            maxZ = Mathf.Max(maxZ, t.position.z);
        }

        //Bounds
        minZ -= 2;

        float distance = Vector3.Distance(new Vector3(minX, minZ), new Vector3(maxX, maxZ));
        distance = Mathf.Clamp(distance, 7, areaSize);

        float gameView = (areaSize - distance);

        Vector3 target = new Vector3(
            Mathf.Clamp((minX + maxX) / 2, -(gameView - centerView.x), gameView + centerView.x),
            0,
            Mathf.Clamp((minZ + maxZ) / 2, -(gameView - centerView.z), gameView + centerView.z));

        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * Vector3.Distance(transform.position, target));

        Vector3 zoomPos = new Vector3(0, 0, -(distance + 3));
        camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, zoomPos, Time.deltaTime * Vector3.Distance(camera.transform.localPosition, zoomPos));
    }
}
