using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using Domain.Interfaces;
using MediatR;

namespace Application.Home
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IAppRepository<Homes> _appRepo;

            public Handler(IAppRepository<Homes> appRepo)
            {
                _appRepo = appRepo;
            }
            
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var home = await _appRepo.Search(x => x.Id == request.Id);

                if (home == null) throw new RestException(HttpStatusCode.NotFound, new { home = "Care Home could not be found."} );

                _appRepo.Delete(home);

                if (await _appRepo.SaveAllAsync()) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}