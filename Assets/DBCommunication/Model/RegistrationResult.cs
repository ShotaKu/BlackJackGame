using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Result
{
    [Serializable]
    public class Result
    {
        public int ErrorCode;
        public string Message;
    }
    [Serializable]
    public class RegistrationResult : Result
    {
        public string FriendCode;
    }
}

