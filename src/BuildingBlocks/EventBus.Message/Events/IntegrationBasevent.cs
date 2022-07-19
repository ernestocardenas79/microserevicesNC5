using System;

namespace EventBus.Message.Events
{
    public class IntegrationBasevent
    {
        public Guid Id { get; private set; }
        public DateTime CreatioDate { get; private set; }

        public IntegrationBasevent()
        {
            Id = new Guid();
            CreatioDate = DateTime.Now;
        }

        public IntegrationBasevent(Guid id, DateTime creatioDate)
        {
            Id = id;
            CreatioDate = creatioDate;
        }
    }
}
