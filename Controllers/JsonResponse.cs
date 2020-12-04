using System.Collections.Generic;

namespace CourseApi.Controllers
{
    //Json Response to Call after every succesful/fail call
    public class JsonResponse<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<T> Results { get; set; }

        public List<T> Result { get; set; }


    }
}