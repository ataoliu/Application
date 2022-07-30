using System;
namespace Application.Util.Model
{
	public class Result
	{
        public object type { get; set; }
        public object message { get; set; }
        public object resultdata { get; set; }
    }
    public enum ResultType
    {
        
        error,
        success,

    }
}

