using System;

namespace CSNK.Common.Base.APIClient
{
    public class APIResponse
    {
        public bool IsSuccessful { get; set; }
        public string Result { get; set; }
        public Exception ErrorException { get; set; }
    }
}
