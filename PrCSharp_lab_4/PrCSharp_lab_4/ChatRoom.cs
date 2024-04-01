using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrCSharp_lab_4
{
    public class ChatRoom
    {
        
        public string Name { get; set; } 
        public List<Contact> Contacts { get; set; }
        private List<Message> Messages { get; set; }

        public void AddMessage(Message message)
        {
            if (!Contacts.Contains(message.Author))
            {
                Contacts.Add(message.Author);
            }
            Messages.Add(message);
        }

        public void GetStatistics(out (string, int, string) tuple)
        {
            var messagesByAuthor = Messages.GroupBy(x => x.Author);

            var shortestMessageGroup = messagesByAuthor.OrderByDescending(x => x.Count()).FirstOrDefault();
            string shortestMessageAuthorName = shortestMessageGroup.Key.Name;
            int messageCount = shortestMessageGroup.Count();
            string shortestMessageText = shortestMessageGroup.Select(x => x.Text).OrderByDescending(x => x.Length).FirstOrDefault();
            tuple = (shortestMessageAuthorName, messageCount, shortestMessageText);
        }
    }
}
