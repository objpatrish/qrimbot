using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using objpatrishbot.Commands.Attributes;

namespace objpatrishbot.Commands
{
    // Do something here that makes it more explicit that ICommand methods
    // needs to be overriden, no compiler issues when deriving a class from this 
    public class BaseCommand : ICommand
    {
        public CommandAttribute _attributeData { get; protected set; }
        public BaseCommand()
        {
            _attributeData = this.GetType().GetCustomAttribute(typeof(CommandAttribute)) as CommandAttribute;
        }

        public virtual string GetResponse()
        {
            return String.Empty; // Add something more intelligent here
        }
    }
}