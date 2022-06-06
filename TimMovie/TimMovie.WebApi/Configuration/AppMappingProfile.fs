﻿module TimMovie.WebApi.Configuration.AppMappingProfile

open AutoMapper
open TimMovie.Core.DTO.Account
open TimMovie.Core.Entities

type AppMappingProfile() as this =
    inherit Profile()

    do
        this.CreateMap<UserRegistrationDto, User>()
        |> ignore
