using System;
using System.Collections.Generic;
using System.Text;

namespace PrCSharp_lab_4
{
    public class Message
    {
        public Contact Author { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool hasBeenRedacted { get; private set; }

        public Message(Contact author, string text)
        {
            Author = author ?? throw new ArgumentNullException(nameof(author));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            CreatedAt = DateTime.Now;
            hasBeenRedacted = false;
        }

        public void Redact(string text)
        {
            Text = text;
            hasBeenRedacted = true;
        }

        public override string ToString()
        {
            return $"<{CreatedAt}> by {Author.Name}: {Text}, has been redacted: {hasBeenRedacted}";
        }

        public void Deconstruct(out DateTime creationDate)
        {
            creationDate = CreatedAt;
        }
    }
}
