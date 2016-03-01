using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Pipelines
{
    public abstract class Processor<TArgs> where TArgs:PipelineArgs
    {
        public int Priority { get; set; }

        protected abstract void DoProcess();

        public virtual void Process(TArgs args)
        {
            if (!args.Cancel)
            {
                DoProcess();
            }
        }
    }
}
