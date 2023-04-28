public class jResponse
{
    public bool error { get; set; }
    public string message { get; set; }
    public dynamic data { get; set; }
   
    public jResponse(bool error, string message, dynamic data)
    {
        this.error =  error;
        this.message = message;
        this.data = data;
    }
}
