namespace EntertainmentSystem.Data.Common.Models
{
    using System;

    public abstract class BaseModelGuid : BaseModel<Guid>
    {
        public BaseModelGuid()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
