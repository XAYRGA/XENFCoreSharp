using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XENFCoreSharp.DoubleDecker;

namespace XENFCoreSharp.Bot.Commands
{
    static class ConfigCommand
    {
        public static void getValueBool(TGMessage data, string[] arguments)
        {
            if (arguments.Length > 0)
            {
                //data.replySendMessage("Xen Enforce Bot V3.1.4.5 (Serg--- Circle?)\n\nDocumentation on commands is available at http://www.xayr.ga/xenforce/");
                // throw new Exception("fuuuuck");
                var ok = XenforceRoot.getGroupConfigurationValue(data.chat, arguments[0], false);
                var repl = "The current value of {0} is {1}";

                data.replySendMessage(string.Format(repl,arguments[0],ok));
            }
            else
            {
                data.replySendMessage("The usage of this command is: getbool <valname>");
            }
        }

        public static void getValueInt(TGMessage data, string[] arguments)
        {
            if (arguments.Length > 0)
            {
                var ok = XenforceRoot.getGroupConfigurationValue(data.chat, arguments[0], -999912);
                if (ok==-999912)
                {
                    data.replySendMessage(string.Format("The configuration attribute {0} doesn't exist.",arguments[0]));
                }

                var repl = "The current value of {0} is {1}";
                data.replySendMessage(string.Format(repl, arguments[0], ok));
            }
            else
            {
                data.replySendMessage("The usage of this command is: getint <valname>");
            }
        }

        public static void setValueInt(TGMessage data, string[] arguments)
        {
            if (arguments.Length > 1)
            {
                var before = arguments[1];
                var after = 0;
                try
                {
                    after = Int32.Parse(before);
                    var success = XenforceRoot.writeGroupConfiguration(data.chat, arguments[0], after);
                    if (!success)
                    {
                        data.replySendMessage(string.Format("That didn't work. The configuration item {0} might not exist or is already this value.", arguments[0]));
                    } else
                    {
                        data.replySendMessage(string.Format("Success, set {0} to {1}",arguments[0], before));
                    }

                } catch
                {
                    data.replySendMessage(string.Format("Sorry, I couldn't understand the value '{0}', you need to use a number.",before));                    
                }
            }
            else
            {
                data.replySendMessage("The usage of this command is: setint <valname> <value>");
            }
        }

        public static void setValuebool(TGMessage data, string[] arguments)
        {
            if (arguments.Length > 1)
            {
                var before = arguments[1];
                var after = before == "true";
      
                if (before=="true" || before=="false")
                {
                    var success = XenforceRoot.writeGroupConfiguration(data.chat, arguments[0], after );
                    if (!success)
                    {
                        data.replySendMessage(string.Format("That didn't work. The configuration item {0} might not exist or is already this value.", arguments[0]));
                    }
                    else
                    {
                        data.replySendMessage(string.Format("Success, set {0} to {1}", arguments[0], before));
                    }
                }
                else
                {
                    data.replySendMessage(string.Format("Sorry, I couldn't understand the value '{0}', you need to use a boolean (true/false).", before));
                }
            }
            else
            {
                data.replySendMessage("The usage of this command is: setint <valname> <value>");
            }
        }


        public static void load()
        {
            XenforceCommandInterpreter.AddCommand("getbool", getValueBool);
            XenforceCommandInterpreter.AddCommand("getint", getValueInt);
            XenforceCommandInterpreter.AddCommand("setint", setValueInt);
            XenforceCommandInterpreter.AddCommand("setbool", setValuebool);
        }
    }
}
