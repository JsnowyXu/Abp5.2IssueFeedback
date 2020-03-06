using System;
using System.Threading.Tasks;
using Abp;
using Abp.Notifications;
using Fun2RepairMVC.Authorization.Users;

namespace Fun2RepairMVC.Notifications
{
    public class NotificationManager :  Fun2RepairMVCDomainService, INotificationManager
    {

        private readonly INotificationPublisher _notificationPublisher;

        public NotificationManager(INotificationPublisher notificationPublisher)
        {
            _notificationPublisher = notificationPublisher;
        }

        public async Task WelcomeToFIHsAsync(User user)
        {

            await _notificationPublisher.PublishAsync(
             Fun2RepairMVCConsts.NotificationConstNames.WelcomeToFIH,
                new MessageNotificationData(L("WelcomeToFIH")),severity:NotificationSeverity.Success,userIds:new []{user.ToUserIdentifier()}
                );
        }

        public async Task SendMessageAsync(UserIdentifier user, string messager, NotificationSeverity severity = NotificationSeverity.Info)
        {
            await _notificationPublisher.PublishAsync(
               Fun2RepairMVCConsts.NotificationConstNames.SendMessageAsync,
                new MessageNotificationData(messager),severity:severity,userIds:new []{user});
        }
    }
}