using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Communication.WCFService;
using AAA.Meta.Command;
using AAA.Base.Util.Json;

namespace AAA.PublisherClient
{
    public class PublisherClient
    {
        private WCFCommandClient _commandClient = null;
        
        public PublisherClient()
        {
            _commandClient = new WCFCommandClient();
        }

        public void Connect()
        {
            _commandClient.Connect("net.tcp://localhost:8100/AAA.Communication.WCFService/CommandService");
        }

        public Dictionary<string, string> LoginServer(string strAccount, string strPassword)
        {   
            
            CommandProfile command = new CommandProfile();            
            command.Command = "Login";
            command.SetValue("Account", strAccount);
            command.SetValue("Password", strPassword);

            command = _commandClient.ExecuteCommand(command);
            return command.Data;
        }

        public Dictionary<string, string> GetAccountInfo(string strAccount)
        {
            CommandProfile command = new CommandProfile();
            command.Command = "GetArticleCategoryList";
            command.SetValue("Account", strAccount);

            command = _commandClient.ExecuteCommand(command);

            return command.Data;
        }

        public Dictionary<string, string> VersionCheckInfo()
        {
            CommandProfile command = new CommandProfile();
            command.Command = "GetSystemConfig";
            command.SetValue("Category", "VersionCheck");

            command = _commandClient.ExecuteCommand(command);
            return command.Data;
        }

        public Dictionary<string, string> GetFunctionList(string strAccount)
        {
            CommandProfile command = new CommandProfile();
            command.Command = "GetFunctionList";
            command.SetValue("Account", strAccount);

            command = _commandClient.ExecuteCommand(command);
            return command.Data;
        }

        public Dictionary<string, string> QueryAccountList()
        {
            Dictionary<string, string> dicParameter = new Dictionary<string, string>();

            CommandProfile command = new CommandProfile();
            command.Command = "QueryAccountListCommand";
            command = _commandClient.ExecuteCommand(command);
            return command.Data;
        }

        public string[] GetArticleCategories(string strAccount)
        {
            CommandProfile command = new CommandProfile();
            command.Command = "GetArticleCategoryList";
            command.SetValue("Account", strAccount);

            command = _commandClient.ExecuteCommand(command);
            return command.Data["CategoryList"].Split(',');
        }
    }
}
