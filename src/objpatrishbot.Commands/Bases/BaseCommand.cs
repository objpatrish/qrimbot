using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using objpatrishbot.Commands.Attributes;

namespace objpatrishbot.Commands
{
    public class BaseCommand : ICommand
    {
        public CommandAttribute _attributeData { get; protected set; }
        public BaseCommand()
        {
            _attributeData = this.GetType().GetCustomAttribute(typeof(CommandAttribute)) as CommandAttribute;
        }
    }
}