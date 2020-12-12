using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoJob.DTO.DTOs.AciliyetDtos;
using ToDoJob.DTO.DTOs.AppUserDtos;
using ToDoJob.DTO.DTOs.JobDtos;
using ToDoJob.DTO.DTOs.NotificationDtos;
using ToDoJob.DTO.DTOs.RaporDtos;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Aciliyet-AciliyetDto
            CreateMap<AddAciliyetDto, Aciliyet>();
            CreateMap<Aciliyet, AddAciliyetDto>();
            CreateMap<UpdateAciliyetDto, Aciliyet>();
            CreateMap<Aciliyet, UpdateAciliyetDto>();
            CreateMap<AciliyetListDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetListDto>();
            #endregion

            #region AppUser-AppUserDto
            CreateMap<AddUserDto, AppUser>();
            CreateMap<AppUser, AddUserDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<UserSignInDto, AppUser>();
            CreateMap<AppUser, UserSignInDto>();
            #endregion

            #region Notification-NotificationDto
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region Job-JobDto
            CreateMap<AddJobDto, Job>();
            CreateMap<Job, AddJobDto>();
            CreateMap<UpdateJobDto, Job>();
            CreateMap<Job, UpdateJobDto>();
            CreateMap<JobListDto, Job>();
            CreateMap<Job, JobListDto>();
            CreateMap<JobAllListDto, Job>();
            CreateMap<Job, JobAllListDto>();
            #endregion

            #region Rapor-RaporDto
            CreateMap<AddRaporDto, Rapor>();
            CreateMap<Rapor, AddRaporDto>();
            CreateMap<UpdateRaporDto, Rapor>();
            CreateMap<Rapor, UpdateRaporDto>();
            #endregion
        }
    }
}
