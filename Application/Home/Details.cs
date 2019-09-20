using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Errors;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using MediatR;

namespace Application.Home
{
    public class Details
    {
        public class Query : IRequest<HomeDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, HomeDto>
        {
            private readonly IAppRepository<Homes> _appRepo;
            private readonly IMapper _mapper;

            public Handler(IAppRepository<Homes> appRepo, IMapper mapper)
            {
                _appRepo = appRepo;
                _mapper = mapper;
            }
            public async Task<HomeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var home = await _appRepo.Search(x => x.Id == request.Id);

                if (home== null) throw new RestException(HttpStatusCode.NotFound, new { home = "Care Home could not be found."} );

                return _mapper.Map<HomeDto>(home);
            }
        }
    }
}