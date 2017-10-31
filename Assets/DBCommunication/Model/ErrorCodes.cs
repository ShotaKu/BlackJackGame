using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBErrorCodeAndMessages
{
    [Serializable]
    public class ErrorCodes
    {
        private string objective;
        public const int success = 1;
        public const int someThingIsWrong = -1;
        public const int hasDupricateThings = -2;
        public const int objectNotFound = -3;
        public const int completedOperation = -4;
        public const int alreadyHasPlayer = -5;

        public ErrorCodes(string objective)
        {
            this.objective = objective;
        }

        public bool isError(int code)
        {
            return (code <= -1);
        }

        public string getMessage(int code, string exceptionMessage = null)
        {
            string message = objective;

            if (code == success)
                message += " success.";
            else
            {
                if (isError(code))
                {
                    message += " Failed: ";
                    if (code == someThingIsWrong)
                        message += "Some thing occor in data changes";
                    else if (code == hasDupricateThings)
                        message += "There are some dupricate data in database";
                    else if (code == objectNotFound)
                        message += "There are no such information record in database.";
                    else if (code == completedOperation)
                        message += objective + " are already compleated operation.";
                    else if (code == alreadyHasPlayer)
                        message += "Other player already joined.";

                }

                if (exceptionMessage != null)
                    message += " (" + exceptionMessage + ").";
            }
;
            return message;
        }


    }
}
