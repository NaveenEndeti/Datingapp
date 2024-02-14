namespace API;

public class ApiExceptions
{
    public ApiExceptions(int statuscode, string message,string details)
    {
        StatusCode=statuscode;
        Messages=message;
        Details=details;
    }

    public int StatusCode {get;set;}

    public string Messages{get;set;}

    public string Details{get;set;}
}
