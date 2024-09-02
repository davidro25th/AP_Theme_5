using AP_Theme_5.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP_Theme_5.Domain.Types;

namespace AP_Theme_5.Application.Variable.Query.GetVariableByID
{
    public record GetVariableByIDQuery(Guid Id) : IQuery<Domain.Entities.Configuration_Data.Variable?>;
}
