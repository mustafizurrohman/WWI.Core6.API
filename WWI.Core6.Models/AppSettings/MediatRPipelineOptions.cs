using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWI.Core6.Models.AppSettings
{
    /// <summary>
    /// 
    /// </summary>
    public class MediatRPipelineOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public bool EnableLoggingBehaviour {get; init; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool EnableRetryBehaviour {get; init; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool EnableTimingBehaviour {get; init; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool EnableValidationBehaviour {get; init; }

    }
}
