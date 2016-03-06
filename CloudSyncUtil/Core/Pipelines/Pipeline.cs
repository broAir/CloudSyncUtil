using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Pipelines
{
    public abstract class Pipeline<TArgs> where TArgs : PipelineArgs
    {
        private TaskFactory taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
        protected List<Processor<TArgs>> Processors;
        
        public bool IsRunning = false;
        public bool PendingCancel = false;

        protected Pipeline(List<Processor<TArgs>> processors = null)
        {
            Processors = processors ?? new List<Processor<TArgs>>();
        }

        public void AddProcessor(Processor<TArgs> processor)
        {
            Processors.Add(processor);

            Processors = Processors.OrderBy(x => x.Priority).ToList();
        }

        protected virtual async Task<int> Run(TArgs args)
        {
            if (IsRunning)
                return 1;

            IsRunning = true;

            foreach (var processor in Processors)
            {
                if (!PendingCancel)
                {
                    await taskFactory.StartNew(()=> processor.Process(args));
                }
                else
                {
                    args.Cancel = true;
                    break;
                }
            }
        
            IsRunning = false;

            return args.ExitCode;
        }

        public virtual void Abort()
        {
            PendingCancel = true;
        }

    }
}
