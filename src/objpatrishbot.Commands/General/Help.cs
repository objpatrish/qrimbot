using System;
using System.Reflection;
using System.Threading.Tasks;
using objpatrishbot.Commands.Attributes;

namespace objpatrishbot.Commands
{
    [Command("Help", "-h", "--help")]
    public class Help : BaseCommand 
    {
        public override string GetResponse()
        {
            return "This is the help menu, probably need helper methods to create the whole thing";
        }
    }
}