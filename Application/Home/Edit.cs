using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Errors;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.Home
{
    public class Edit
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string City { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public int Rating { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.City).NotEmpty();
                RuleFor(x => x.Address).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Rating).NotEmpty().InclusiveBetween(1, 5);
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IAppRepository<Homes> _appRepo;
            private readonly IMapper _mapper;

            public Handler(IAppRepository<Homes> appRepo, IMapper mapper)
            {
                _appRepo = appRepo;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var home = await _appRepo.Search(x => x.Id == request.Id);

                if (home == null) throw new RestException(HttpStatusCode.NotFound, new { home = "Care Home could not be found."} );

                _mapper.Map<Command, Homes>(request, home);

                 if (await _appRepo.SaveAllAsync()) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}