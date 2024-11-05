namespace Orders_Managment_System.Middlewares
{
    public class LimitRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public static int counter = 0;
        public static DateTime _datetime = DateTime.Now;

        public LimitRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            counter++;
            if (DateTime.Now.Subtract(_datetime).Seconds > 10)
            {
                counter = 1;
                _datetime = DateTime.Now;
                await _next(context);
            }
            else
            {
                if (counter > 5)
                {
                    _datetime = DateTime.Now;
                    await context.Response.WriteAsync("request number excedded");
                }
                else
                {
                    _datetime = DateTime.Now;
                    await _next(context);
                }
            }
        }

    }
}

