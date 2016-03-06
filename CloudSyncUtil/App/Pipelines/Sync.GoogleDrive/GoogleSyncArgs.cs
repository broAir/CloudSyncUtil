﻿using CloudSyncUtil.Core.Pipelines;
using CloudSyncUtil.Integrations.GoogleDrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines.Sync.GoogleDrive
{
    public class GoogleSyncArgs:CloudSyncPipelineArgs<GoogleCloudRepository, Google.Apis.Drive.v3.Data.File>
    {
    }
}
