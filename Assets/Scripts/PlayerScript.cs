using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerScript : NetworkBehaviour
{
    public Material Red;
    public Material Blue;
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();
    private void Start()
    {
        if (IsOwner)
        {
            if (IsHost)
            {
                GetComponent<MeshRenderer>().material = Red;
            }
            else
            {
                GetComponent<MeshRenderer>().material = Blue;
            }
        }
    }

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            Move();
        }
    }

    public void Move()
    {
        SubmitPositionRequestRpc();
    }

    [Rpc(SendTo.Server)]
    void SubmitPositionRequestRpc(RpcParams rpcParams = default)
    //void SubmitPositionRequestRpc()
    {
        Debug.Log("Random");
        var randomPosition = GetRandomPositionOnPlane();
        transform.position = randomPosition;
        Position.Value = randomPosition;
    }

    static Vector3 GetRandomPositionOnPlane()
    {
        return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
    }

    void Update()
    {
        if (IsOwner)
        {
            var x = Input.GetAxis("Horizontal") * 0.1f;
            var z = Input.GetAxis("Vertical") * 0.1f;

            transform.Translate(x, 0, z);
        }
        transform.position = Position.Value;
    }
}
