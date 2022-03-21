using System;
using System.Collections.Generic;
using System.Text;

namespace Navigation
{
    class Task
    {
        public Task(string taskId, string description, string assigned, DateTime deadLine)
        {
            TaskId = taskId;
            Description = description;
            Assigned = assigned;
            DeadLine = deadLine.ToShortDateString();
        }

        public string TaskId { get; set; }
        public string Description { get; set; }

        public string Assigned { get; set; }

        public string DeadLine { get; set; }

    }
}
