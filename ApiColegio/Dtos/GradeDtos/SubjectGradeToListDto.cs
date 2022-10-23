﻿using ApiColegio.Dtos.SubjectDtos;
using ApiColegio.Models;

namespace ApiColegio.Dtos.GradeDtos
{
    public class SubjectGradeToListDto
    {

        public string Subject { get; set; } = null!;
        //  public string Teacher { get; set; } = null!;

        public int FirstPartial { get; set; }
        public int? SecondPartial { get; set; }
        public int? ThirdPartial { get; set; }

    }
}