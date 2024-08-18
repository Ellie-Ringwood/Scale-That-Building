using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : NetworkBehaviour
{
    public Material Red;
    public Material Blue;
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

    public override void OnNetworkSpawn()
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
        Debug.Log("player");
    }

    public void RandomMove()
    {
         SubmitPositionRequestRpc();
    }


    public void Move()
    {
        var x = Input.GetAxis("Horizontal") * 0.1f;
        var z = Input.GetAxis("Vertical") * 0.1f;

        transform.Translate(x, 0, z);
        Position.Value = transform.position;

    }


    [Rpc(SendTo.Server)]
    void SubmitPositionRequestRpc(RpcParams rpcParams = default)
    {
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
        transform.position = Position.Value;
    }
}
