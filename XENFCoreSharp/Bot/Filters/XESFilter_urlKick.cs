using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XENFCoreSharp.DoubleDecker;

namespace XENFCoreSharp.Bot.Filters
{
    public partial class XESFilter
    {
        public static void doURLFilter(TGMessage msg, TGUser usr)
        {
            var msg_lower = msg.text.ToLower();
            var contains_atleast = false;


            if (msg_lower.Contains("http://"))
            {
                contains_atleast = true;
            }

            if (msg_lower.Contains("https://"))
            {
                contains_atleast = true;
            }

            if (msg_lower.Contains(".co"))
            {
                contains_atleast = true;
            }

            if (msg_lower.Contains(".cn"))
            {
                contains_atleast = true;
            }

            if (!contains_atleast) // It's cheaper to check this filters condition first than it is to make sql queries.
                return; 


            var chat = msg.chat; // grab chat.

            var enabled = XenforceRoot.getGroupConfigurationValueX(chat, "kickurlunactivated", false); // Check configuration value.

            if (!enabled) // return if not enabled.
                return;

            var qsc = "SELECT * FROM xen_activations WHERE activated=0 AND `group`={0} AND `forwho`={1}"; // 

            var rqry = string.Format(qsc, chat.id, usr.id);
            MySql.Data.MySqlClient.MySqlDataReader datar;

            var queryok = SQL3.Query(rqry, out datar);
            bool onerow = false;

            if (datar != null && datar.HasRows) // They've already been kicked before. If we return at least one row, then its valid to assume they havent activated 
            { // There can only be one activation index per user per group.
                onerow = true;               
            }

            if (datar != null)
            {
                datar.Close();
            }

            if (!onerow)
                return; // There was no activation 

            var wtf = msg.replySendMessage(usr.first_name + " was removed from the chat for sending URL/Media before activating!");
            XenforceRoot.AddCleanupMessage(msg.chat.id, wtf.message_id, 30);
            Telegram.kickChatMember(msg.chat, msg.from, 30);
        }
    }
}
