using CloudSyncUtil.Core.Integrations;
using CloudSyncUtil.Core.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines
{
    public class CloudSyncPipelineArgs<TRepository, TFile>:PipelineArgs where TRepository:CloudRepository<TFile>
    {
        public TRepository Repository { get; set; }
    }
}
