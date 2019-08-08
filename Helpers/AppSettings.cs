using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAVSS.Helpers
{
    public class AppSettings
    {
        #region Properities for JWT signature
        public string Site { get; set; }
        public string Audience { get; set; }
        public string ExpireTime { get; set; }
        public string Secret { get; set; }
        #endregion
    }
}
