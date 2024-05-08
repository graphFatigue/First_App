using System.Text;
using TaskBoard.Domain.Enum;

namespace TaskBoard.Common.Extensions
{
    internal static class ActionModelExtension
    {
        //public static string SetMessage(this Domain.Entities.Action action)
        //{
        //    StringBuilder message = new StringBuilder();
        //    switch (action.ActionType)
        //    {
        //        case ActionType.Update:
        //            message.Append("Updated");
        //            break;
        //        case ActionType.Delete:
        //            message.Append("Deleted");
        //            break;
        //        case ActionType.Create:
        //            message.Append("Created");
        //            break;
        //        default: break;
        //    }

        //    if (action.ListCards is not null)
        //    {
        //        message.Append($" list with cards '{ action.ListCards.Name}' at {action.ActionTime.ToString("h:mm tt")} {action.ActionTime.ToLongDateString()}");
        //    }
        //    if (action.Card is not null)
        //    {
        //        message.Append($" card '{action.Card.Name}' at {action.ActionTime.ToString("h:mm tt")} {action.ActionTime.ToLongDateString()}");
        //    }
            
        //    return message.ToString();   
        //}
    }
}
