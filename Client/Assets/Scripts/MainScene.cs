using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grpc.Core;

public class MainScene : MonoBehaviour
{  
    Channel m_Channel;

    void Start()
    {
        Connect();
    }

    void Connect()
    {
        m_Channel = new Channel("localhost", ChannelCredentials.Insecure);
    }

    public void OnClick() => Debug.Log("haha");
}
