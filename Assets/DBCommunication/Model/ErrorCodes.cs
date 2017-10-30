namespace DBErrorCodeAndMessages
{
    public class ErrorCodes
    {
        public const int success = 1;
        public const int someThingIsWrong = -1;
        public const int hasDupricateThings = -2;

        public bool isError(int code)
        {
            return (code <= -1);
        }

        public string getMessage(int code, string objective, string exceptionMessage = null)
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


                }

                if(exceptionMessage != null)
                    message += " (" + exceptionMessage + ").";
            }
;
            return message;
        }

    }
}
