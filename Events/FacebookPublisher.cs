using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class FacebookPublisher
    {
        private event EventHandler<NotificationEventArgs> _notificationSent;
        private readonly object _lock = new object();

        public event EventHandler<NotificationEventArgs> NotificationSent
        {
            add
            {
                _notificationSent += value;
            }
            remove
            {
                _notificationSent -= value;
            }
        }

        public void PublishNotification(string title, string message)
        {
            OnNotificationSent(new NotificationEventArgs(title, message));
        }

        protected virtual void OnNotificationSent(NotificationEventArgs e)
        {
            EventHandler<NotificationEventArgs> handler;

            handler = _notificationSent;


            if (handler != null)
            {
                try
                {
                    handler(this, e);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while notifying subscribers: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("No subscribers to notify.");
            }
        }
    }
}
