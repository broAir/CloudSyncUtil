using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Pipelines
{
    public abstract class Pipeline<TArgs> where TArgs : PipelineArgs
    {
        protected List<Processor<TArgs>> Processors;

        public bool IsRunning { get; protected set; }
        public bool PendingCancel { get; protected set; }

        protected Pipeline(List<Processor<TArgs>> processors = null)
        {
            Processors = processors ?? new List<Processor<TArgs>>();
        }

        public void AddProcessor(Processor<TArgs> processor)
        {
            Processors.Add(processor);

            Processors = Processors.OrderBy(x => x.Priority).ToList();
        }

        public virtual void Run(TArgs args)
        {
            IsRunning = true;

            foreach (var processor in Processors)
            {
                if (!PendingCancel)
                {
                    processor.Process(args);
                }
                else
                {
                    args.Cancel = true;
                    break;
                }
            }
        
            IsRunning = false;
        }

        public virtual void Abort()
        {
            PendingCancel = true;
        }

    }
}
