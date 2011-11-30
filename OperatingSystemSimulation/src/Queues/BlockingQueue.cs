using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OperatingSystemSimulation.src.Queues
{
    public class BlockingQueue<T>
    {
        private readonly Queue<T> queue = new Queue<T>();

        public void EnQueue(T item)
        {
            lock (queue)
            {
                queue.Enqueue(item);

                if (queue.Count == 1)
                    Monitor.PulseAll(queue);
            }
        }

        public T DeQueue()
        {
            lock (queue)
            {
                if (queue.Count == 0)
                    Monitor.Wait(queue);

                return queue.Dequeue();
            }
        }

        public int Count
        {
            get
            {
                lock (queue)
                    return queue.Count;
            }
        }
    }
}
