using System;
using System.Collections;

namespace Application.Model
{
    public class Pagination<T> : List<T> where T : class, new()
    {
        public Pagination(IEnumerable<T> ts)
        {
            Data = ts;
        }

        public  IEnumerable<T> Data {get;set;}

        //public IEnumerator<T> GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

