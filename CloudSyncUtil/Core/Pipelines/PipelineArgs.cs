﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Pipelines
{
    public class PipelineArgs
    {
        public bool Cancel { get; set; }

        public int ExitCode { get; set; }

        public Exception Exception { get; set; }

        public bool HasException { get; set; }
    }
}
