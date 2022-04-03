using MediatR;
using Microsoft.AspNetCore.Http;

namespace OnlineStore.Business.Mediator.HelperCommands
{
    public record SavePhotoCommand(IFormFile formFile): IRequest<string>;
}
