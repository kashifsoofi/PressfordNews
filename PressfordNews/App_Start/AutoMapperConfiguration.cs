using AutoMapper;
using PressfordNews.Model;
using PressfordNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PressfordNews
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<ArticleCreateViewModel, Article>();
            Mapper.CreateMap<ArticleEditViewModel, Article>()
                .ReverseMap();

            Mapper.CreateMap<UserCreateViewModel, AppUser>();
        }
    }
}