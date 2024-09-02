using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using AP_Theme_5.Contracts.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.AuditEvent.Commands.DeleteAuditEvent
{
    public class DeleteAuditEventCommandHandler : ICommandHandler<DeleteAuditEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditEventRepository _auditEventRepository;

        public DeleteAuditEventCommandHandler(IUnitOfWork unitOfWork, IAuditEventRepository auditEventRepository)
        {
            _unitOfWork = unitOfWork;
            _auditEventRepository = auditEventRepository;
        }

        public Task Handle(DeleteAuditEventCommand request, CancellationToken cancellationToken) 
        {
            var AuditEventToDelete = _auditEventRepository.GetAuditEventById(request.id);
            if (AuditEventToDelete == null)
               return Task.CompletedTask;
            
            _auditEventRepository.DeleteAuditEvent(AuditEventToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }

    }

    

}
