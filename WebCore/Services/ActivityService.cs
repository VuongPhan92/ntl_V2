using Data;
using Domain.Command;
using Domain.IServices;
using Infrastructure.Decorator;

namespace WebCore.Services
{
    public class ActivityService : IService<Activity>, IActivityService
    {
        private readonly ICommandHandler<ActivityAddCommand> addActivityHandler;

        public ActivityService(ICommandHandler<ActivityAddCommand> _addActivityHandler)
        {
            addActivityHandler = _addActivityHandler;
        }

        public void AddActivity(ActivityAddCommand command)
        {
            addActivityHandler.Handle(command);
        }
    }
}
