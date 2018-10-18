using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROSBridge;
using SimpleJSON;

namespace RoboyWalk
{
    public class RoboyCommandMsg : ROSBridgeMsg {

        private string _cmd;
        private string _content;

        public RoboyCommandMsg(JSONNode msg)
        {
            _cmd = msg["cmd"];
            _content = msg["content"];
        }

        public RoboyCommandMsg(string cmd, string content)
        {
            _cmd = cmd;
            _content = content;
        }

        public static string GetMessageType()
        {
            return "walking_roboy/RoboyCommand";
        }

        public string GetCmd()
        {
            return _cmd;
        }

        public string GetContent()
        {
            return _content;
        }

        public override string ToString()
        {
            return "cmd: " + _cmd + " content: " + _content;
        }

        public override string ToYAMLString()
        {
            return "{\"cmd\": " + _cmd + ", \"content\": " + _content + "}";
        }
    }
}