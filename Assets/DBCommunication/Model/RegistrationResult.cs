using DBErrorCodeAndMessages;
using System;

namespace BlackJackGame.Models
{
    [Serializable]
    public class Result
    {
        public int ErrorCode;
        public string Message;

        public void setCodeAndMessage(int code, string message)
        {
            ErrorCode = code;
            Message = message;
        }

        public void setSuccessMessage(ErrorCodes err)
        {
            ErrorCode = ErrorCodes.success;
            Message = err.getMessage(ErrorCode);
        }
    }
    [Serializable]
    public class RegistrationResult : Result
    {
        public string FriendCode;
    }
}

