using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameConfigTools.Util
{
    public class LogQueue
    {
        public static readonly LogQueue instance = new LogQueue();

        private readonly Queue<string> queue = new Queue<string>();

        public void Add(string log)
        {
            lock (queue)
            {
                queue.Enqueue(DateTime.Now + " - " + log + "\r\n");
            }
        }

        public string Take()
        {
            lock (queue)
            {
                if (queue.Count > 0)
                {
                    return queue.Dequeue();
                }
                return null;
            }
        }
    }
}
