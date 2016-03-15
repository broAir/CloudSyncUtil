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

        protected Processor() : this(100) { }

        protected Processor(int priority)
        {
            Priority = priority;
        }

        // to set up error code and args.cancel
        protected virtual void Cancel(TArgs args, Exception e = null)
        {
            args.Cancel = true;
            // generic error
            args.ExitCode = 999;

            if (e != null)
            {
                args.Exception = e;
                args.HasException = true;
            }
        }

        protected abstract void DoProcess(TArgs args);

        public virtual void Process(TArgs args)
        {
            if (!args.Cancel)
            {
                DoProcess(args);
            }
        }
    }
}
