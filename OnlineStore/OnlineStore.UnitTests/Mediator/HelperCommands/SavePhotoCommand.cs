using MediatR;
using Microsoft.AspNetCore.Http;

namespace OnlineStore.UnitTests.Mediator.HelperCommands
{
    /// <summary>
    /// Salveaza imaginea intr-un folder si retunreaza un nume unit al pozei cu care s-a salvat, pentru a putea fi stochat in db
    /// </summary>
    public record SavePhotoCommand(IFormFile formFile): IRequest<string>;
}
