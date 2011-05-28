using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.DesignPattern.Observer;

namespace AAA.TradingSystem
{
    public sealed class MessageSubject
    {
        private static MessageSubject _messageSubject = null;

        private Subject _subject;

        public Subject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        private MessageSubject()
        {
            if (_subject == null)
                _subject = new Subject();
        }

        public static MessageSubject Instance()
        {
            if (_messageSubject == null)
                _messageSubject = new MessageSubject();

            return _messageSubject;
        }
    }
}
