﻿using CloudSyncUtil.Core.Integrations;
using CloudSyncUtil.Core.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines
{s
    public class CloudSyncPipelineArgs:PipelineArgs
    {
        public CloudRepository Repository { get; set; }
    }
}
