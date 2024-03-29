using MediatR;
using Domain;
using FluentValidation;
using Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Errors;
using System.Net;
using System;
using Application.Dtos;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Home
{
    public class Create
    {
        public class Command : IRequest<HomeDto>
        {
            public string Name { get; set; }
            public string City { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public int Rating { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty().MinimumLength(6).MaximumLength(48);
                RuleFor(x => x.City).NotEmpty();
                RuleFor(x => x.Address).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Rating).NotEmpty().InclusiveBetween(1, 5);
            }
        }

        public class Handler : IRequestHandler<Command, HomeDto>
        {
            private readonly IMapper _mapper;
            private readonly IAppRepository<Homes> _appRepo;

            public Handler(IMapper mapper, IAppRepository<Homes> appRepo)
            {
                _mapper = mapper;
                _appRepo = appRepo;
            }

            public async Task<HomeDto> Handle(Command request, CancellationToken cancellationToken)
            {
                if ((await _appRepo.Search(x => x.Name.ToUpper() == request.Name.ToUpper())) != null) 
                    throw new RestException(HttpStatusCode.BadRequest, new  { Name = "Care Home exists."} );

                var newHomeDto = new HomeDto() 
                {
                    Name = request.Name,
                    City = request.City,
                    Address = request.Address,
                    Email = request.Email,
                    Rating = request.Rating
                };

                _appRepo.Add(_mapper.Map<Homes>(newHomeDto));

                if (await _appRepo.SaveAllAsync()) return newHomeDto;

                throw new Exception("Problem saving new Care Home");
            }
        }
    }
}