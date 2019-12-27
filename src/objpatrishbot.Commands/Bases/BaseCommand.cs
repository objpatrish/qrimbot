using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using objpatrishbot.Commands.Attributes;
using objpatrishbot.Infrastructure;

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
            // OTHER OPTION: Get all attributes in this assembly, filter, then add.
            // Ideally, there will be some attribute stating what type, so we don't get
            // commands we don't want for our specific handler. Proof of concept for now.
            // At that point an interface can fully replace this base class if desired.
        }

        public virtual string GetResponse()
        {
            return String.Empty; // Add something more intelligent here
        }
    }
}