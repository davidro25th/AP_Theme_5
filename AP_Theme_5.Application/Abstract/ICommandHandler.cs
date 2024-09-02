using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.Abstract
{
    public interface ICommandHandler<TComand>:
        IRequestHandler<TComand> 
        where TComand : ICommand
    {

    }

    public interface ICommandHandler<TComand, TResponse>
        : IRequestHandler<TComand,TResponse>
        where TComand : ICommand<TResponse>
    {

    }

}
