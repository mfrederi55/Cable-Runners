using Unity.Netcode;
using UnityEngine;

public class GameplayStartup : MonoBehaviour {
    void Start() {
        if (GameSession.IsHost) {
            NetworkManager.Singleton.StartHost();
            Debug.Log("Game session Host");
        } else {
            NetworkManager.Singleton.StartClient();
            Debug.Log("Game session Client");
        }
    }
}