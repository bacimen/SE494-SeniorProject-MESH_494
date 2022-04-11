using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
	PhotonView PV;


	void Awake()
	{
		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		if (PV.IsMine)
		{
			CreateController();
		}
	}

	void CreateController()
	{
		Debug.Log("instantiate character controller");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), InstantiatePlayer.Instance.GetPosition(), Quaternion.Euler(0.0f, 90.0f, 0.0f));
    }
}