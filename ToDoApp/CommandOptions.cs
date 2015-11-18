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
        public int Done { get; set; }

        [Option('e', "edit", HelpText = "Edit Task \"ID\" with new \"text\".")]
        public int EditIndex { get; set; }
        [ValueOption(1)]
        public string EditText { get; set; }

        [Option('f', "find", HelpText = "Find a string in \"open\"; \"done\" or \"all\" Tasks")]
        public string FindString { get; set; }
        [ValueOption(1)]
        public string FindTarget { get; set; }

        [Option('p', "print", HelpText = "Print \"open\"; \"done\" or \"all\" Tasks.")]
        public string Print { get; set; }

        [Option('x', "export", HelpText = "Export \"open\"; \"done\" or \"all\" Tasks to html.")]
        public string Export { get; set; }

        [Option('#', "tag", HelpText = "Find a specific tag #...")]
        public string Tag { get; set; }

        [Option('t', "alltags", HelpText = "Print all tags #...")]
        public string AllTags { get; set; }

        public string Help()
        {
            string help = HelpText.AutoBuild(this,
                (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
            return help;
        }
    }
}
