using UnityEngine;

public class GhostController : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    public GhostObject ghost;

    void Start()
    {
        LoadGhost(ghost);

        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * ghost.movementSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        //ghost.speed = ghost.startSpeed;
    }

    private void LoadGhost(GhostObject _data)
    {
        //remove children objects i.e. visuals
        foreach (Transform child in this.transform)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(child.gameObject);
            }
            else
            {
                Destroy(child.gameObject);
            }
        }

        //load current enemy visuals
        GameObject ghostModel = Instantiate(_data.model);
        ghostModel.transform.SetParent(this.transform);
        ghostModel.transform.localPosition = new Vector3(0f, 1f, 0f);
        ghostModel.transform.rotation = Quaternion.identity;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        Destroy(gameObject);
    }

}
