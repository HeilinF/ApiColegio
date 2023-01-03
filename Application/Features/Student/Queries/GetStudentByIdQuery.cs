using Application.Dtos.StudentDtos;
using AutoMapper;
using Domain.Interface.Repository.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Student.Queries
{
    public class GetStudentByIdQuery: StudentResponse, IRequest<StudentResponse>
    {
        public int StudentId { get; set; }
    }
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery,StudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<StudentResponse> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _studentRepository.GetByIdAndInclude(request.StudentId);

           var entityMapped =  _mapper.Map<StudentResponse>(entity);

            return entityMapped;
        }
    }
}
