using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandsCount = int.Parse(Console.ReadLine());

            var listCommands = new List<string>();
            for (int i = 0; i < commandsCount; i++)
            {
                listCommands.Add(Console.ReadLine());
            }

            var result = CommandHandler(listCommands);

            Console.WriteLine(result);
        }

        public static string CommandHandler(List<string> listCommands)
        {
            var builder = new List<string>();
            for (int i = 0; i < listCommands.Count; i++)
            {
                var line = listCommands[i].Split(' ').ToList();
                var command = int.Parse(line[0]);

                switch (command)
                {
                    case 1:
                        Editor.Append(line[1]);
                        break;
                    case 2:
                        Editor.Delete(int.Parse(line[1]));
                        break;
                    case 3:
                        builder.Add(Editor.Print(int.Parse(line[1])));
                        break;
                    case 4:
                        Editor.Undo();
                        break;
                    default:
                        break;
                }
            }
            return string.Join("\r\n", builder);
        }
    }
}
