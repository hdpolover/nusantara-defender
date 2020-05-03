using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;

    private NavMeshAgent playerAgent;
    public PlayerObject player;
    private void Start()
    {
        if (playerAgent == null)
        {
            playerAgent = this.GetComponent<NavMeshAgent>();
        }

        if (player != null)
        {
            LoadPlayer(player);
        }
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                playerAgent.SetDestination(hit.point);
            }
        }
    }

    private void LoadPlayer(PlayerObject _data)
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
        GameObject playerModel = Instantiate(_data.model);
        playerModel.transform.SetParent(this.transform);
        playerModel.transform.localPosition = new Vector3(0f, 1f, 0f);
        playerModel.transform.rotation = Quaternion.identity;

        //use stats data to set up enemy
        if (playerAgent == null)
        {
            playerAgent = this.GetComponent<NavMeshAgent>();
        }

        this.playerAgent.speed = _data.movementSpeed;
    }
}
