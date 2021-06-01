using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHolder : MonoBehaviour
{
    InfoHolder instance;
    public Vector3 PlayerStartPosition;
    public GameObject mainPlayer;
    public GameObject ShieldPlayer, BlasterPlayer;
    public Transform firstPosi, Secondpos;
    private void Awake()
    {
        instance = this;
        PlayerStartPosition = mainPlayer.transform.position;
    }
    




}
