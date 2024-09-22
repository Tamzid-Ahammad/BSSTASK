using ChatAppApi.Entities;
using ChatAppApi.Model;

namespace ChatAppApi.Business_Interface.ServiceQuery
{
    public interface IMessageService
    {
        void Add(Message message);
        Task<Message> DeleteMessage(MessageDeleteModel messageDeleteModel);
    }
}
