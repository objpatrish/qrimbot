using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace objpatrishbot.Commands.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class,
                        AllowMultiple = false)
    ]
    public class DiscordCommandAttribute : Attribute
    {
        public string Name { get; private set; } //e.g help
        public string TriggerString { get; private set; } //e.g. h, ls, pwd, etc.
        public DiscordCommandAttribute(string name, string triggerString)
        {
            this.Name = name;
            this.TriggerString = triggerString;
        }
    }
}
