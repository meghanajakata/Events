namespace Events
{

    public class Program
    {
        public event EventHandler<NotificationEventArgs> OnNotificationRecieved;
        static void Main(string[] args)
        { 
            FacebookPublisher publisher = new FacebookPublisher();

            publisher.NotificationSent += OnNotificationSent;
            publisher.NotificationSent += OnNotificationSentAdditional;
            publisher.NotificationSent += OnNotificationSentAnother;

            publisher.PublishNotification("New Post", "Check out our latest blog post!");

            publisher.NotificationSent -= OnNotificationSent;
            publisher.NotificationSent -= OnNotificationSentAdditional;
            publisher.NotificationSent -= OnNotificationSentAnother;

            publisher.PublishNotification("Another Post", "Check out another blog post!");
        }



        static void OnNotificationSent(object sender, NotificationEventArgs e)
        {
            try
            {
                Console.WriteLine("Subscriber 1 - Notification Received:");
                Console.WriteLine($"Title: {e.Title}");
                Console.WriteLine($"Message: {e.Message}");
                Console.WriteLine($"Timestamp: {e.Timestamp}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Subscriber 1 event handler: {ex.Message}");
            }
        }

        static void OnNotificationSentAdditional(object sender, NotificationEventArgs e)
        {
            try
            {
                Console.WriteLine("Subscriber 2 - Notification Received:");
                Console.WriteLine($"Title: {e.Title}");
                Console.WriteLine($"Message: {e.Message}");
                Console.WriteLine($"Timestamp: {e.Timestamp}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Subscriber 2 event handler: {ex.Message}");
            }
        }

        static void OnNotificationSentAnother(object sender, NotificationEventArgs e)
        {
            try
            {
                Console.WriteLine("Subscriber 3 - Notification Received:");
                Console.WriteLine($"Title: {e.Title}");
                Console.WriteLine($"Message: {e.Message}");
                Console.WriteLine($"Timestamp: {e.Timestamp}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Subscriber 3 event handler: {ex.Message}");
            }
        }
    }
}