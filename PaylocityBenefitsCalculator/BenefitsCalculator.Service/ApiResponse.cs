using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsCalculator.Service
{
    /// <summary>
    /// Added 'Status' here. Sometimes there are situations where we need to return
    /// one of two, three or four codes, and to prevent having to put conditional logic
    /// in the controller, it can be handled from the service layer and keep the
    /// controller a bit leaner.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
    }

}
