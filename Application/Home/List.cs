using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Home
{
    public class List
    {
        public class Query : IRequest<List<HomeDto>>
        {
            public class Handler : IRequestHandler<Query, List<HomeDto>>
            {
                private readonly CareHomeContext _context;
                private readonly IMapper _mapper;
                public Handler(CareHomeContext context, IMapper mapper)
                {
                    _context = context;
                    _mapper = mapper;
                }

                public async Task<List<HomeDto>> Handle(Query request, CancellationToken cancellationToken)
                {
                    return _mapper.Map<List<HomeDto>>(await _context.Homes.ToListAsync());
                }
            }
        }
    }
}