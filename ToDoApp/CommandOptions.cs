using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace ToDoApp
{
    public class CommandOptions
    {
        [Option('a', "add", HelpText = "Add a new Task.")]
        public string Add { get; set; }

        [Option('d', "done", HelpText = "Set one Task to Done.")]
        public int DoneID { get; set; }

        [Option('p', "print", HelpText = "Print \"open\"; \"done\" or \"all\" Tasks.")]
        public string TasksToPrint { get; set; }

        [Option('e', "edit", MutuallyExclusiveSet = "zero", HelpText = "Edit \"ID\" \"new string\".")]
        public int EditID { get; set; }

        [Option('f', "find", MutuallyExclusiveSet = "zero", HelpText = "Find a string in \"open\" \"done\" or \"all\" Tasks")]
        public string Find { get; set; }

        [Option('x', "export", HelpText = "Export \"open\" \"done\" or \"all\" Tasks to html.")]
        public string TaskStatusToExport { get; set; }

        [Option('#', "tag", HelpText = "Find a specific tag #...")]
        public string Tag { get; set; }

        [Option('t', "alltags", HelpText = "Print all tags #...")]
        public string AllTags { get; set; }

        [ValueOption(1)]
        public string SecondArgument { get; set; }

        [HelpOption]
        public string Help()
        {
            string help = HelpText.AutoBuild(this,
                (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
            return help;
        }
    }
}
