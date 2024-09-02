using AP_Theme_5.Application.Abstract;
using AP_Theme_5.Contracts;
using AP_Theme_5.Contracts.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Application.AuditEvent.Commands.CreateAuditEvent
{
    public class CreateAuditEventCommandHandler :
        ICommandHandler<CreateAuditEventCommand, Domain.Entities.HistoricData.AuditEvent>
    {
        private readonly IAuditEventRepository _auditEventRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAuditEventCommandHandler(IAuditEventRepository auditEventRepository, IUnitOfWork unitOfWork)
        {
            _auditEventRepository = auditEventRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Domain.Entities.HistoricData.AuditEvent> Handle(CreateAuditEventCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.HistoricData.AuditEvent result = new Domain.Entities.HistoricData.AuditEvent( request.action, request.worker );
            _auditEventRepository.AddAuditEvent( result );
            _unitOfWork.SaveChanges();

            return Task.FromResult( result );
        }


    }

    

}
