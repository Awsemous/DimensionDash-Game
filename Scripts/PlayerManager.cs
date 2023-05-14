using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
public class PlayerManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    int characterIndex;
    public CinemachineVirtualCamera VCam;
    public CinemachineVirtualCamera vCam2;
    public static bool MultiMode = true;
    

    // Start is called before the first frame update
    void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject Player = Instantiate(playerPrefabs[characterIndex]);
        var ItemCollector = Player.GetComponent<ItemCollector>();
        var Cameraobj = Camera.main.gameObject;
        ItemCollector.cherryText = Camera.main.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        VCam.m_Follow = Player.transform;
        Debug.Log(MultiMode);
        if (MultiMode)
        {
            int characterIndex2 = PlayerPrefs.GetInt("SelectedCharacter2", 0);
            GameObject Player2 = Instantiate(playerPrefabs[characterIndex2]);
            var player2Move = Player2.GetComponentInChildren<PlayerMovement>();
            player2Move.isPlayer2 = true;
            var ItemCollector2 = Player2.GetComponent<ItemCollector>();
            var Cameraobj2 = Instantiate(Camera.main.gameObject);
            ItemCollector2.cherryText = Cameraobj2.GetComponentInChildren<TextMeshProUGUI>();
            var CherryText2position = ItemCollector2.cherryText.transform.position;
            CherryText2position.x = 2000;
            ItemCollector2.cherryText.transform.position= CherryText2position;
            vCam2.m_Follow = Player2.transform;
            VCam.gameObject.layer = 8;
            vCam2.gameObject.layer = 7;
            var Camera1 = Cameraobj.GetComponent<Camera>();
            Camera1.cullingMask = RemoveLayerFromLayerMask(Camera1.cullingMask, 7);
            vCam2.gameObject.SetActive(true);
            var Camera2 = Cameraobj2.GetComponent<Camera>();
            Camera2.cullingMask = RemoveLayerFromLayerMask(Camera2.cullingMask, 8);
            Camera1.rect = new Rect(0, 0, .5f, 1);
            Camera2.rect = new Rect(.5f, 0, .5f, 1);
        }
    }
    public static int RemoveLayerFromLayerMask(int layerMask, int layer) { return layerMask & ~(1 << layer); }
}