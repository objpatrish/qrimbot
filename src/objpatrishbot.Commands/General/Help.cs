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
            return "Probably need helper methods to create the whole thing piecewise so it can be formatted";
        }
    }
}