using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROSBridge;
using SimpleJSON;

namespace RoboyWalk
{
    public class RosCommandSubscriber : ROSBridgeSubscriber
    {

        public new static string GetMessageTopic()
        {
            return "/roboy/material";
        }

        public new static string GetMessageType()
        {
            return StringMsg.GetMessageType();
        }

        public new static ROSBridgeMsg ParseMessage(JSONNode msg)
        {
            return new StringMsg(msg);
        }

        public static new void CallBack(ROSBridgeMsg msg)
        {
            StringMsg strMsg = (StringMsg)msg;
            GroundsManager.Instance.ChangeGround(strMsg.GetData());
        }
    }
}

