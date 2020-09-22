namespace ButtonDeckClient.Workflows
{
    public abstract class Event
    {
        public abstract void Subscribe(ICommandContext commandContext);
        public abstract void Unsubscribe(ICommandContext commandContext);

        protected void RunWorkflows(IEventContext eventContext)
        {
            // TODO : Do stuff
        }
    }
}
