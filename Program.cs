using System;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var trfk = new TrFk();

app.MapGet("/", trfk.get);
app.Run();

class TrFk
{
    public string get(HttpRequest request, HttpResponse response)
    {
        if (!Int32.TryParse(request.Query["s"], out int size)) size = 0;
        if (!Int32.TryParse(request.Query["d"], out int delay)) delay = 0;
        if (delay > 0) {
            Thread.Sleep(delay);
        }
        string data = "";
        if (size > 0) {
            Random rr = new Random();
            string content = "0123456789abcdef";
            int xx = content.Length;
            char[] fill = new char[size];
            for (int ii = 0; ii < size; ii++) {
                fill[ii] = content[rr.Next(xx)];
            }
            data = new string(fill);
        }
        response.Headers["X-Trfk-Size"] = $"{size}";
        response.Headers["X-Trfk-Delay"] = $"{delay}";
        return data;
    }
}
