using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace objpatrishbot.Commands.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class,
                        AllowMultiple = false)
    ]
    public class CommandAttribute : Attribute
    {
        public string Name { get; private set; } //e.g help
        public List<string> TriggerStrings { get; private set; } //e.g. -h --help
        public CommandAttribute(string name, params string[] triggerStrings)
        {
            this.Name = name;
            this.TriggerStrings = triggerStrings.ToList();
        }
    }
}
