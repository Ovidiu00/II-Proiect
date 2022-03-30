using MediatR;

namespace OnlineStore.Business.Mediator.Requests.Commands
{
    public record AddSubcategoryToCategoryCommand(int ParentId, int ChildId) : IRequest<bool>;

}