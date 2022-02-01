using UnityEngine;
using Unity.Notifications.Android;
using System.Collections;
using System.Collections.Generic;

public class NeedsNotification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        var channel = new AndroidNotificationChannel(){
            Id = "channel_id",
            Name = "Notification Channel",
            Importance = Importance.Default,
            Description = "Reminder notification"
        };   
        if(Player.Hunger <= 0){  
            AndroidNotificationCenter.RegisterNotificationChannel(channel);

            var hungerNotification = new AndroidNotification();
            hungerNotification.Title = "Comeback And Play!";
            hungerNotification.Text = "I'm Hungry";
            hungerNotification.FireTime = System.DateTime.Now.AddSeconds(15);

            AndroidNotificationCenter.SendNotification(hungerNotification, "channel_id");
        

            var hungerId = AndroidNotificationCenter.SendNotification(hungerNotification, "channel_id");

            if(AndroidNotificationCenter.CheckScheduledNotificationStatus(hungerId) == NotificationStatus.Scheduled){
                AndroidNotificationCenter.CancelAllNotifications();
                AndroidNotificationCenter.SendNotification(hungerNotification, "channel_id");
            }
        }

        if(Player.Energy <= 0){
            var energyNotification = new AndroidNotification();
            energyNotification.Title = "Comeback And Play!";
            energyNotification.Text = "I'm Sleepy";
            energyNotification.FireTime = System.DateTime.Now.AddSeconds(15);

            AndroidNotificationCenter.SendNotification(energyNotification, "channel_id");

            var energyId = AndroidNotificationCenter.SendNotification(energyNotification, "channel_id");

            if(AndroidNotificationCenter.CheckScheduledNotificationStatus(energyId) == NotificationStatus.Scheduled){
                AndroidNotificationCenter.CancelAllNotifications();
                AndroidNotificationCenter.SendNotification(energyNotification, "channel_id");
            }
        }

        if(Player.Hygiene <= 0){
            var cleanlinessNotification = new AndroidNotification();
            cleanlinessNotification.Title = "Comeback And Play!";
            cleanlinessNotification.Text = "I'm Dirty";
            cleanlinessNotification.FireTime = System.DateTime.Now.AddSeconds(15);

            AndroidNotificationCenter.SendNotification(cleanlinessNotification, "channel_id");

            var cleanlinessId = AndroidNotificationCenter.SendNotification(cleanlinessNotification, "channel_id");

            if(AndroidNotificationCenter.CheckScheduledNotificationStatus(cleanlinessId) == NotificationStatus.Scheduled){
                AndroidNotificationCenter.CancelAllNotifications();
                AndroidNotificationCenter.SendNotification(cleanlinessNotification, "channel_id");
            }
        }
    }
}
