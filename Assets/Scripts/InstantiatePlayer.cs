using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos{
    private Vector3 _position;
    private bool _isAvailable;

    public PlayerPos(Vector3 position, bool isAvailable){
        _position = position;
        _isAvailable = isAvailable;
    }

    public Vector3 GetPos(){
        return _position;
    }

    public bool GetAvailability(){
        return _isAvailable;
    }

    public void SetAvailability(bool set){
        _isAvailable = set;
    }
}

public class InstantiatePlayer : MonoBehaviour
{
    // Singleton
    public static InstantiatePlayer instance;
    private List<PlayerPos> _playerPosList;
    private int _playerCt;

    public InstantiatePlayer(int playerCt = 10){
        _playerCt = playerCt;
        _playerPosList = new List<PlayerPos>(new PlayerPos[_playerCt]){ 
            new PlayerPos(new Vector3(-8.309975f, -16.38184f, 0.05430984f), true),
            new PlayerPos(new Vector3(-8.309975f, -16.38184f, -2.19569f), true),
            new PlayerPos(new Vector3(-8.309975f, -16.38184f, -4.94569f), true),
            new PlayerPos(new Vector3(-8.309975f, -16.38184f, -7.44569f), true),
            new PlayerPos(new Vector3(-8.309975f, -16.38184f, -9.94569f), true),
            new PlayerPos(new Vector3(-8.309975f, -16.38184f, -12.44569f), true),
            new PlayerPos(new Vector3(-11.55997f, -16.38184f, -8.44569f), true),
            new PlayerPos(new Vector3(-11.55997f, -16.38184f, -6.19569f), true),
            new PlayerPos(new Vector3(-11.55997f, -16.38184f, -3.44569f), true),
        };
    }

    public Vector3 GetPosition(){
        int random = Random.Range(0, _playerCt);
        _playerPosList[random].SetAvailability(false);
        return _playerPosList[random].GetPos();
    }

    // Singleton
    private void Awake() {
        if(instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
}
