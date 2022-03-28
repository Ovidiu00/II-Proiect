﻿using MediatR;
using OnlineStore.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.Requests.Commands
{
    public record AddProductCommand(AddProductDTO addProductDTO, int categroryId) : IRequest<ProductDTO>;
}
