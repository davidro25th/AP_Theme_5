using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.AuditEvent.Commands.UpdateAuditEvent
{
    public class UpdateAuditEventCommandHandler :
        ICommandHandler<UpdateAuditEventCommand>
    {
        private readonly IAuditEventRepository _auditEventRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuditEventCommandHandler(IAuditEventRepository auditEventRepository, IUnitOfWork unitOfWork)
        {
            _auditEventRepository = auditEventRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle( UpdateAuditEventCommand request, CancellationToken cancellationToken)
        {
            _auditEventRepository.UpdateAuditEvent(request.auditEvent);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }

        
    }
}
